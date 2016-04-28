appcmd.exe set config /section:system.webServer/handlers /+[name=’PHP-FastCGI’,
path=’*.php’,verb=’*’,modules=’FastCgiModule’,scriptProcessor=’c:\program
files\php\php-cgi.exe’,resourceType=’Either’]