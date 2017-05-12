using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class WebHelper
    {

        const int BUFFER_SIZE = 1024;
        const int DefaultTimeout = 2 * 60 * 1000; // 2 minutes timeout

        public SNHttpWebResponse GetRequest(string serviceUrl, Dictionary<string, string> headers = null, List<Cookie> cookies = null)
        {
            return CommonHttpRequest(serviceUrl, WebRequestMethods.Http.Get, headers, null, "", cookies);
        }

        public SNHttpWebResponse PostRequest(string serviceUrl, Dictionary<string, string> headers = null, string postData = "", string contentType = "", List<Cookie> cookies = null, string accept = "")
        {
            return CommonHttpRequest(serviceUrl, WebRequestMethods.Http.Post, headers, postData, contentType, cookies, accept);
        }

        public Task<SNHttpWebResponse> GetRequestAsync(string serviceUrl, Dictionary<string, string> headers = null)
        {
            Task<SNHttpWebResponse> getResult = new Task<SNHttpWebResponse>(() => {

                SNHttpWebResponse response = CommonHttpRequest(serviceUrl, WebRequestMethods.Http.Get, headers);
                return response;
            });
            getResult.Start();
            return getResult;
        }

        public Task<SNHttpWebResponse> PostRequestAsync(string serviceUrl, Dictionary<string, string> headers = null, string postData = "", string contentType = "")
        {
            Task<SNHttpWebResponse> postResult = new Task<SNHttpWebResponse>(() => {

                SNHttpWebResponse response = CommonHttpRequest(serviceUrl, WebRequestMethods.Http.Post, headers, postData, contentType);
                return response;
            });
            postResult.Start();
            return postResult;
        }

        public SNHttpWebResponse CommonHttpRequest(string serviceUrl, string type, Dictionary<string, string> headers = null, string postData = "", string contentType = "", List<Cookie> cookies = null, string accept = "")
        {
            HttpWebRequest request = WebRequest.Create(serviceUrl) as HttpWebRequest;
            request.Timeout = 20 * 60 * 1000;
            if (headers != null)
            {
                foreach (string item in headers.Keys)
                {
                    request.Headers.Add(item, headers[item]);
                }
            }

            if (cookies != null)
            {
                if (request.CookieContainer == null)
                {
                    request.CookieContainer = new CookieContainer();
                }

                foreach (var c in cookies)
                {
                    request.CookieContainer.Add(c);
                }
            }

            request.Method = type;
            if (!string.IsNullOrWhiteSpace(accept))
            {
                request.Accept = accept;
            }

            if (!string.IsNullOrWhiteSpace(postData))
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(postData);
                request.ContentLength = bytes.Length;

                if (string.IsNullOrWhiteSpace(contentType))
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                }
                else
                {
                    request.ContentType = contentType;
                }

                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bytes, 0, bytes.Length);
                    reqStream.Close();
                }
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string responseStream = GetResponseString(response);
            return new SNHttpWebResponse(response.StatusCode, response.StatusDescription, responseStream, response);
        }

        public static string GetResponseString(HttpWebResponse response)
        {
            using (Stream stream = response.GetResponseStream())
            {
                return new StreamReader(stream, Encoding.UTF8).ReadToEnd();
            }
        }

    }

    public class SNHttpWebResponse
    {

        public HttpStatusCode StatusCode { get; private set; }

        public string StatusDescription { get; private set; }

        public string ResponseStream { get; private set; }

        public HttpWebResponse OriginalResponse { get; private set; }

        public SNHttpWebResponse(HttpStatusCode statusCode, string statusDescription, string respoinseStream, HttpWebResponse originalResponse)
        {
            StatusCode = statusCode;

            StatusDescription = statusDescription;

            ResponseStream = respoinseStream;

            OriginalResponse = originalResponse;
        }

    }
}
