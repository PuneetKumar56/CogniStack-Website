using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using CogniStack_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
namespace CogniStack_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home - CogniStack";
            return View();
        }

        public IActionResult Services()
        {
            ViewData["Title"] = "Services - CogniStack";
            return View();
        }

        public IActionResult Portfolio()
        {
            ViewData["Title"] = "Portfolio - CogniStack";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About - CogniStack";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact - CogniStack";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendEmail(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(kv => kv.Value.Errors.Count > 0)
                    .ToDictionary(kv => kv.Key,
                                    kv => kv.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );
                return Json(new { success = false, validationErrors = errors });
            }

            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(_configuration["ContactInfo:Email2"]?? "");

                mail.To.Add(_configuration["ContactInfo:Email2"]?? "");

                mail.ReplyToList.Add(new MailAddress(contact.Email));
                mail.Subject = $"New Contact Form Submission from {contact.Name} - Service: {contact.Service}";

                mail.Body = $"Name: {contact.Name}\nEmail: {contact.Email}\nPhone: {contact.Phone}\nService: {contact.Service}\nMessage:  {contact.Message}\nMessageDate: {contact.MessageDate}";

                using SmtpClient smtpClient = new SmtpClient("smtp.gmail.com") {
                   Port = 587,
                   EnableSsl = true,
                   Credentials = new NetworkCredential(_configuration["ContactInfo:Email2"], _configuration["ContactInfo:AppPassword"])
                };
                

                smtpClient.Send(mail);
                return Json(new { success = true, message = "Your message has been sent successfully!" });
            }
            catch (System.Exception ex)
            {
                // For debugging return the error; remove or sanitize in production
                return Json(new { success = false, smtpError = ex.Message });
            }
        }

        public IActionResult Blog()
        {
            ViewData["Title"] = "Insights - CogniStack";
            return View();
        }
    }
}
