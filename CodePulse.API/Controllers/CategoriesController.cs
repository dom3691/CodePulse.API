﻿using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        //
        [HttpPost]
        public async Task<IActionResult> CreatCategory(CreateCategoryRequestDto request)
        {
            //Map DTo to Domain Model

            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await categoryRepository.CreateAsync(category);
            //Map From Domain Model to DTo

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            return Ok(response);
        }
    }
}
