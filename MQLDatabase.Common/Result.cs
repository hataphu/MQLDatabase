using System;
using MQLDatabase.Common.Loger;

namespace MQLDatabase.Common
{
    public class Result<T>
    {
        private ILogerServices _loger;
        public Result(T data, Exception exception, ILogerServices loger)
        {
            _loger = loger;
            Data = data;
            Exception = exception;
            Message = exception.Message;
            if (Exception != null)
            {
                _loger.SystemLog(Exception);
            }
        }
        public Result(T data, string message, Exception exception, ILogerServices loger)
        {
            _loger = loger;
            Data = data;
            Message = message;
            Exception = exception;
            if (Exception != null)
            {
                _loger.SystemLog(Exception);
            }
        }
        public Result(Exception exception, ILogerServices loger)
        {
            _loger = loger;
            Exception = exception;
            Message = exception.Message;
            if (Exception != null)
            {
                _loger.SystemLog(Exception);
            }
        }
        public Result(Exception ex, T data)
        {
            Data = data;
        }
        public Result(T data, string message)
        {
            Data = data;
            Message = message;
        }

        public Result(T data)
        {
            Data = data;
        }
        //dữ liệu trả về
        public T Data { get; set; }
        //Ngoại lệ
        public Exception Exception { get; set; }
        //Thông báo
        public string Message { get; set; }

    }
}
