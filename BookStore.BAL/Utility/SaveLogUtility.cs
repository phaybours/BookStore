using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BAL.Utility
{
    public class SaveLogUtility
    {
        private Object cvLockObject;
        string cvsLogFile = System.Configuration.ConfigurationManager.AppSettings["LogFile"];
        public void SaveLog(string psDetails)
        {
            cvLockObject = new Object();
            lock (cvLockObject)
            {
                string sError = DateTime.Now.ToString() + ": " + psDetails;
                StreamWriter sw = new StreamWriter(cvsLogFile, true, Encoding.ASCII);
                sw.WriteLine(sError);
                sw.Close();
            }
        }
    }
}
