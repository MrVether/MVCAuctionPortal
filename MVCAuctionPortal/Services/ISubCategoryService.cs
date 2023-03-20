﻿using AuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services;

public interface ISubCategoryService
{
    IEnumerable<SubCategory> GetAllSubCategories(int id);
    SubCategory GetSubCategoryById(int id);
    int Create(SubCategory subCategory);
    void Update(SubCategory dto);
    void Delete(int id);
}