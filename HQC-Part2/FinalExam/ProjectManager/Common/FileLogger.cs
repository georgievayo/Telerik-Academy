using log4net;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Common
{
    public class FileLogger : IFileLogger
    {
        private static ILog log;

        static FileLogger()
        {
            log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void Info(string msg)
        {
            log.Info(msg);
        }
                
        public void Error(string msg)
        {
            log.Error(msg);
        }    
            
        public void Fatal(string msg)
        {
            log.Fatal(msg);
        }
    }
}
