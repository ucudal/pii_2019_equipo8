using System;
using System.Collections.Generic;
using Ignis.Models;

namespace Ignis.Areas.Identity.Data
{
    // Esta clase cumple con el rol del "administrador" de nuestra aplicación
    // Si bien se puede utilizar la propiedad Role de ApplicationUser para determinar
    // las páginas que ve el administrador, decidimos crear la clase Admin para que
    // pueda guardar una lista con instancias de Technician y así pasarsela al cliente
    // cuando quiera crear un contrato
    public class Admin : ApplicationUser
    {
        public ICollection<Consults> Consults { get; set; } = new List<Consults>();

        // Esta lista de técnicos es necesaria para que cuando el cliente quiera
        // crear un contrato, que lo pueda hacer mediante la lista filtrada de
        // técnicos
        public ICollection<Technician> ListaFiltradaTechnicians { get; set; } = new List<Technician>();
    }
}