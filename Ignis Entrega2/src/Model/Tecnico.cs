using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

//Tecnico es el usuario que tiene el rol del "técnico" en la aplicación que pidió el Centro Ignis.
//Por lo tanto Client Tecnico ApplicationUser para que sea un usuario como tal y además definimos las metodos
//ShowProperties y NamesOfProperties para poder mostrar las propiedades ya que son distintas a las de Tecnico.
namespace Ignis.Areas.Identity.Data
{
    public class Tecnico : Ignis.Areas.Identity.Data.ApplicationUser
    {
        public int AverageRanking{get;set;}
        public bool Available{get; set;}
        public int WorkedHours{get; set;}
        public int TotalWorks{get; set;}

        public override List<String> ShowProperties()
        {
        List<String> result = new List<String>();
             
        result.Add(this.Name.ToString());
        result.Add(this.AverageRanking.ToString());
        result.Add(this.Available.ToString());
        result.Add(this.WorkedHours.ToString());
        result.Add(this.TotalWorks.ToString());
        return result;
        }
        public override List<String> NamesOfProperties()
        {
        List<String> result = new List<String>();
             
        result.Add("Name");
        result.Add("AverageRanking");
        result.Add("Available");
        result.Add("WorkedHours");
        result.Add("TotalWorks");
        return result;
        }
        
 
    }
}