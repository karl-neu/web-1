using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : Controller
    {
        business.Domains.Dog domain;

        public DogController(IConfiguration configuration)
        {
            this.domain = new business.Domains.Dog(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dogs = this.domain.Get();
            return Ok(dogs);
        }

        [HttpPost]
        public IActionResult Post(business.ViewModels.Dog dog)
        {
            if (ModelState.IsValid)
            {
                domain.Add(dog);
                return Ok(dog);
            }
            return BadRequest(ModelState);
        }
    }
}
