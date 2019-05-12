using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTML_original
{
    class NW
    {
        public void NWurlAddress()
        {
            //北西
            string NWurlAddress = "https://branch.taipower.com.tw/Content/NoticeBlackout/bulletin.aspx?&SiteID=564766277367364243&MmmID=616371300000777256";


            HttpWebRequest NWrequest = (HttpWebRequest)WebRequest.Create(NWurlAddress);

            HttpWebResponse NWresponse = (HttpWebResponse)NWrequest.GetResponse();

            if (NWresponse.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = NWresponse.GetResponseStream();
                StreamReader readStream = null;

                if (NWresponse.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(NWresponse.CharacterSet));
                }

                string data = readStream.ReadToEnd().Replace("，", Environment.NewLine);
                //==========================================================

                //===========================HtmlAgilityPack============

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(data);

                //輸出成txt
                DateTime d = DateTime.Now;
                string Sameday = d.GetDateTimeFormats('D')[1].ToString();
                string dirPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\北西區";
                if (Directory.Exists(dirPath))
                {
                    Console.WriteLine("success");
                }
                else
                {
                    Directory.CreateDirectory(dirPath);
                    Console.WriteLine("The directory  {0} was created.", dirPath);
                }



                StreamWriter str = new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}\北西區\{Sameday}-北西區.txt");
                // str.WriteLine(data);

                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
                {
                    str.WriteLine("(北西區)日期:" + table.Id);
                    //Console.WriteLine("Date:" + table.Id);
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {

                        str.WriteLine();
                        //Console.WriteLine("row");
                        foreach (HtmlNode cell in row.SelectNodes("th|td"))
                        {

                            str.WriteLine( cell.InnerText);
                            // Console.WriteLine("cell:" + cell.InnerText);
                        }
                    }
                }

                //===========================HtmlAgilityPack============
                str.Close();
                NWresponse.Close();
                readStream.Close();
                //  Console.ReadLine();

            }



        }

    }
}
