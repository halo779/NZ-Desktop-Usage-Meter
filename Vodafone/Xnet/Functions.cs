using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml;

namespace Isps.Xnet
{
    /// <summary>
    /// Holds all functions which are used for processing Xnet Usage Meter
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Changes the Password into the Token used to authenticate on the API.
        /// </summary>
        /// <param name="Password">The users password.</param>
        /// <returns>Api Token</returns>
        public static string ApiToken(string Password)
        {
            MD5 md5 = MD5.Create();
            byte[] IB = Encoding.ASCII.GetBytes(Password);
            byte[] Hash = md5.ComputeHash(IB);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Hash.Length; i++)
            {
                sb.Append(Hash[i].ToString("x2"));
            }

            return sb.ToString();
        }
        /// <summary>
        /// Reads the a value from the XML.
        /// </summary>
        /// <param name="xdocu">The XML file.</param>
        /// <param name="Node">The node to read from.</param>
        /// <returns>the text inside the node; if the node doesn't exist a blank string is returned</returns>
        public static string ReadXmlValue(XmlDocument xdocu, string Node)
        {
            XmlNodeList list = xdocu.GetElementsByTagName(Node);
            if (list[0].InnerText != "")
            {
                return list[0].InnerText;
            }
            else
            {
                return "";
            }
        }
    }
}
