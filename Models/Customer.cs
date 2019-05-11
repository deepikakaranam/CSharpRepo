using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Customer
    {
       [Key]
       public int CustomerId{get; set;}
       public string CustomerName{get; set;}
       public DateTime CreatedDate{get; set;}=DateTime.Now;
       public List<Product> OrderedProducts {get; set;}
       public List<Order> Ordersmade{get; set;}
    }
    public class Product
    {
        [Key]
        public int ProductId{get; set;}
        public string ProductName{get; set;}
        public string Description {get; set;}
        public int Quantity {get; set;}
        
        
        public List<Order> OrdersofProduct {get; set;}
    }
    public class Order
    {
        [Key]
        public int OrderId {get; set;}
        public int CustomerId {get; set;}
        public int ProductId {get; set;}
        public int Quantity{get; set;}
        public Customer CustomerOrdered {get; set;}
        public Product OrderedProduct {get; set;}
    }
}