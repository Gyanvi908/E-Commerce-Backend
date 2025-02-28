﻿using ecom.Data;
using ecom.Entities;
using ecom.Extensions;
using ecom.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ecom.Controllers
{
    
    public class ProductsController : BaseApiController
    {

        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
                _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery]ProductParams productParams)
        {
            var query =   _context.Products
                .Sort(productParams.OrderBy)
                .Search(productParams.SearchTerm)
                .Filter(productParams.Brands, productParams.Types)
                .AsQueryable();


            var products = await PagedList<Product>.ToPagedList(query, productParams.PageNumber, productParams.PageSize);
            Response.AddPaginationHeader(products.MetaData);
            return products;

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("Product Id Not Found!");
            }
            return Ok(product);
        }

        [HttpGet("filters")]

        public async Task<IActionResult> GetFilters()
        {
            var brands = await _context.Products.Select(p => p.Brand).Distinct().ToListAsync();
            var types = await _context.Products.Select(p => p.Type).Distinct().ToListAsync();

            return Ok(new {brands, types });

        }
    }
}
