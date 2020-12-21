using System;

namespace MQLDatabase.Common.Loger
{
    public interface ILogerServices
    {
        void SystemLog(Exception ex);
        void History(string mess);
    }
}
