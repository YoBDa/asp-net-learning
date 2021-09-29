using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LangFeatures.Models;
using System.Linq;

namespace LangFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();
           
            return View(Product.GetProducts().Select(p =>
            $"{nameof(p.Name)}: {p?.Name}, {nameof(p.Price)}: {p?.Price}"));
        }

    }
}
