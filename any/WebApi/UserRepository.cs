using Project.SQLDataAccess;
using Project.SQLDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi
{
    public class UserRepository
    {
        private readonly ProjectDbContext _context = new ProjectDbContext();
        public Account Get(string login, string password)
        {
            return _context.Users
                .Where(a => a.Login == login
                     && a.Password == password).FirstOrDefault();
        }
    }
}