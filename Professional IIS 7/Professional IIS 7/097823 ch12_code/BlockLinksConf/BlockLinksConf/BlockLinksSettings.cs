using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.Administration;

namespace BlockLinksConf
{
    class BlockLinksSettings : ConfigurationSection
    {
        public bool permitBookmarks
        {
            get { return (bool)base["enabled"];}
            set { base["enabled"] = value; }
        }
    }
}

