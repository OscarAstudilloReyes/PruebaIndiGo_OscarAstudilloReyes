using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace PruebaTecnicaIndiGO.Model
{
    public class SaleItems 
    {
        public int Id { get; set; }               
        public int SaleId { get; set; }         
        public int ProductId { get; set; }      
        public int Quantity { get; set; }        
        public decimal TotalValue { get; set; }   

        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}
