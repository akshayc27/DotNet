using Ecom_Shopping.DataAccess.Data;
using EcomShopping.DataAccess.Repository.IRepository;
using EcomShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcomShopping.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
