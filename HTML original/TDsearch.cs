using Microsoft.VisualBasic;
using System;
using System.Collections;
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
        string[] area = { "北市區", "北北區", "北南區", "北西區" };
        
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DateTime d = DateTime.Now;
            //string t = textBox1.Text.ToString();
            string t = Strings.StrConv(textBox1.Text.ToString(), VbStrConv.Wide);
            int count=0;
            DateTime yday = d.AddDays(1);//明天
            string yyday = yday.ToString("yyyyMMdd");   //明天轉字串
            string day = d.ToString("yyyyMMdd");    //今天轉字串
            string line ;
            ArrayList text = new ArrayList();
            string[] text1 = new string[5000];
            int num = 1;
            text1[0] = " ";
            string Sameday = d.GetDateTimeFormats('D')[1].ToString();
            foreach (var item in area)
            {
              StreamReader str = new StreamReader($@"{AppDomain.CurrentDomain.BaseDirectory}\{item}\{Sameday}-{item}.txt");
                while ((line = str.ReadLine()) != null)
                {
                    //  Console.WriteLine(line);
                    //text.Add(line);
                    if (num == 0 ||num < 5000)
                    {
                     text1[num] = line;

                    
                    int dayd = line.IndexOf(yyday); // 文本中搜尋明天

                    int ttd = line.IndexOf(day);//文本搜尋今天
                    int td = line.IndexOf("日期");
                    int time = line.IndexOf("分 至");

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

                    switch (count)
                    {
                        case 1:
                            if (td != -1 || r != -1 )  //當搜尋到"日期"  "文字格中的字串" "自"  和count=1
                            {                                             //輸出


                                    //richTextBox2.Text += $"{text1[num]}" + Environment.NewLine; 顯示區域
                                    if (r!=-1)
                                    {

                                        richTextBox2.Text += $"{text1[num - 1]}" + Environment.NewLine;
                                    }
                                                           
                               
                            }

                            break;
                        default:
                            break;
                    }

                        num++;
                    }

                }
            str.Close();
            }



            

            
        }

    }
}
