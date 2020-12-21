using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MQLDatabase.Common.Loger
{
    public class LogerServices : ILogerServices
    {

        private string _path;
        public LogerServices(string path)
        {
            _path = path;
        }

        public void SystemLog(Exception ex)
        {
            if (Directory.Exists(_path) == false) Directory.CreateDirectory(_path);
            FileStream fileStream = null;
            try
            {
                var directory = new DirectoryInfo(_path);
                if (!directory.Exists)
                {
                    directory.Create();
                }
                var fullFileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
                fileStream = new FileStream(Path.Combine(_path, fullFileName), FileMode.Append, FileAccess.Write, FileShare.ReadWrite);

                var st = new StackTrace(ex, true);
                //Get the first stack frame
                var frame = st.GetFrame(0);
                //Get the file name
                if (frame != null)
                {
                    string fileName = frame.GetFileName();
                    //Get the method name
                    string methodName = frame.GetMethod().Name;
                    //Get the line number from the stack frame
                    int line = frame.GetFileLineNumber();
                    //Get the column number
                    int col = frame.GetFileColumnNumber();

                    var source = string.Format("At line({2}), col({3}), m({1}) of file:{0}", fileName, methodName, line, col);
                    var str = "[" + DateTime.Now.DateTimeToString() + "] " + source + " |x| Message:" + ex.Message + Environment.NewLine;
                    fileStream.Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetByteCount(str));
                }
            }
            catch (Exception) { }
            finally
            {
                fileStream.Close();
                fileStream.Dispose();
            }
        }

        public void History(string mess)
        {
            if (Directory.Exists(_path) == false) Directory.CreateDirectory(_path);
            FileStream fileStream = null;
            try
            {
                var directory = new DirectoryInfo(_path);
                if (!directory.Exists)
                {
                    directory.Create();
                }
                var fullFileName = DateTime.Now.ToString("yyyyMMdd") + ".his";
                fileStream = new FileStream(Path.Combine(_path, fullFileName), FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                var str = "[" + DateTime.Now.DateTimeToString() + "] " + mess + Environment.NewLine;
                fileStream.Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetByteCount(str));
            }
            catch (Exception) { }
            finally
            {
                fileStream.Close();
                fileStream.Dispose();
            }
        }
    }
}
