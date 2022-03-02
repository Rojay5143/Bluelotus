using B_lotus.Function;
using B_lotus.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace B_lotus.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        ImageUpload ImageUpload;
        private readonly DBContext _dal;
        public CompanyController(IWebHostEnvironment hostEnvironment, DBContext dal) { 
            _dal = dal;
            _webHostEnvironment = hostEnvironment;
            
            ImageUpload = new ImageUpload();
        }

        public IActionResult Index()
        {
            return View();
        }  
        [HttpPost]
        public IActionResult Index(Company company,string DisplayName)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            if (company.Logo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    company.Logo.CopyTo(memoryStream);
                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 5242880)
                    {
                        //based on the upload file to create Photo instance.
                        //You can also check the database, whether the image exists in the database.
                        
                        //add the photo instance to the list.
                        company.LogoByte = ImageUpload.GetByteArrayFromImage(company.Logo);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                        return View(company);
                    }
                }
                Server Servers = GetServerDetails(company);

                _dal.Companys.Add(company);
               
                User users = new()
                {
                    FirstName = DisplayName,
                    Email = company.Email,
                    Password = GenerateToken(6),
                    LoginId = GenerateLoginId(company.Email),
                    Address = company.Address,
                    Role = "Admin",
                    
                    Contact = company.Mobile_No,
                    LastName = " "
                };
                using (var memoryStream = new MemoryStream())
                {
                    company.Logo.CopyTo(memoryStream);
                    if (memoryStream.Length < 5242880)
                    {
                        //based on the upload file to create Photo instance.
                        //You can also check the database, whether the image exists in the database.
                       
                        //add the photo instance to the list.
                        users.Profile = ImageUpload.GetByteArrayFromImage(company.Logo);

                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                        return View(company);
                    }
                }
                _dal.Users.Add(users);
                _dal.SaveChanges();
                TempData["Message2"] = "LoginId : " + users.LoginId +" Password = "+users.Password;

            }

            TempData["Message"] = "Company Registerd successfully, Please note down LoginId and Password ";
           


            return RedirectToAction("Index","Login");
        } 
        
        public Server GetServerDetails(Company company)
        {

            var server = new Server() {
            
            };

            return server;
        }



        public IActionResult CompanyDetails()
        {
            if (HttpContext.Session.GetString("usersession") != null) {
                var Company = _dal.Companys.FirstOrDefault();
                //code for image retrive (byte to string ) 
                if (Company.LogoByte != null)
                    Company.CompanyProfile = ImageUpload.GetStrigFromByteArray(Company.LogoByte);
                //code for image retrive (byte to string )

                return View(Company);
            }
            return RedirectToAction("Index", "Login");
        }

        public string GenerateLoginId(string email)
        {
            string[] parts = email.Split(new[] { '@' });
            string id = parts[0];
            return id;
        }

        public string GenerateToken(int Length)
        {
            using RNGCryptoServiceProvider cryptRNG = new();
            byte[] tokenBuffer = new byte[Length];
            cryptRNG.GetBytes(tokenBuffer);
            return Convert.ToBase64String(tokenBuffer);
        }
    }

}
