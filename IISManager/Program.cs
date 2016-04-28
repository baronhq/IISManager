using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISManager
{
    class Program
    {
        //新建应用程序池
        const int NUMBEROFPOOLS = 2;
        const int APPPOOLBASENUMBER = 1000;
        const string POOLPREFIX = "Pool_Site";
        const string USERNAMEPREFIX = "PoolId";
        const string PASSWORDPREFIX = "PoolIDPwd";
        const bool ENCRYPTPASSWORD = true;
        static void Main(string[] args)
        {

            //新建应用程序池
            ServerManager mgr = new ServerManager();
            ApplicationPoolCollection pools = mgr.ApplicationPools;
            for (int i = 0; i < NUMBEROFPOOLS; i++)
            {
                CreateAppPool(pools, i + APPPOOLBASENUMBER, POOLPREFIX, USERNAMEPREFIX, PASSWORDPREFIX, ENCRYPTPASSWORD);
            }
            mgr.CommitChanges();
        }

        static bool CreateAppPool(ApplicationPoolCollection pools, int i, string appPoolPrefix, string userNamePrefix, string passwordPrefix, bool bEncryptPassword)
        {
            try
            {
                ApplicationPool newPool = pools.Add(appPoolPrefix + i);
                newPool.ProcessModel.UserName = userNamePrefix + i;
                // the SetMetadata call will remove the encryptionprovider in the schema. This results in clear-text passwords!!!
                //if (!bEncryptPassword)
                //    newPool.ProcessModel.Attributes["password"].SetMetadata("encryptionProvider", "");

                //newPool.ProcessModel.Password = passwordPrefix + i;
                newPool.ProcessModel.IdentityType = ProcessModelIdentityType.ApplicationPoolIdentity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Adding AppPool {0} failed. Reason: {1}", appPoolPrefix + i, ex.Message);
                return false;
            }

            return true;
        }
    }
}
