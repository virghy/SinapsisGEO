using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SinapsisWCF
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int Price { get; set; }
    
    }


    public partial class Pedidos
    {
        private static readonly Pedidos _instance = new Pedidos();
        private Pedidos() { } 
       public static Pedidos Instance 
      { 
                get { return _instance; } 
       } 
        public List<Pedido> ProductList 
        { 
               get { return products; } 
         } 
          private List<Pedido> products = new List<Pedido>() 
         { 
                 new Pedido() { ProductId = 1, Name = "Product 1", CategoryName = "Category 1", Price=10}, 
                new Pedido() { ProductId = 1, Name = "Product 2", CategoryName = "Category 2", Price=5}, 
                new Pedido() { ProductId = 1, Name = "Product 3", CategoryName = "Category 3", Price=15}, 
                new Pedido() { ProductId = 1, Name = "Product 4", CategoryName = "Category 1", Price=9} 
         }; 
    }
}