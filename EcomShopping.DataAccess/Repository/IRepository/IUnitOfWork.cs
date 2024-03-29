﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EcomShopping.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        ICompanyRepository Company { get; }


        IApplicationUserRepository ApplicationUser { get; }

        ICoverTypeRepository CoverType { get; }

        IProductRepository Product { get; }

        ISP_Call SP_Call { get; }

        void Save();

    }
}
