using System;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutoRestoreBackups
{
    public partial class AutoRestoreService : ServiceBase
    {
        public AutoRestoreService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
