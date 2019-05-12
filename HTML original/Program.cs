using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTML_original
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            N n = new N();
            n.NurlAddress();
            NN nn = new NN();
            nn.NNurlAddress();
            NS ns = new NS();
            ns.NSurlAddress();
            NW nw = new NW();
            nw.NWurlAddress();
            //test t = new test();
            //t.urlAddress();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TDsearch());

        }
    }

}