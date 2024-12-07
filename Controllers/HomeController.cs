using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVCDEMO.Repository;

namespace MVCDEMO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            string original = "The symmetric key is a string used to encrypt the data, and with the exact string, we can decrypt the data, which means a single string is required for encryption and decryption.";
            string encrypted;
            string decrypted;
            byte[] key = null;
            byte[] four = null;
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.GenerateKey();
                des.GenerateIV();
                key = des.Key;
                four = des.IV;
                // Encrypt the string
                encrypted = Cryptograpy.EncryptString(original, key, four);
                Console.WriteLine("Encrypted: {0}", encrypted);
                ViewBag.encrytptedstring = encrypted;
            }
            TempData["key"] = key;
            TempData["four"] = four;
            TempData["encryptionedstring"] = encrypted;
            return View();
        }
        public  ActionResult Test(string Name)
        {
            ViewBag.name = Name;
            return View();
        }

        public ActionResult Encrytion()
        {
            return View();
        }
    }
}