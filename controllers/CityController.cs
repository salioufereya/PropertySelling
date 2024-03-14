using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Dtos;
using AutoMapper;
using Models;
using WebApi.controllers;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    
  //[Authorize]
    public class CityController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCities()
        
        {
           //throw new UnauthorizedAccessException();
            var cities = await _uow.CityRepository.GetCitiesAsync();
            var CitiesDto = _mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(CitiesDto);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
           var city =_mapper.Map<City>(cityDto);
           city.LastUpdatedBy=1;
           city.LastUpdateOn=DateTime.Now;
            _uow.CityRepository.AddCity(city);
            await _uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id,CityDto cityDto)
        {
            if(id!=cityDto.Id){
                return BadRequest("Update not allowed");
            }
           var cityFromDb = await _uow.CityRepository.FindCity(id);
           if(cityFromDb==null){
            return BadRequest("Update not allowed");
           }
           cityFromDb.LastUpdatedBy=1;
           cityFromDb.LastUpdateOn=DateTime.Now;
          _mapper.Map(cityDto,cityFromDb);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            _uow.CityRepository.DeleteCity(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}
