using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ConfigSettings configSettings { get; set; }

        public TransactionController(IOptions<ConfigSettings> settings)
        {
            configSettings = settings.Value;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return configSettings.Message;
        }

        /// <summary>
        /// Withdraw amount from account
        /// </summary>
        /// <param name="accountNo">The account no</param>
        /// <param name="amount">The amount to withdraw</param>
        /// <returns></returns>
        [HttpPost]
        [Route("withdraw")]
        public string WithDraw(string accountNo, int amount)
        {
            return accountNo + "debited with amount " + amount;
        }

        /// <summary>
        /// Deposits amount to a account no
        /// </summary>
        /// <param name="accountNo">The account no</param>
        /// <param name="amount">The amount to deposit</param>
        /// <returns>Message</returns>
        [HttpPost]
        [Route("deposit")]
        public string Deposit(string accountNo, int amount)
        {
            return accountNo + "credited with amount " + amount;
        }

        /// <summary>
        /// Transfer amount from one account to another
        /// </summary>
        /// <param name="toAccountNo">To account no</param>
        /// <param name="fromAccountNo">From account no</param>
        /// <param name="amount">The amount</param>
        /// <returns>Message</returns>
        [HttpPost]
        [Route("transfer")]
        public string Transfer(string toAccountNo, string fromAccountNo, int amount)
        {
            return amount + " transferred successfully from  " + fromAccountNo + " to " + toAccountNo;
        }

        /// <summary>
        /// Get the transaction summary of account
        /// </summary>
        /// <param name="accountNo">The account no</param>
        /// <returns>Message</returns>
        [HttpGet]
        [Route("accountSummary")]
        public string AccountSummary(string accountNo)
        {
            return "account transaction summary";
        }

    }
}
