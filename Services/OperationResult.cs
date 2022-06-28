using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public Exception Exception { get; set; }
    }
    public static class OperationResultHelper
    {
        public static string WriteLog(this OperationResult value)
        {
            if(value.Exception != null)
            {
                return value.Exception.ToString();
            }
            else
            {
                return "No Promble";
            }
        }
    }
}
