using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace rrp3CW1RapidBrowser
{
    // <summary>
    /// The RapidBrowser class.
    /// Defines the properties of RpidBrowser objects and basic methods
    /// Impletments IDsiplay interface
    /// </summary>
    [Serializable]
    public class RapidBrowser : IDisplay<RapidBrowser>
    {

        // <summary>
        /// Private fields for RapidBwoser Objects
        /// </summary>
        // private fields
        [XmlIgnore]
        private string name;
        private string url;
        [XmlIgnore]
        private string htmlcode;
        [XmlIgnore]
        private string httpcode;
        [XmlIgnore]
        private string title;

        [XmlIgnore]
        public HttpWebRequest req;
        [XmlIgnore]
        public HttpWebResponse res;
        [XmlIgnore]
        public Match m;

        public RapidBrowser(string name, string url, string htmlcode, string httpcode, string title)
        {
            this.name = name;
            this.url = url;
            this.htmlcode = htmlcode;
            this.httpcode = httpcode;
            this.title = title;

        }
        public RapidBrowser(){ }



        // <summary>
        ///Properties to access the private fields
        /// </summary>
        // properties
        [XmlIgnore]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        [XmlIgnore]
        public string HTMLcode
        {
            get { return htmlcode; }
            set { htmlcode = value; }
        }

        [XmlIgnore]
        public string Httpcode
        {
            get { return httpcode; }
            set { httpcode = value; }
        }

        [XmlIgnore]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string HTMLDisplay(RapidBrowser RB)
        {
            //change this to try catch with httpcode execeptions and finally statement with
            //s?.Dispose()
            
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(URL);
                    res = (HttpWebResponse)req.GetResponse();
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader s = new StreamReader(res.GetResponseStream());
                        RB.HTMLcode = s.ReadToEnd();
                        s.Close();
                    }
                    else throw new UnableToSearchException(RB.Httpcode);
                }
                catch (UriFormatException ex)
                {
                    throw new InvalidOperationException(
                   String.Format("Use a correct URL format "), ex);

                }
            
            return (RB.HTMLcode);

        }

        
        public string HttpDisplay(RapidBrowser RB)
        {
           

                res = (HttpWebResponse)req.GetResponse();


                if (res.StatusCode == HttpStatusCode.OK)
                {
                    RB.Httpcode = "Http Status code is 200 - " + res.StatusDescription;
                }
                else if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    RB.Httpcode = "Http Status code is 404 - " + res.StatusDescription;
                }
                else if (res.StatusCode == HttpStatusCode.Unauthorized)
                {
                    RB.Httpcode = "Http Status code is 401 - " + res.StatusDescription;
                }
                else if (res.StatusCode == HttpStatusCode.Forbidden)
                {
                    RB.Httpcode = "Http Status code is 403 - " + res.StatusDescription;
                }
                else throw new UnableToSearchException(RB.Httpcode);

                return (RB.Httpcode);
           
        }


        public string TitleDisplay(RapidBrowser RB)
        {
           
                Match m = Regex.Match(RB.HTMLcode, @"<title>\s*(.+?)\s*</title>");
                if (m.Success)
                {
                    RB.Title = m.Groups[1].Value;
                    return (RB.Title);
                }
                else
                {
                    return "";
                }
            
        }

    }
}

