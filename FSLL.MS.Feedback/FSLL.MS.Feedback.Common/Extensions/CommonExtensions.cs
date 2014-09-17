using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FSLL.MS.Feedback.Common.Extensions
{
    public static class CommonExtensions
    {
        public static T ToResult<T>(this HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public static async Task<T> ToResult<T>(this Task<HttpResponseMessage> task)
        {
            
            var response = await task;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        
    }
}
