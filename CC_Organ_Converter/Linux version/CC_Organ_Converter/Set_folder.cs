using System;
using System.Reflection;

namespace CC_Organ_Converter
{
    internal class Set_folder
    {
        private Logger log;
        private string folder_noteinfos;

        public Set_folder(Logger log) {
            this.log = log;
        }

        public string set_noteinfo_folder()
        {
            log.WriteLineToLog("Setting the folder position", "Set_folder");

            var outPutDirectory = Path.GetDirectoryName(AppContext.BaseDirectory);
            string newPath = outPutDirectory;
            this.folder_noteinfos = new Uri(newPath).LocalPath;

            return this.folder_noteinfos;
        }
    }
}
