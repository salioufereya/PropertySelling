using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using WebApi.Interfaces;

namespace WebApi.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;
        public CityRepository(DataContext dc){
            this.dc = dc;
        }
        public void AddCity(City city)
        {
           dc.Cities.AddAsync(city);
        }

      public  void DeleteCity(int CityId)
        {
            var city = dc.Cities.Find(CityId);
            dc.Cities.Remove(city);
        }

       public  async Task<City>  FindCity(int id)
        {
           return await dc.Cities.FindAsync(id);
        }

        async Task<IEnumerable<City>> ICityRepository.GetCitiesAsync()
        {
           return await dc.Cities.ToListAsync();
        }

     

       
    }
}