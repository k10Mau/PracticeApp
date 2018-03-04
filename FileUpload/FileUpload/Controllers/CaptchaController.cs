using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class CaptchaController : Controller
    {
        // GET: Captcha
        public ActionResult Index()
        {
            return View();
        }
        public void GenerateCaptcha()
        {
            using (Bitmap objBitMap = new Bitmap(40, 20))
            {
                using (Graphics objGraphics = Graphics.FromImage(objBitMap))
                {
                    string capchaText = "";
                    int[] randomNoArray = new int[5];
                    Random radomNo = new Random();
                    for(var i=0;i<5;i++)
                    {
                        randomNoArray[i] = radomNo.Next(0,9);
                        capchaText += randomNoArray[i].ToString();
                    }
                    objGraphics.DrawString(capchaText, new Font("Arial", 30, FontStyle.Bold), Brushes.Blue, 5, 5);
                    HttpContext.Session["captchaKey"] = capchaText;
                    HttpContext.Response.ContentType = "image/GIF";
                    objBitMap.Save(HttpContext.Response.OutputStream, ImageFormat.Gif);
                }
            }
        }
    }
}