using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces
{
  public interface IUserRepository
  {

    Task<User> Authenticate(string userName, string password);

    void Register(string userName, string password);
    Task<bool> UserAlreadyExists(string userName);

  }
}