using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using Gma.System.MouseKeyHook;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //nothing happens heres
        }
        private readonly Stopwatch sw = new Stopwatch();
        
        //get a screen shot of a area, with width of w, height of h, centered with x and y 
        private static Bitmap CaptureImage(int x, int y,int w, int h)
        {
            Bitmap b = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(x, y, 0, 0, new Size(w, h), CopyPixelOperation.SourceCopy);
            }
            return b;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            Unsubscribe(); //release the hook in case the autorelease didnt work.
        }
        public static string CodeDecoder(Bitmap examplecapture)
        {
            string decoderStr;
            try
            {
                Bitmap bitMap = examplecapture;//实例化位图对象，把文件实例化为带有颜色信息的位图对象  
                QRCodeDecoder decoder = new QRCodeDecoder();//实例化QRCodeDecoder  

                //通过.decoder方法把颜色信息转换成字符串信息  
                decoderStr = decoder.decode(new QRCodeBitmapImage(bitMap), System.Text.Encoding.UTF8);
                bitMap.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return decoderStr;//返回字符串信息  
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Subscribe(); //engage the hook.
        }
        

        private void Button1_Click(object sender, EventArgs e)
        {
            //nothing happens here.     
        }

        private IKeyboardMouseEvents m_GlobalHook;

        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
        }
        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            //Console.WriteLine("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);
            Bitmap bmp = null;
            int width = 300;
            int height = 300;
            //this.Cursor = new Cursor(Cursor.Current.Handle);
            
            try
            {
                //sw.Restart();
                //string[] files;
                bmp = CaptureImage(Cursor.Position.X - width / 2, Cursor.Position.Y - height / 2, width, height);
                //bmp.Save(@"E:\VS Project\GitHub\QR Code Things\selftesting\test.png");
                //files = Directory.GetFiles(@"E:\VS Project\GitHub\QR Code Things\selftesting\", @"*.png");
                //Console.WriteLine(sw.ElapsedMilliseconds);
                //Console.WriteLine(CodeDecoder(new Bitmap(Image.FromFile(files[0]))));
                Console.WriteLine(CodeDecoder(bmp));
                //Console.WriteLine(sw.ElapsedMilliseconds);
                //sw.Stop();
                //Console.WriteLine(sw.ElapsedMilliseconds);
                bmp.Dispose();
            }
            catch (Exception ex)
            {
                //nothing happens here
                //Console.WriteLine("识别出错：" + ex.Message);
                //Console.ReadLine();
                //Console.WriteLine(sw.ElapsedMilliseconds);
            }
            Unsubscribe();
        }
        public void Unsubscribe()
        {
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }
    }
}
