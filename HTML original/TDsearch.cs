using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTML_original
{
    public partial class TDsearch : Form
    {
        public TDsearch()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DateTime d = DateTime.Now;

            string Sameday = d.GetDateTimeFormats('D')[1].ToString();
            StreamReader str = new StreamReader($@"{AppDomain.CurrentDomain.BaseDirectory}\北市區\{Sameday}-北市區.txt");
            StreamReader NNstr = new StreamReader($@"{AppDomain.CurrentDomain.BaseDirectory}\北北區\{Sameday}-北北區.txt");
            StreamReader NSstr = new StreamReader($@"{AppDomain.CurrentDomain.BaseDirectory}\北南區\{Sameday}-北南區.txt");
            StreamReader NWstr = new StreamReader($@"{AppDomain.CurrentDomain.BaseDirectory}\北西區\{Sameday}-北西區.txt");
            string line,NNline,NSline,NWline ;


            //string t = textBox1.Text.ToString();
            string t = Strings.StrConv(textBox1.Text.ToString(), VbStrConv.Wide);
            int count=0;
            DateTime yday = d.AddDays(1);//明天
            string yyday = yday.ToString("yyyyMMdd");   //明天轉字串
            string day = d.ToString("yyyyMMdd");    //今天轉字串
            while ((line = str.ReadLine()) != null)
            {
                //  Console.WriteLine(line);

                
                int dayd = line.IndexOf(yyday); // 文本中搜尋明天

                int ttd = line.IndexOf(day);//文本搜尋今天
                int td = line.IndexOf("日期");
                int time = line.IndexOf("至");
                
                int r = line.IndexOf(t);
                
                if (ttd != -1)           //當搜尋到今天日期 count=1
                {
                    count = 1;
                }
                else if (dayd != -1)
                {
                    count = 0;
                }
                // Console.WriteLine(line);
                if (count==1)
                {
                    if (td != -1 || r != -1 || time != -1)  //當搜尋到"日期"  "文字格中的字串" "自"  和count=1
                    {                                             //輸出
                                                                  // Console.WriteLine(line);
                       
                        richTextBox2.Text += $@"{line}" + Environment.NewLine;

                        //if (comma!=-1)
                        //{
                        //    richTextBox2.Text += Environment.NewLine;
                        //}


                    }
                }






                

            }


            while ((NNline = NNstr.ReadLine()) != null)
            {
                //  Console.WriteLine(line);


                int dayd = NNline.IndexOf(yyday); // 文本中搜尋明天

                int ttd = NNline.IndexOf(day);//文本搜尋今天
                int td = NNline.IndexOf("日期");
                int time = NNline.IndexOf("自");
              
                int r = NNline.IndexOf(t);

                if (ttd != -1)           //當搜尋到今天日期 count=1
                {
                    count = 1;
                }
                else if (dayd != -1)

                {
                    count = 0;
                }
                // Console.WriteLine(line);
                if (count == 1)
                {
                    if (td != -1 || r != -1 || time != -1)  //當搜尋到"日期"  "文字格中的字串" "自"  和count=1
                    {                                             //輸出
                                                                  // Console.WriteLine(line);

                        richTextBox2.Text += $@"{NNline}" + Environment.NewLine;

                        //if (comma!=-1)
                        //{
                        //    richTextBox2.Text += Environment.NewLine;
                        //}


                    }
                }








            }

            while ((NSline = NSstr.ReadLine()) != null)
            {
                //  Console.WriteLine(line);


                int dayd = NSline.IndexOf(yyday); // 文本中搜尋明天

                int ttd = NSline.IndexOf(day);//文本搜尋今天
                int td = NSline.IndexOf("日期");
                int time = NSline.IndexOf("自");
          
                int r = NSline.IndexOf(t);

                if (ttd != -1)           //當搜尋到今天日期 count=1
                {
                    count = 1;
                }
                else if (dayd != -1)

                {
                    count = 0;
                }
                // Console.WriteLine(line);
                if (count == 1)
                {
                    if (td != -1 || r != -1 || time != -1)  //當搜尋到"日期"  "文字格中的字串" "自"  和count=1
                    {                                             //輸出
                                                                  // Console.WriteLine(line);

                        richTextBox2.Text += $@"{NSline}" + Environment.NewLine;

                        //if (comma!=-1)
                        //{
                        //    richTextBox2.Text += Environment.NewLine;
                        //}


                    }
                }








            }

            while ((NWline = NWstr.ReadLine()) != null)
            {
                //  Console.WriteLine(line);


                int dayd = NWline.IndexOf(yyday); // 文本中搜尋明天

                int ttd = NWline.IndexOf(day);//文本搜尋今天
                int td = NWline.IndexOf("日期");
                int time = NWline.IndexOf("自");
            
                int r = NWline.IndexOf(t);

                if (ttd != -1)           //當搜尋到今天日期 count=1
                {
                    count = 1;
                }
                else if (dayd != -1)

                {
                    count = 0;
                }
                // Console.WriteLine(line);
                if (count == 1)
                {
                    if (td != -1 || r != -1 || time != -1)  //當搜尋到"日期"  "文字格中的字串" "自"  和count=1
                    {                                             //輸出
                                                                  // Console.WriteLine(line);

                        richTextBox2.Text += $@"{NWline}" + Environment.NewLine;

                        //if (comma!=-1)
                        //{
                        //    richTextBox2.Text += Environment.NewLine;
                        //}


                    }
                }








            }
            str.Close();
            
        }

    }
}
