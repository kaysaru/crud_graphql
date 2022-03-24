using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeService _coffeeService;

        public CoffeeController(CoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet]
        public ActionResult<List<Coffee>> Get()
        {
            return _coffeeService.Get();
        }
            

        [HttpGet("{id:length(24)}", Name = "GetCoffee")]
        public ActionResult<Coffee> Get(string id)
        {
            var coffee = _coffeeService.Get(id);

            if (coffee == null)
            {
                return NotFound();
            }

            return coffee;
        }

        [HttpPost]
        public ActionResult<Coffee> Create(Coffee coffee)
        {
            _coffeeService.Create(coffee);

            return CreatedAtRoute("GetCoffee", new { id = coffee.Id }, coffee);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Coffee coffeeIn)
        {
            var coffee = _coffeeService.Get(id);

            if (coffee == null)
            {
                return NotFound();
            }

            _coffeeService.Update(id, coffeeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var coffee = _coffeeService.Get(id);

            if (coffee == null)
            {
                return NotFound();
            }

            _coffeeService.Remove(id);

            return NoContent();
        }
    }
}