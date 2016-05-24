#define _WINSOCKAPI_
#include <windows.h>
#include <sal.h>
#include <httpserv.h>

// Create the module class.
class CBlockCrossLinks : public CHttpModule
{
    //TODO
    // Implement Notification Method/s
	REQUEST_NOTIFICATION_STATUS
			OnBeginRequest( IN IHttpContext * pHttpContext,
				            IN IHttpEventProvider * pProvider
					       )
    {
		// We won’t be using this, so confirm that to avoid compiler warnings        
		UNREFERENCED_PARAMETER( pProvider );

		// The images folder to be protected
		// Change this value to reflect 
		PCSTR pszProtectedPath = "/images/";
		
		// controls whether to permit loading of images from
		// bookmarks or type the url into the browser location
		BOOL permitBookmarks  = false;

		// Create an HRESULT to receive return values from methods.
		HRESULT hr;

		// Buffer size for returned variable values.
		DWORD cbValue = 512;

		// Allocating buffers for relevant
		// CGI environment variable values
		PCSTR pszServerName =
				(PCSTR) pHttpContext->AllocateRequestMemory( cbValue );
		PCSTR pszReferer =
				(PCSTR) pHttpContext->AllocateRequestMemory( cbValue );
		PCSTR pszPathInfo =
				(PCSTR) pHttpContext->AllocateRequestMemory( cbValue );

		if(  pszPathInfo == NULL ||
			 pszServerName == NULL ||
			 pszReferer == NULL
		   )
		{
				// looks like a memory allocation problem
				// bail out and let IIS take care of it.
				return RQ_NOTIFICATION_CONTINUE;
		}
		
        // Retrieve a pointer to the response.
        IHttpResponse * pHttpResponse = pHttpContext->GetResponse();

        // start by inspecting the path
        hr = pHttpContext->GetServerVariable("PATH_INFO",
                                              &pszPathInfo,
                                              &cbValue);

        if( hr != S_OK )
        {
                // Can't determine whether this is an image folder request,
                // so give it back to IIS to finish it off.
                return RQ_NOTIFICATION_CONTINUE;
        }

        // is it the folder of interest?
        if( strstr( pszPathInfo, pszProtectedPath ) == NULL )
        {
                // not a path of interest - let it go through unchallenged
                return RQ_NOTIFICATION_CONTINUE;
        }
        // Look for the "SERVER_NAME" variable.
        hr = pHttpContext->GetServerVariable("SERVER_NAME",\
                                              &pszServerName,
                                              &cbValue);

         if( hr != S_OK )
         {
                // No point continuing if we have no SERVER_NAME
                // give it back to IIS to finish it off.
                return RQ_NOTIFICATION_CONTINUE;
         }

         // now retrieve the HTTP_REFERER value
         hr = pHttpContext->GetServerVariable("HTTP_REFERER",&pszReferer,&cbValue);

         // check for a valid result
         if( hr == S_OK )
         {
                // if the referer is the same web site, then pszServerName
                // will appear in pszReferer
                if( strstr(pszReferer, pszServerName) != 0 )
                {
                        // it is there, so this is a valid link
                        return RQ_NOTIFICATION_CONTINUE;
                }
                else
                {
                        // the referer does not match server_name
                        return RQ_NOTIFICATION_FINISH_REQUEST;
                }
         }
        if( hr = ERROR_INVALID_INDEX )
        {
                // the referer value is missing from the header
                if( permitBookmarks )
                        return RQ_NOTIFICATION_CONTINUE;
                else
                        return RQ_NOTIFICATION_FINISH_REQUEST;
        }

        // we only arrive here if there was an error
        // allow IIS to deal with the rest.
        // Return processing to the pipeline.
        return RQ_NOTIFICATION_CONTINUE;

	}
};

// Create the module's class factory.
class CBlockCrossLinksFactory : public IHttpModuleFactory
{
public:
    HRESULT
    GetHttpModule(
        OUT CHttpModule ** ppModule, 
        IN IModuleAllocator * pAllocator
    )
    {
        UNREFERENCED_PARAMETER( pAllocator );

        // Create a new instance.
        CBlockCrossLinks * pModule = new CBlockCrossLinks;

        // Test for an error.
        if (!pModule)
        {
            // Return an error if the factory cannot create the instance.
            return HRESULT_FROM_WIN32( ERROR_NOT_ENOUGH_MEMORY );
        }
        else
        {
            // Return a pointer to the module.
            *ppModule = pModule;
            pModule = NULL;
            // Return a success status.
            return S_OK;
        }            
    }

    void
    Terminate()
    {
        // Remove the class from memory.
        delete this;
    }
};

// Create the module's exported registration function.
HRESULT
__stdcall
RegisterModule(
    DWORD dwServerVersion,
    IHttpModuleRegistrationInfo * pModuleInfo,
    IHttpServer * pGlobalInfo
)
{
	   HRESULT hr = S_OK;

	   UNREFERENCED_PARAMETER( dwServerVersion );
	   UNREFERENCED_PARAMETER( pGlobalInfo );

	   // TODO
	   // Register for notifications
	   // Set notification priority

		// Set the request notifications
		hr = pModuleInfo->SetRequestNotifications(
				new CBlockCrossLinksFactory,
				RQ_BEGIN_REQUEST, // Register for BeginRequest notifications
				0);

		if( hr == S_OK ) // Do this only if there was no error
		{
			hr = pModuleInfo->SetPriorityForRequestNotification(
                        RQ_BEGIN_REQUEST,     // which notification
                        PRIORITY_ALIAS_FIRST  // what priority
                        );
		}

	   return hr;
}
