using System;
using System.Web.Http;
using Newtonsoft.Json;
using ToDoApp.Identity.Application.Account;
using ToDoApp.Identity.Application.Account.Commands;
using ToDoApp.Identity.Application.Account.Representations;

namespace ToDoApp.Identity.Ports.Resources
{
    /// <summary>
    /// API interface for Identity & Access related requests
    /// </summary>
    [RoutePrefix("v1/account")]
    public class AccountController : ApiController
    {
        private IAccountApplicationService _accountApplicationService;
        
        public AccountController(IAccountApplicationService accountApplicationService)
        {
            _accountApplicationService = accountApplicationService;
        }

        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register([FromBody] Object userObject)
        {
            try
            {
                if (userObject != null)
                {
                    var jsonString = userObject.ToString();
                    var createUserCommand = JsonConvert.DeserializeObject<CreateUserCommand>(jsonString);

                    if (createUserCommand != null)
                    {
                        string identityResult = _accountApplicationService.Register(createUserCommand);
                        if (!string.IsNullOrWhiteSpace(identityResult))
                        {
                            return Ok(true);
                        }
                        else
                        {
                            return BadRequest("Could not register user");
                        }
                    }
                    else
                    {
                        return BadRequest("User data not in expected format");
                    }
                }
                else
                {
                    return BadRequest("No user data received");
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("get-user")]
        [HttpGet]
        public IHttpActionResult GetUser(string email)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    UserRepresentation user = _accountApplicationService.GetUserByEmail(email);
                    return Ok(user);
                }
                else
                {
                    return BadRequest("No email provided to GetUser");
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }
    }
}
