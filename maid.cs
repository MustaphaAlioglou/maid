using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maid
{
    class maid
    {

        string[] Files;
        string workingDirectory;
        
        public void moveFiles(string workDir)
        {
            this.workingDirectory = workDir;
            Files = Directory.GetFiles(workDir, "*.*", SearchOption.TopDirectoryOnly);
            CheckDirectories(workDir, Files);

            foreach (var item in Files)
            {
                try
                {
                    if (Path.GetExtension(item).Substring(1) == "")
                    {
                        continue;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                string exlocation = workDir+"\\" + Path.GetExtension(item).Substring(1);
                File.Move(item, exlocation+"\\"+Path.GetFileName(item));
            }
        }

        private void CheckDirectories(string workingDir, string[] Files)
        {
            string extention;
            foreach (var item in Files)
            {
                try
                {
                    extention = Path.GetExtension(item).Substring(1);
                }
                catch (Exception)
                {
                    continue;
                }
                if (extention == "")
                    continue;

                if (!Directory.Exists(workingDir + "\\" + extention))
                    Directory.CreateDirectory(workingDir + "\\" + extention);
            }
        }
    }
}
