﻿//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace iShop.Infras.API.APIs
//{
//    [Route("/api/[controller]")]
//    public class ShoppingCartsController : BaseController
//    {
//        private readonly IMapper _mapper;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly ILogger<ShoppingCartsController> _logger;

//        public ShoppingCartsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ShoppingCartsController> logger)
//        {
//            _unitOfWork = unitOfWork;
//            _logger = logger;
//            _mapper = mapper;
//        }

//        // GET
//        [HttpGet("{id}", Name =  ApplicationConstants.ControllerName.ShoppingCart)]
//        public async Task<IActionResult> Get(string id)
//        {
//            bool isValid = Guid.TryParse(id, out var shoppingCartId);
//            if (!isValid)
//                return InvalidId(id);

//            var shoppingCart = await _unitOfWork.ShoppingCartRepository.GetShoppingCart(shoppingCartId);

//            if (shoppingCart == null)
//                return NotFound(shoppingCartId);

//            var shoppingCartDto = _mapper.Map<ShoppingCart, ShoppingCartDto>(shoppingCart);

//            return Ok(shoppingCartDto);
//        }

//        // GET
//        [Authorize(Roles = ApplicationConstants.PolicyName.SuperUsers)]
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var shoppingCarts = await _unitOfWork.ShoppingCartRepository.GetShoppingCarts();

//            var shoppingCartDto =
//                _mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartDto>>(shoppingCarts);

//            return Ok(shoppingCartDto);
//        }


//        // GET
//        [HttpGet("user/{id}")]
//        public async Task<IActionResult> GetUserShoppingCarts(string id)
//        {
//            bool isValid = Guid.TryParse(id, out var userId);
//            if (!isValid)
//                return InvalidId(id);

//            if (userId != User.GetUserId())
//                return UnAuthorized();

//            var shoppingCarts = await _unitOfWork.ShoppingCartRepository.GetUserShoppingCarts(userId);

//            var shoppingCartDto =
//                _mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartDto>>(shoppingCarts);

//            return Ok(shoppingCartDto);
//        }

//        // POST
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] SavedShoppingCartDto shoppingCartDto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            // do not need to check for duplication in here
//            var shoppingCart = _mapper.Map<SavedShoppingCartDto, ShoppingCart>(shoppingCartDto);

//            await _unitOfWork.ShoppingCartRepository.AddAsync(shoppingCart);

//            if (!await _unitOfWork.CompleteAsync())
//            {
//                //_logger.LogMessage(LoggingEvents.SavedFail,  ApplicationConstants.ControllerName.ShoppingCart, shoppingCart.Id);
//                _logger.LogInformation("");

//                return FailedToSave(shoppingCart.Id);
//            }

//            shoppingCart = await _unitOfWork.ShoppingCartRepository.GetShoppingCart(shoppingCart.Id);

//            var result = (_mapper.Map<ShoppingCart, ShoppingCartDto>(shoppingCart));

//            //_logger.LogMessage(LoggingEvents.Created,  ApplicationConstants.ControllerName.Product, shoppingCart.Id);
//            _logger.LogInformation("");


//            return CreatedAtRoute( ApplicationConstants.ControllerName.ShoppingCart, new { id = shoppingCart.Id }, result);
//        }

//        //PUT
//       [HttpPut("{id}")]
//       [Authorize]
//         public async Task<IActionResult> Update(string id, [FromBody]SavedShoppingCartDto ShoppingCartDto)
//        {
//            bool isValid = Guid.TryParse(id, out var shoppingCartId);
//            if (!isValid)
//                return InvalidId(id);

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var shoppingCart = await _unitOfWork.ShoppingCartRepository.GetShoppingCart(shoppingCartId);

//            if (shoppingCart == null)
//                return NotFound(shoppingCartId);

//            _mapper.Map(ShoppingCartDto, shoppingCart);

//            if (!await _unitOfWork.CompleteAsync())
//            {
//                //_logger.LogMessage(LoggingEvents.SavedFail,  ApplicationConstants.ControllerName.ShoppingCart, shoppingCart.Id);
//                _logger.LogInformation("");

//                return FailedToSave(shoppingCart.Id);
//            }

//            shoppingCart = await _unitOfWork.ShoppingCartRepository.GetShoppingCart(shoppingCart.Id);

//            var result = _mapper.Map<ShoppingCart, SavedShoppingCartDto>(shoppingCart);

//            //_logger.LogMessage(LoggingEvents.Updated, ApplicationConstants.ControllerName.ShoppingCart, shoppingCart.Id);
//            _logger.LogInformation("");


//            return Ok(result);
//        }


//        // DELETE
//        [HttpDelete("{id}")]     
//        public async Task<IActionResult> Delete(string id)
//        {
//            bool isValid = Guid.TryParse(id, out var shoppingCartId);
//            if (!isValid)
//                return InvalidId(id);

//            var shoppingCart = await _unitOfWork.ShoppingCartRepository.GetShoppingCart(shoppingCartId, false);

//            if (shoppingCart == null)
//                return NotFound(shoppingCartId);

//            if (shoppingCart.UserId != User.GetUserId())
//                return UnAuthorized();

//            _unitOfWork.ShoppingCartRepository.Remove(shoppingCart);
//            if (!await _unitOfWork.CompleteAsync())
//            {
//                //_logger.LogMessage(LoggingEvents.SavedFail,  ApplicationConstants.ControllerName.ShoppingCart, shoppingCart.Id);
//                _logger.LogInformation("");

//                return FailedToSave(shoppingCart.Id);
//            }

//            //_logger.LogMessage(LoggingEvents.Deleted,  ApplicationConstants.ControllerName.ShoppingCart, shoppingCart.Id);
//            _logger.LogInformation("");

//            return NoContent();
//        }
//    }
//}