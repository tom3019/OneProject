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
    class NN
    {
        public void NNurlAddress()
        {
            //北北
            string NNurlAddress = "https://branch.taipower.com.tw/Content/NoticeBlackout/bulletin.aspx?&SiteID=564732636524040174&MmmID=616371300130136031";

            HttpWebRequest NNrequest = (HttpWebRequest)WebRequest.Create(NNurlAddress);

            HttpWebResponse NNresponse = (HttpWebResponse)NNrequest.GetResponse();

            if (NNresponse.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = NNresponse.GetResponseStream();
                StreamReader readStream = null;

                if (NNresponse.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(NNresponse.CharacterSet));
                }

                string data = readStream.ReadToEnd().Replace("，", Environment.NewLine);
                //==========================================================

                //===========================HtmlAgilityPack============

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(data);

                //輸出成txt
                DateTime d = DateTime.Now;
                string Sameday = d.GetDateTimeFormats('D')[1].ToString();
                string dirPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\北北區";
                if (Directory.Exists(dirPath))
                {
                    Console.WriteLine("success");
                }
                else
                {
                    Directory.CreateDirectory(dirPath);
                    Console.WriteLine("The directory {0} was created.", dirPath);
                }

                StreamWriter str = new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}\北北區\{Sameday}-北北區.txt");
                // str.WriteLine(data);

                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
                {
                    str.WriteLine("(北北區)日期:" + table.Id);
                    //Console.WriteLine("Date:" + table.Id);
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {

                        str.WriteLine();
                        //Console.WriteLine("row");
                        foreach (HtmlNode cell in row.SelectNodes("th|td"))
                        {

                            str.WriteLine(cell.InnerText);
                            // Console.WriteLine("cell:" + cell.InnerText);
                        }
                    }
                }

                //===========================HtmlAgilityPack============
                str.Close();
                NNresponse.Close();
                readStream.Close();
                //  Console.ReadLine();

            }



        }

    }
}
