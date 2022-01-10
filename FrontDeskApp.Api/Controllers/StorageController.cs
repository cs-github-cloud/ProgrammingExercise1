using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FrontDeskApp.Api.Resources;
using FrontDeskApp.Api.Validators;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Core.Services;
using FrontDeskApp.Core.Extensions;

using AutoMapper;


namespace FrontDeskApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {

        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public StorageController(IStorageService storageService, IMapper mapper)
        {
            this._mapper = mapper;
            this._storageService = storageService;
        }

        [HttpGet("{facilityId}/{storageType}")]
        public async Task<ActionResult<string>> GetStorageCount(int facilityId, StorageTypes storageType)
        {
            var storageCount = await _storageService.GetStorageCount(facilityId, storageType);

            if (storageCount > 0)
                return Ok(string.Concat(storageCount, " storage/s remaining."));
            else
                return Ok("Not enough space. Please go to other facility.");

        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<string>> GetCustomerStatus(int customerId)
        {
            var storage = await _storageService.GetWithStorageByCustomerId(customerId);

            if (storage != null)
            {
                return storage.StorageStatus.Description();
            }
            else
            {
                return string.Empty;
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<StorageResource>> CreateStorage([FromBody] SaveStorageResource saveStorageResource)
        {
            var storageToCreate = _mapper.Map<SaveStorageResource, Storage>(saveStorageResource);

            var newStorage = await _storageService.CreateStorage(storageToCreate);

            var storage = await _storageService.GetStorageById(newStorage.StorageId);

            var storageResource = _mapper.Map<Storage, StorageResource>(storage);

            return Ok(storageResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StorageResource>> UpdateStorage(int id)
        {

            var storageToBeUpdate = await _storageService.GetStorageById(id);

            if (storageToBeUpdate == null)
                return NotFound();

            await _storageService.UpdateStorage(storageToBeUpdate);

            var updatedStorage = await _storageService.GetStorageById(id);
            var updatedStorageResource = _mapper.Map<Storage, StorageResource>(updatedStorage);

            return Ok(updatedStorageResource);
        }
    }
}
