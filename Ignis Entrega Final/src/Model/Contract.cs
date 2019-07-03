using System;
using System.Collections.Generic;
using Ignis.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Esta es la clase Contract la cual vincula Technician con Client, ya que Contract
// conoce a Client y Technician, y ApplicationUser (clase base de Client y Technician)
// tiene una lista de Contracts.
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