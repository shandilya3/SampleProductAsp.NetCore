using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProduct.Models
{
    public class Product
    {
    public  int Id { get; set; }

     [Required]
     public string Name { get; set; }

     public int Quantity { get; set; }

    public  float Price { get; set; }

    public DateTime ManufDate { get; set; }
    }
}
