using System;
using Xunit;
using Ignis.Models;
using Ignis.Areas.Identity.Data;
using Microsoft.Extensions.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Ignis.Pages_AdminContracts;

namespace Ignis.Tests
{
    public class ContractTests
    {
        [Fact]
        // Se verifica la creación de un contrato por día
        public async Task Creation_of_contract_by_day()
        {
            // Creo la base de datos "falsa" para iniciar el test
            using (var db = new IdentityContext(Utilities.TestDbContextOptions()))
            {
                // Obtengo los objetos que voy a testear
                db.Initialize();

                ContractByDay expectedContract = new ContractByDay 
                {
                    Time = 3,
                    ClientId = "1",
                    TechnicianId = "2"
                };
                CreateByDayModel createByDayModel = new CreateByDayModel(db);
                createByDayModel.Contract = expectedContract;

                await createByDayModel.OnPostAsync();

                Contract actualContract = await db.Contract.FindAsync("1","2");

                Assert.Equal(expectedContract, actualContract);
            }
        }

        [Fact]
        // Se verifica la creación de un contrato por hora
        public async Task Creation_of_contract_by_Hour()
        {
            // Creo la base de datos "falsa" para iniciar el test. Y uso Utilities
            // para que se borre luego de finalizado el test   
            using (var db = new IdentityContext(Utilities.TestDbContextOptions()))
            {
                // Obtengo los objetos que voy a testear
                db.Initialize();

                // Creo el contrato que voy a guardar en la base de datos
                ContractByHour expectedContract = new ContractByHour 
                {
                    Time = 8,
                    ClientId = "1",
                    TechnicianId = "2"
                };
                CreateByHourModel createByDayModel = new CreateByHourModel(db);
                createByDayModel.Contract = expectedContract;

                await createByDayModel.OnPostAsync();

                Contract actualContract = await db.Contract.FindAsync("1","2");

                Assert.Equal(expectedContract, actualContract);
            }
        }
        [Fact]
        // Se verifica que se agregue un nuevo contrato al usuario
        public async Task Contract_was_added_to_User()
        {
            // Creo la base de datos "falsa" para iniciar el test. Y uso Utilities
            // para que se borre luego de finalizado el test   
            using (var db = new IdentityContext(Utilities.TestDbContextOptions()))
            {
                // Obtengo los objetos que voy a testear
                db.Initialize();

                // Creo el contrato que voy a guardar en la base de datos
                ContractByHour expectedContract = new ContractByHour 
                {
                    Time = 8,
                    ClientId = "1",
                    TechnicianId = "2"
                };
                Technician technician = await db.Technicians.FindAsync("2");
                // Si le agrego un contrato al técnico debe tener uno más
                int expectedContractList = technician.Contracts.Count + 1;

                CreateByHourModel createByDayModel = new CreateByHourModel(db);
                createByDayModel.Contract = expectedContract;

                await createByDayModel.OnPostAsync();

                Contract actualContract = await db.Contract.FindAsync("1","2");
                int actualContractList = actualContract.Technician.Contracts.Count;

                Assert.Equal(expectedContractList, actualContractList);
            }
        }
    }
}