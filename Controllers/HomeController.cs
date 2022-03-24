using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /HelloWorld/
        private readonly CoffeeService _coffeeService;

        public HomeController(CoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }
        public IActionResult Index()
        {
            var coffee = _coffeeService.Get();
            return View(coffee);
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Add(Coffee coffee)
        {
            if (coffee.Name == null)
            {
                return View();
            }
            _coffeeService.Create(coffee);
            return Redirect("~/Home/Index");
        }
        
        public IActionResult Update(string id)
        {
            var coffee = _coffeeService.Get(id);
            return View(coffee);
        }

        [HttpPost]
        public IActionResult UpdateById(Coffee coffee)
        {
            _coffeeService.Update(coffee.Id, coffee);
            return Redirect("~/Home/Index");
        }
        public IActionResult Delete(string Id)
        {
            if (Id == null)
            {
                return View();
            }
            _coffeeService.Remove(Id);
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult DeleteById(string id)
        {
            _coffeeService.Remove(id);
            return Redirect("~/Home/Index");
        }
    }
}