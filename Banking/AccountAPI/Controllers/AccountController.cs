using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        ConfigSettings configSettings { get; set; }

        public AccountController(IOptions<ConfigSettings> settings)
        {
            configSettings = settings.Value;
            
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return configSettings.Message;
        }

        /// <summary>
        /// Creates a new accounerete
        /// </summary>
        /// <param name="accountDetails">The account details</param>
        /// <returns>Message</returns>
        [HttpPost]
        public string Post([FromBody] string accountDetails)
        {
            return "New Accoaunt Created with account no:= " + Guid.NewGuid();
        }

        

        [HttpPut("{accountNo}")]
        public string  Put(int accountNo, [FromBody] string accountDetails)
        {
            return "Account Details Updated....";
        }

        /// <summary>
        /// Transer account to another branch
        /// </summary>
        /// <param name="accountNo">The account no</param>
        /// <param name="branchCode">The branch code</param>
        /// <returns>The message</returns>
        [HttpPost]
        [Route("transfer")]
        public string Transfer(string accountNo, string branchCode)
        {
            return accountNo + "successfully transferred to " + branchCode + "branch";
        }

        /// <summary>
        /// Return accounts linked with userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The list of account numbers</returns>
        [HttpPost]
        [Route("useraccounts")]
        public List<string> UserAccounts(string userId)
        {
            return new List<string>() { Guid.NewGuid().ToString() };
        }
    }
}
