using Core.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Utilities
{
    public static class HttpRequestHelper
    {
    
        public static async Task<HttpResult> HttpPost(string url, string param,string Method = "POST", string accessToken="")
        {
            var result = new HttpResult();

            try
            {
                HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                req.Method =Method;
                req.ContentType = "application/json";
                req.Accept = "application/json";
                req.Headers.Add("Authorization", "Bearer  " + accessToken);

                byte[] formData = UTF8Encoding.UTF8.GetBytes(param.ToString());
                req.ContentLength = formData.Length;

                using (Stream post = req.GetRequestStream())
                {
                    post.Write(formData, 0, formData.Length);
                }

                using (HttpWebResponse resp = await req.GetResponseAsync() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result.Result = reader.ReadToEnd();
                }
            }
            catch (WebException webEx)
            {
                var response = ((HttpWebResponse)webEx.Response);
                StreamReader content = new StreamReader(response.GetResponseStream());
                result.Result = content.ReadToEnd();
                result.Status = false;
            }
            catch (Exception ex)
            {
                result.Result = ex.Message.ToString();
                result.Status = false;

            }
            return result;
        }

        public static async Task<HttpResult> HttpGet(string url, string accessToken)
        {
            var result = new HttpResult();

            try
            {
                HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                req.Method = "GET";
                req.ContentType = "application/json";
                req.Accept = "application/json";
                req.Headers.Add("Authorization", "Bearer  " + accessToken);



                using (HttpWebResponse resp = await req.GetResponseAsync() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result.Result = reader.ReadToEnd();
                }
            }
            catch (WebException webEx)
            {
                var response = ((HttpWebResponse)webEx.Response);
                StreamReader content = new StreamReader(response.GetResponseStream());
                result.Result = content.ReadToEnd();
                result.Status = false;
            }
            catch (Exception ex)
            {
                result.Result = ex.Message.ToString();
                result.Status = false;

            }
            return result;
        }

    }
}
