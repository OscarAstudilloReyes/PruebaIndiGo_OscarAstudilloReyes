using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace PruebaTecnicaIndiGO.Model
{
    public class Sale 
    {
        public int Id { get; set; }                
        public DateTime Date { get; set; }        
        public decimal Total { get; set; }        

        public List<SaleItems> Items { get; set; } = new();
    }
}
