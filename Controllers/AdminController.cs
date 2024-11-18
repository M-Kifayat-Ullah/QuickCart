using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;
using System.Threading.Tasks.Dataflow;
using static Humanizer.On;

namespace E_Commerce.Controllers
{
    public class AdminController : Controller
    {
        //private (for excess only in admin controller class)
        private MyContex _contex; // for globally access of mycontex class
        private IWebHostEnvironment _env;
        public AdminController(MyContex contex,IWebHostEnvironment env) // passing reference of mycontex
        {
            _contex = contex; 
            _env = env;
            
        }
        public IActionResult Index()
        {
            string admin_session = HttpContext.Session.GetString("Admin_Session");
            if(admin_session!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] // for collecting form value and compare with with database value
        public IActionResult Login( string AdminEmail,string AdminPassword)
        {
           
            
                var row = _contex.tbl_admin.FirstOrDefault(a => a.Admin_Email == AdminEmail);
                if (row != null && row.Admin_password == AdminPassword)
                {
                    HttpContext.Session.SetString("Admin_Session", row.Admin_id.ToString());
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.messege = "incorrect username or password";
                    return View();
                return View();
                }
            }
          
           
                
           
        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Admin_Session");
            return RedirectToAction("Login");
        }
        public IActionResult Profile()
        {
            //for displaying one admin data beacuase multiple admin will working in site
           var adminid= HttpContext.Session.GetString("Admin_Session"); // finding which admin profile
           var row= _contex.tbl_admin.Where(a => a.Admin_id == int.Parse(adminid)).ToList(); // find admin data from admin table in database
            return View(row);
        }
        [HttpPost]
     public IActionResult UpdateProfile(Admin admin)
        {
            _contex.tbl_admin.Update(admin);
            _contex.SaveChanges();
            return RedirectToAction("Profile");
        }
        public IActionResult changeprofileimage(IFormFile admin_image, Admin admin)
        {
            string imagepath= Path.Combine(_env.WebRootPath,"admin_image",admin_image.FileName); // return filename from root folder
            FileStream fs=new FileStream(imagepath, FileMode.Create);
            admin_image.CopyTo(fs);
            admin.Admin_image = admin_image.FileName;
            _contex.SaveChanges();
            return RedirectToAction("Profile");
        }
        public IActionResult fetchCustomer()
        {
            return View(_contex.tbl_Customer.ToList()); // fetch data from database
        }

    }
}
