using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvite.Models;
using System.Linq;

namespace PartyInvite.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int Hour = DateTime.Now.Hour;
            ViewBag.Greeting = Hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult ListResponses() => View(Repository.Responses.Where(r => r.WillAttend == true));
    }
}