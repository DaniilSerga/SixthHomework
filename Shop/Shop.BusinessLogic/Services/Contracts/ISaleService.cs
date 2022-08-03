﻿using Shop.Common.Models;

namespace Shop.BusinessLogic.Services.Contracts
{
    public interface ISaleService
    {
        List<SaleModel> GetAllSales();
        SaleModel GetSale(int id);
        void Create(SaleModel sale);
        void Delete(int id);
        void Update(int id, SaleModel sale);
    }
}
