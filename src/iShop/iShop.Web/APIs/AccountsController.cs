﻿//using System.Security.Claims;
//using System.Threading.Tasks;
//using iShop.Domain.Entities.Entities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace iShop.Infras.API.APIs
//{
//    /// <summary>
//    /// This Controller is reposible for everything relative to Accounts
//    /// </summary>
//    [Authorize]
//    [Route("/api/[controller]")]
//    public class AccountsController : Microsoft.AspNetCore.Mvc.Controller
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly ILogger<AccountsController> _logger;
//        private readonly IMapper _mapper;

//        public AccountsController(
//            UserManager<ApplicationUser> userManager,
//            ILogger<AccountsController> logger, IMapper mapper)
//        {
//            _userManager = userManager;
//            _logger = logger;
//            _mapper = mapper;
//        }

//        /// <summary>
//        /// API endpoint for registering a new User
//        /// </summary>
//        /// <param name="model">Contain info to create a new User</param>
//        [HttpPost("register")]
//        [AllowAnonymous]
//        public async Task<IActionResult> Register([FromBody]RegisterDto model)
//        {
//            // Validate input fields
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            // Mapping the input to model class
//            var currentUser = _mapper.Map<RegisterDto, ApplicationUser>(model);

//            // In this application, UserName itseft is Email
//            currentUser.UserName = model.Email;

//            // Create a new User by User's info and password
//            var createResult = await _userManager.CreateAsync(currentUser, model.Password);

//            // Add roles to the User 
//            var roleResult = await _userManager.AddToRoleAsync(currentUser, ApplicationConstants.RoleName.User);

//            var claimResult = await _userManager.AddClaimAsync(currentUser, new Claim(ApplicationConstants.ClaimName.User, "true"));
//            // Add claims as well


//            // Everything is fine, return 200 and log 
//            if (createResult.Succeeded && roleResult.Succeeded && claimResult.Succeeded)
//            {
//                _logger.LogInformation(LoggingEvents.Success, "User with email " + model.Email + " created");
//                return Ok();
//            }

//            // Failed at some point, return 400 and the errors
//            return BadRequest(createResult);
//        }
//    }
//}

