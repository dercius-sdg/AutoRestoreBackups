using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRestoreBackups.Classes
{
    class Settings
    {
        private static Settings instance;
        private Settings(string path)
        {

        }
        public static Settings GetSettings(string path)
        {
            if(instance == null)
            {
                instance = new Settings(path);
            }
            return instance;
        }
    }
}
