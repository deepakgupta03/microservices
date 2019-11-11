using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChequeBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeBookController : ControllerBase
    {
        ConfigSettings configSettings { get; set; }

        public ChequeBookController(IOptions<ConfigSettings> settings)
        {
           configSettings = settings.Value;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return configSettings.Message;
        }

        /// <summary>
        /// Order a Cheque book for account
        /// </summary>
        /// <param name="accountNo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("order")]
        public string Order(string accountNo)
        {
            return "cheque book ordered successfully";
        }

        /// <summary>
        /// Block Cheque book for account
        /// </summary>
        /// <param name="accountNo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("block")]
        public string Block(string accountNo)
        {
            return "cheque book blocked successfully";
        }
    }
}
