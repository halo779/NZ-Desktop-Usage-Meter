using System;
using System.Net;

namespace WebClient
{
    /// <summary>
    /// WebClient class is very useful when you need to download or upload date from or to the Web.
    /// However, when you need to make a sequence of calls you find that WebClient does not preserve cookies set by the server between requests.
    /// Fortunately, WebClient gives you an opportunity to handle cookies by yourself.
    /// The very simple solution is to override GetWebRequest method of the WebClient class and set CookieContainer property.
    /// </summary>
    public class CookieAwareWebClient : System.Net.WebClient
    {
        private CookieContainer m_container = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = m_container;
            }
            return request;
        }
    }
}
