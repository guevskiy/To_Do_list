using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using NUnit.Framework;

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

        public string GetResponse()
        {
            // Get the original response.
            WebResponse response = request.GetResponse();

            this.Status = ((HttpWebResponse)response).StatusDescription;

            // Get the stream containing all content returned by the requested server.
            dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        [Test]
        public void Test_MyRequest_001()
        {
            MyWebRequest("https://randomuser.me/api");
            var resp = GetResponse();
            Console.WriteLine(GetResponse());


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

        private static async Task PostRequestAsync()
        {
            WebRequest request = WebRequest.Create("https://aio.tradeone.co.il:29006/V2/xml/login");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = "<Login>\n<User>aio5</User>\n<Password>12345</Password>\n</Login>";
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/x-www-form-urlencoded";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен...");
        }

        [Test]
        public void Test_MyRequest_004()
        {
            PostRequestAsync();
        }

    }
}
