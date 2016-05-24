using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.Management.Client;
using Microsoft.Web.Management.Client.Win32;
using Microsoft.Web.Management.Server;
using Microsoft.Web.Administration;

namespace BlockLinksConf
{
    class BlockLinksConfPage : ModulePage
    { 
        private ServerManager mgr;
        private BlockLinksConfForm cf;

        public BlockLinksConfPage() 
        { 
            mgr = new ServerManager();
            cf = new BlockLinksConfForm(mgr); 
            Controls.Add(cf); 
        }

        protected override void OnActivated(bool initialActivation)
        { 
            base.OnActivated(initialActivation);
            if (initialActivation)
                cf.Initialize();
        }
    }

    class BlockLinksConfModule : Module 
    { 
        protected override void Initialize(IServiceProvider serviceProvider, Microsoft.Web.Management.Server.ModuleInfo moduleInfo) 
        { 
            base.Initialize(serviceProvider, moduleInfo);
            IControlPanel controlPanel = (IControlPanel)GetService(typeof(IControlPanel));
            controlPanel.RegisterPage(new ModulePageInfo(this, typeof(BlockLinksConfPage), "BlockLinks", "Configuration for the BlockLinks Custom Module.")); 
        } 
        
        protected override bool IsPageEnabled(ModulePageInfo pageInfo) 
        { 
            Connection conn = (Connection)GetService(typeof(Connection)); 
            ConfigurationPathType pt = conn.ConfigurationPath.PathType; 
            return pt == ConfigurationPathType.Server; 
        } 
    }

    class BlockLinksConfModuleProvider : ModuleProvider
    {
        public override Type ServiceType
        { 
            get { return null; } 
        } 
        
        public override bool SupportsScope(ManagementScope scope) 
        { 
            return true; 
        } 
        
        public override ModuleDefinition GetModuleDefinition(IManagementContext context) 
        {
            return new ModuleDefinition(Name, typeof(BlockLinksConfModule).AssemblyQualifiedName); 
        } 
    }
}
