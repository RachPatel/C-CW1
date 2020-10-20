using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace rrp3CW1RapidBrowser
{
    public class History
    {

        private List<RapidBrowser> history;

        public History()
        {
            history = new List<RapidBrowser>();
        }

        public void MyHistory (RapidBrowser rb)
        {
            history.Add(rb);
        }
   
        public List<RapidBrowser> GetMyHistory()
        {
            return history;
        }
     
       
     

      
              
      
    }
}