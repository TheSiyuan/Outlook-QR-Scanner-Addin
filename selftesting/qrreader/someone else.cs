
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
 
namespace ImageToQR
{
    class Program
    {
        static string QRImgPath = @"E:\项目\支付\文档\收款码\未处理\支付宝";
        static string ImgType = @"*.jpg";
        /// <summary>
        /// 识别指定目录下的全部二维码图片（默认是PNG）
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                string[] files;
                if (args.Length > 0)
                {
                    //args[0]为CMD里exe后的第一个参数 ImgType默认配置的*.png
                    files = Directory.GetFiles(args[0], ImgType);
                }
                else
                {
                    //读取指定路劲（QRDecodeConsoleApp.exe.config里配置的路劲）
                    files = Directory.GetFiles(QRImgPath,ImgType);
                }
 
                //存放结果的文件
                string filePath = "txtResult" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".config";
 
                //一个个读取并追加到记录文件
                for (int i = 0; i < files.Length; i++)
                {
                    File.AppendAllText(filePath, CodeDecoder(files[i]) + "\t" + files[i] + "\n");//追加到文件里记录
                    Console.WriteLine("第" + i + "个识别成功");
                }
                Console.WriteLine("识别完成，按任意键退出");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("识别出错：" + ex.Message);
                Console.ReadLine();
            }
 
        }
 
        /// <summary>
        /// 读取图片文件，识别二维码
        /// </summary>
        /// <param name="filePath">图片文件路劲</param>
        /// <returns>识别结果字符串</returns>
        public static string CodeDecoder(string filePath)
        {
            string decoderStr;
            try
            {
                if (!System.IO.File.Exists(filePath))//判断有没有需要读取的主文件夹，如果不存在，终止  
                    return null;
 
                Bitmap bitMap = new Bitmap(Image.FromFile(filePath));//实例化位图对象，把文件实例化为带有颜色信息的位图对象  
                QRCodeDecoder decoder = new QRCodeDecoder();//实例化QRCodeDecoder  
 
                //通过.decoder方法把颜色信息转换成字符串信息  
                decoderStr = decoder.decode(new QRCodeBitmapImage(bitMap), System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return decoderStr;//返回字符串信息  
        }
 
 
    }
}
--------------------- 
作者：昵称全重复 
来源：CSDN 
原文：https://blog.csdn.net/liuzishang/article/details/88534401 
版权声明：本文为博主原创文章，转载请附上博文链接！