using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FSLL.MS.Feedback.Common
{
    public class WebServiceManager
    {
        #region GET
        
        
        /// <summary>
        /// Get back JSON Object 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static object Get(string url)
        {
            WebRequest req = WebRequest.Create(url);
            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    var res = reader.ReadToEnd();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(res);
                    return obj;
                }
            }
            else
            {
                throw new Exception(string.Format("Fail! Status Code: {0}, Status Description: {1}", resp.StatusCode,
                       resp.StatusDescription));
            }
        }

        public static T Get<T>(string url)
        {
            WebRequest req = WebRequest.Create(url);
            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    var res = reader.ReadToEnd();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res);
                    return obj;
                    //return (T)Convert.ChangeType(obj, typeof(T));
                }
            }
            else
            {
                throw new Exception(string.Format("Fail! Status Code: {0}, Status Description: {1}", resp.StatusCode,
                       resp.StatusDescription));
            }
        }
        #endregion

        #region POST
        
        
        public static object Post(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            using (var requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(data);
            }

            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    var res = reader.ReadToEnd();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(res);
                    return obj;
                    //return (T)Convert.ChangeType(res, typeof(T));
                }
            }
            else
            {
                throw new Exception(string.Format("Fail! Status Code: {0}, Status Description: {1}", resp.StatusCode,
                    resp.StatusDescription));
            }
        }

        public static T Post<T>(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            using (var requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(data);
            }

            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    var res = reader.ReadToEnd();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res);
                    return obj;
                    //return (T)Convert.ChangeType(res, typeof(T));
                }
            }
            else
            {
                throw new Exception(string.Format("Fail! Status Code: {0}, Status Description: {1}", resp.StatusCode,
                    resp.StatusDescription));
            }
        }

        #endregion

        
    }
}
