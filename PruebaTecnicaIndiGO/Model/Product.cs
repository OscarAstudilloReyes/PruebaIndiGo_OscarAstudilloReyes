using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaIndiGO.Model
{
    public class Product 
    {
        public int Id { get; set; }            
        public string Code { get; set; }        
        public string Name { get; set; }        
        public decimal Cost { get; set; }      
        public int Stock { get; set; }         
        public string Picture { get; set; }  

    }
}
