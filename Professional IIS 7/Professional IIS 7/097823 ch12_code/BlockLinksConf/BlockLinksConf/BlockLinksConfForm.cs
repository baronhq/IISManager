using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Web.Administration;

namespace BlockLinksConf
{
    public partial class BlockLinksConfForm : UserControl
    {
        private ServerManager mgr;
        private Boolean permitBookmarks;

        public BlockLinksConfForm(ServerManager mgr)
        {
            this.mgr = mgr;
            InitializeComponent();
        }

        private void ReadSettings()
        {
            Configuration config = mgr.GetApplicationHostConfiguration();
            ConfigurationSection sect = config.GetSection("BlockLinksSection");
            permitBookmarks = (Boolean) sect.GetAttributeValue("permitBookmarks");
        }

        public void Initialize()
        {
            ReadSettings();
            checkBox1.Checked = permitBookmarks;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerManager mgr = new ServerManager();
            Configuration conf = mgr.GetApplicationHostConfiguration();
            ConfigurationSection sect = conf.GetSection("BlockLinksSection");
            sect.SetAttributeValue("permitBookmarks", checkBox1.Checked);
            mgr.CommitChanges();
        }
    }
}
