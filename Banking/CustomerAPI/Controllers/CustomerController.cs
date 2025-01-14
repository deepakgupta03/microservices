using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ConfigSettings configSettings { get; set; }

        public CustomerController(IOptions<ConfigSettings> settings)
        {
          configSettings = settings.Value;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return configSettings.Message;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Customer Details";
        }
    
        /// <summary>
        /// creates the customer
        /// </summary>
        /// <param name="customerDetails">The customer details</param>
        /// <returns>Message</returns>
        [HttpPost]
        public string Post([FromBody] string  customerDetails)
        {
            return "New Customer Registered";
        }

        /// <summary>
        /// Updates the customer details
        /// </summary>
        /// <param name="id">The customer id</param>
        /// <param name="customerDetails">The customer details</param>
        /// <returns>Message</returns>
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string customerDetails)
        {
            return "Customer Details Updated";
        }

    }
}
