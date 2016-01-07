using System.IO;
using System.Net;

namespace TrueMedLib
{
    public class WebRequestHelper
    {
        public string Request(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                return reader.ReadToEnd();
            }
            catch
            {
                throw;
            }
        }
    }
}
