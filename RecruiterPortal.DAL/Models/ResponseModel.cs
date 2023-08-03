using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RecruiterPortalDAL.Models
{
    public class ResponseModels<T>
    {
        public T Data { get; set; }
        public int Count { get; set; }
        public string Message { get; set; }

        public ResponseModels(string message)
        {
            this.Message = message;
        }
        public ResponseModels(T data, int count)
        {
            this.Data = data;
            this.Count = count;
        }
        public ResponseModels(T data)
        {
            this.Data = data;            
        }
    }
    public class TResponseModels<T>
    {
        public T Data { get; set; }
        public T Count { get; set; }
        public TResponseModels(T data, T count)
        {
            this.Data = data;
            this.Count = count;
        }
    }
}