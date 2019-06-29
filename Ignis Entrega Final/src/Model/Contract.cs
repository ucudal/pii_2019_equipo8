using System;
using System.Collections.Generic;
using Ignis.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Las clases referentes a Contract van a ser usadas en la 3era entrega del proyecto, ya
//que para esta entrega consideramos como más complejo lo referente al administrador.
namespace Ignis.Models
{
    public class Contract
    {
    public virtual int BaseCost { get; set; }
    public virtual int Time { get; set; }
    public int TotalCost
    {
        get
        {
            return this.BaseCost*this.Time;
        }
    }
    public Client Client { get; set; }
    [Key]
    public string ClientId { get; set; }
    public Technician Technician { get; set; }
    [Key]
    public string TechnicianId { get; set; }

    }
 }