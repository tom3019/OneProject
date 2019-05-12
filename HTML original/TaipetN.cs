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

        class N
        {
            public void NurlAddress()
            {
                //北市
                string NurlAddress = "https://branch.taipower.com.tw/Content/NoticeBlackout/bulletin.aspx?&SiteID=564732646551216421&MmmID=616371300113254267";

                HttpWebRequest Nrequest = (HttpWebRequest)WebRequest.Create(NurlAddress);



                HttpWebResponse Nresponse = (HttpWebResponse)Nrequest.GetResponse();

                if (Nresponse.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = Nresponse.GetResponseStream();
                    StreamReader readStream = null;

                    if (Nresponse.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(Nresponse.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();
                    //==========================================================

                    //===========================HtmlAgilityPack============

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(data);

                    //輸出成txt
                    DateTime d = DateTime.Now;
                    string Sameday = d.GetDateTimeFormats('D')[1].ToString();
                string dirPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\北市區";
                if (Directory.Exists(dirPath))
                {
                    Console.WriteLine("The directory {0} already exists.", dirPath);
                }
                else
                {
                    Directory.CreateDirectory(dirPath);
                    Console.WriteLine("The directory {0} was created.", dirPath);
                }

                StreamWriter str = new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}\北市區\{Sameday}-北市區.txt");
                    // str.WriteLine(data);

                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
                    {
                        str.WriteLine("日期:" + table.Id);
                        //Console.WriteLine("Date:" + table.Id);
                        foreach (HtmlNode row in table.SelectNodes("tr"))
                        {

                            str.WriteLine("row");
                            //Console.WriteLine("row");
                            foreach (HtmlNode cell in row.SelectNodes("th|td"))
                            {

                                str.WriteLine("cell:" + cell.InnerText);
                                // Console.WriteLine("cell:" + cell.InnerText);
                            }
                        }
                    }

                    //===========================HtmlAgilityPack============
                    str.Close();
                    Nresponse.Close();
                    readStream.Close();
                    //  Console.ReadLine();

                }



            }

        }
    }

