using AutoMapper;
using BSynchro_RJP.DTOs;
using BSynchro_RJP_Core.Models;
using BSynchro_RJP_Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSynchro_RJP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, ITransactionService transactionService, ICustomerService customerService, IMapper mapper)
        {
            _accountService = accountService;
            _transactionService = transactionService;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAccount(int customerId, double intialCredit)
        {
            try
            {
                var account = await _accountService.CreateAccount(customerId);
                if(intialCredit > 0)
                {
                    var transactionResult = await _transactionService.CreateTransaction(account.AccountId, intialCredit);
                    if (transactionResult)
                    {
                        return Ok("Account Created and Transaction Succeeded!");
                    }
                    return Ok("Account Created and Transaction Failed!");
                }
                return Ok("Account Created!");
            }catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("UserInfo/{customerId}")]
        public async Task<ActionResult<UserInfo>> getUserInfo(int customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomer(customerId);

                if (customer == null)
                {
                    return NotFound();
                }

                var customerInfo = _mapper.Map<UserInfo>(customer);

                return Ok(customerInfo);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred: {ex.Message}");
            }
        }
    }
}
