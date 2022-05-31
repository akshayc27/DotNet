using EcomShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcomShopping.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void update(CoverType covertype);
    }
}
