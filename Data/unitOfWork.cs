using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using WebApi.Data.Repo;
using WebApi.Interfaces;

namespace WebApi.Data
{
    public class unitOfWork : IUnitOfWork
    {

        private readonly DataContext dc;

        public unitOfWork(DataContext dc){
            this.dc = dc;
        }
        public ICityRepository CityRepository => new CityRepository(dc);

         public IUserRepository UserRepository => new UserRepository(dc);

        public  async Task<bool> SaveAsync()
        {
            return  await dc.SaveChangesAsync() > 0;
        }
    }
}