﻿//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace iShop.Infras.API.APIs
//{
//    [Route("/api/[controller]")]
//    public class ShippingsController: BaseController
//    {
//        private readonly IMapper _mapper;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly ILogger<ShippingsController> _logger;

//        public ShippingsController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ShippingsController> logger)
//        {
//            _mapper = mapper;
//            _unitOfWork = unitOfWork;
//            _logger = logger;
//        }


//        // GET
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var shipping = await _unitOfWork.ShippingRepository.GetShippings();

//            var shippingResource = _mapper.Map<IEnumerable<Shipping>, IEnumerable<ShippingDto>>(shipping);

//            return Ok(shippingResource);
//        }


//        // GET
//        [HttpGet("{id}", Name = ApplicationConstants.ControllerName.Shipping)]
//        public async Task<IActionResult> Get(string id)
//        {
//            bool isValid = Guid.TryParse(id, out var shippingId);

//            if (!isValid)
//                return InvalidId(id);

//            var shipping = await _unitOfWork.ShippingRepository.GetShipping(shippingId);

//            if (shipping == null)
//                return NullOrEmpty();

//            var shippingResource = _mapper.Map<Shipping, ShippingDto>(shipping);

//            return Ok(shippingResource);
//        }



//        // POST
       
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] ShippingDto shippingResource)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var shipping = _mapper.Map<ShippingDto, Shipping>(shippingResource);

//            await _unitOfWork.ShippingRepository.AddAsync(shipping);

//            // if something happens and the new item can not be saved, return the error
//            if (!await _unitOfWork.CompleteAsync())
//            {
//                //_logger.LogMessage(LoggingEvents.SavedFail, ApplicationConstants.ControllerName.Shipping, shipping.Id);
//                _logger.LogInformation("");
//                return FailedToSave(shipping.Id);
//            }

//            shipping = await _unitOfWork.ShippingRepository.GetShipping(shipping.Id);

//            var result = _mapper.Map<Shipping, ShippingDto>(shipping);

//            //_logger.LogMessage(LoggingEvents.Created, ApplicationConstants.ControllerName.Shipping, shipping.Id);
//            _logger.LogInformation("");
//            return CreatedAtRoute(ApplicationConstants.ControllerName.Shipping, new { id = shipping.Id }, result);
//        }

//        // DELETE
//        [Authorize(Roles = ApplicationConstants.RoleName.SuperUser)]
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(string id)
//        {
//            bool isValid = Guid.TryParse(id, out var shippingId);

//            if (!isValid)
//                return InvalidId(id);

//            var shipping = await _unitOfWork.ShippingRepository.GetShipping(shippingId);

//            if (shipping == null)
//                return NullOrEmpty();

//            _unitOfWork.ShippingRepository.Remove(shipping);
//            if (!await _unitOfWork.CompleteAsync())
//            {
//                //_logger.LogMessage(LoggingEvents.Fail, ApplicationConstants.ControllerName.Shipping, shipping.Id);
//                _logger.LogInformation("");
//                return FailedToSave(shipping.Id);
//            }

//            //_logger.LogMessage(LoggingEvents.Deleted, ApplicationConstants.ControllerName.Shipping, shipping.Id);
//            _logger.LogInformation("");
//            return NoContent();
//        }



//        // PUT
//        [Authorize(Policy = ApplicationConstants.PolicyName.SuperUsers)]
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(string id, [FromBody] ShippingDto shippingResource)
//        {
//            bool isValid = Guid.TryParse(id, out var shippingId);

//            if (!isValid)
//                return InvalidId(id);

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var shipping = await _unitOfWork.ShippingRepository.GetShipping(shippingId);

//            if (shipping == null)
//                return NullOrEmpty();

//            _mapper.Map(shippingResource, shipping);

//            if (!await _unitOfWork.CompleteAsync())
//            {
//                //_logger.LogMessage(LoggingEvents.SavedFail, ApplicationConstants.ControllerName.Shipping, shipping.Id);
//                _logger.LogInformation("");
//                return FailedToSave(shipping.Id);
//            }

//            shipping = await _unitOfWork.ShippingRepository.GetShipping(shipping.Id);

//            var result = _mapper.Map<Shipping, ShippingDto>(shipping);
//            //_logger.LogMessage(LoggingEvents.Updated, ApplicationConstants.ControllerName.Shipping, shipping.Id);
//            _logger.LogInformation("");
//            return Ok(result);
//        }
//    }
//}
