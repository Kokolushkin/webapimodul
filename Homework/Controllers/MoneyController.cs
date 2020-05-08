using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController
    {
        private IUserService _service;
        public MoneyController(IUserService service)
        {
            _service = service;
        }

        [HttpPut("topup")]
        public IActionResult TopUpAccount([FromBody] UserCredentials user)
        {
            User accountTo = _service.GetUser(user.ToAccount);

            if(accountTo != null)
            {
                _service.TopUpAccount(accountTo, user.HowMuch);

                var response = new
                {
                    result = "Пополнение успешно"
                };

                return new OkObjectResult(response);
            }
            else
            {
                var errorAccountNumber = new
                {
                    error = "Вы ввели неправильный номер счета"
                };

                return new BadRequestObjectResult(errorAccountNumber);
            }
        }

        [HttpPut("transfer")]
        public IActionResult Transfer([FromBody] UserCredentials user)
        {
            User accountFrom = _service.GetUser(user.FromAccount);
            User accountTo = _service.GetUser(user.ToAccount);

            if (accountFrom != null && accountTo != null)
            {
                if (_service.Transfer(accountFrom, accountTo, user.HowMuch))
                {
                    var response = new
                    {
                        result = "Успешно"
                    };

                    return new OkObjectResult(response);
                }
                else
                {
                    var errorTransfer = new
                    {
                        error = "Недостаточно средств"
                    };

                    return new BadRequestObjectResult(errorTransfer);
                }
            }
            else
            {
                var errorAccountNumber = new
                {
                    error = "Вы ввели неправильный номер счета"
                };

                return new BadRequestObjectResult(errorAccountNumber);
            }
        }
    }
}