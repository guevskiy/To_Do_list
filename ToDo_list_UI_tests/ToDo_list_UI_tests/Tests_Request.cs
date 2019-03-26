using System.Net.Http;
using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;

namespace ToDo_list_UI_tests
{
    class Tests_Request
    {
        private WebRequest request;
        private Stream dataStream;

        private string status;

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public void MyWebRequest(string url)
        {
            // Create a request using a URL that can receive a post.

            request = WebRequest.Create(url);
        }

       

        [Test]
        public void Test_MyRequest_002()
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("https://randomuser.me/api");
            // Sends the HttpWebRequest and waits for a response.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is: {0}",
                                     myHttpWebResponse.StatusDescription);
            // Releases the resources of the response.
            myHttpWebResponse.Close();
        }

        [Test]
        public void Test_MyRequest_003()
        {
            HttpWebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.hhuihp.com/thilink");
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream());
                Console.Write(sr.ReadToEnd());
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)e.Response;
                    Console.Write("Errorcode: {0}", (int)response.StatusCode);
                }
                else
                {
                    Console.Write("Error: {0}", e.Status);
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

        }

        

        
        [Test]
        public void RequestAsync_Login()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://aio.tradeone.co.il:29006/V2/json/login");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{Login: {User: 'aio5', Password: '12345'}}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            XmlDocument xDoc = new XmlDocument();


            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();

                        
           


        }




    }
}
