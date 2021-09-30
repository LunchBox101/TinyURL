using System;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace TinyURL
{
    public static class ShrinkURL
    {
        public static string GetShrinkURL(string strURL)
        {
            string URL;
            URL = "http://tinyurl.com/api-create.php?url=" + strURL.ToLower();

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "Get";
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        strURL = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return strURL;
        }
    }
}
