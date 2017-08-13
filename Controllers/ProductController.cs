﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleProduct.Models;

namespace SampleProduct.Controllers
{
    // return  data in xml 
    [Produces("application/xml")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        //here we are creating sample in-memory , but actually it will be coming  from the database
        public static List<Product> prd = new List<Product>(new[] {
               new Product(){ Id=1, Name="Mazda3", Quantity =3},
               new Product(){ Id=2, Name="Ford Focus", Quantity =53},
               new Product(){ Id=3, Name="Audi X5", Quantity =23},
               new Product(){ Id=4, Name="Maruti Suzuki Star R", Quantity =32},
               new Product(){ Id=5, Name="Hyundai", Quantity =32},
               new Product(){ Id=6, Name="Porsche", Quantity =30},
               new Product(){ Id=7, Name="Honda civic 2017", Quantity =390},

            });
   
        [HttpGet]
        public List<Product> GetAllProduct()
        {
            return prd;
        }

       [HttpGet("{id}")]
       public IActionResult GetById(int id)
        {
          var product =prd.SingleOrDefault(p => p.Id == id);
            try
            {
                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(product);
                }

            }

            catch(Exception e)
            {
                Console.WriteLine("Exceptions in the code" + e.Message);
                return null;
            }
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
              prd.Add(product);

             return CreatedAtAction(nameof(GetAllProduct),
             new { id = product.Id }, product);
        }
        
    }
}
