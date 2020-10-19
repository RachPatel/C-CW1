using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rrp3CW1RapidBrowser
{
    public class History
    {
        Stack<RapidBrowser> history = new Stack<RapidBrowser>();


        public RapidBrowser RapidBrowser { get; set; }

        
        public void AddToHistory(RapidBrowser RB)
        {
            history.Push(RB);
        }

    }
}
