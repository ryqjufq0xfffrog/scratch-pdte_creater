using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FontToScratch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ///string[] mojis = new string[65504];
            ///string json = "{\r\n\t\"objName\": \"moji\",\r\n\t\"costumes\": [";
            ///int inputMoji = 0;

            string[] available = File.ReadAllLines(@"C:\Users\user\frog1\scratch\scratch-download\普通に使える文字.txt");
            string arrayTxt = "";
            StreamWriter stw = new StreamWriter(@"C:\Users\user\frog1\scratch\sprites\moji\font.txt", false, Encoding.UTF8);

            for (int i = 0; i < available.Length; i++)
            {
                arrayTxt = "";
                Bitmap moji1 = new Bitmap(20, 20);
                moji1.MakeTransparent();
                Graphics drawMoji = Graphics.FromImage(moji1);
                ///drawMoji.Clear(Color.Transparent);
                drawMoji.Clear(Color.White);
                Font font1 = new Font("Courier New", 10);
                Brush brush1 = Brushes.Black;
                drawMoji.DrawString(available[i],font1,brush1,new PointF(1,1));
                ///json += "{\r\n\t\t\t\"costumeName\": \"" + mojis[i] + "\",\r\n\t\t\t\"baseLayerID\": " + i.ToString() + ",\r\n\t\t\t\"bitmapResolution\": 2,\r\n\t\t\t\"rotationCenterX\": 0,\r\n\t\t\t\"rotationCenterY\": 0\r\n\t\t}";
                ///if (i != inputMoji) json += ",";
                for (int y = 0; y < 20; y++)
                {
                    for (int x1 = 0; x1 < 5; x1++)
                    {
                        int tmpstr = 0;
                        for (int x2 = 0; x2 < 4; x2++)
                        {
                            if (moji1.GetPixel(x1 * 4 + x2, y).R < 80)
                            {
                                tmpstr *= 2;
                                tmpstr += 1;
                            }
                            else
                            {
                                tmpstr *= 2;
                            }
                        }
                        arrayTxt += tmpstr.ToString("X");
                    }
                }
                ///moji1.Save(@"C:\Users\user\frog1\scratch\sprites\moji\"+i.ToString()+".png",System.Drawing.Imaging.ImageFormat.Png);
                ///arrayTxt += "\r\n";
                stw.WriteLine(arrayTxt);
            }
            ///json += "],\r\n\t\"currentCostumeIndex\": 1,\r\n\t\"scratchX\": 0,\r\n\t\"scratchY\": 0,\r\n\t\"scale\": 1,\r\n\t\"direction\": 90,\r\n\t\"rotationStyle\": \"normal\",\r\n\t\"isDraggable\": false,\r\n\t\"indexInLibrary\": 100000,\r\n\t\"visible\": true,\r\n\t\"spriteInfo\": {\r\n\t}\r\n}";
            ///StreamWriter stw = new StreamWriter(@"C:\Users\user\frog1\scratch\sprites\moji\spritetest.json",false,Encoding.UTF8);
            ///stw.Write(json);
            ///StreamWriter stw = new StreamWriter(@"C:\Users\user\frog1\scratch\sprites\moji\array.txt", false, Encoding.UTF8);
            ///stw.Write(arrayTxt);
        }
    }
}
