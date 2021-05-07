using System;

namespace ElixrMarket.Data
{
    public class ApiResult<TData>  
    {
        public TData Data { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Successful { get; set; }
    }
}