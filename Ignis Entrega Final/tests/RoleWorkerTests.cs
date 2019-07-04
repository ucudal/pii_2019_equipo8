using System;
using Xunit;
using Ignis.Models;
using Ignis.Areas.Identity.Data;
using Microsoft.Extensions;
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
using Ignis.Pages.AssignRoles;

namespace Ignis.Tests
{
    public class RoleWorkerTests
    {
        [Fact]
        //Se verifica la creacion de un RoleWorker
        public void TestRoleWorker()
        {
            RoleWorker rw = new RoleWorker();
            rw.ID = 1111;
            rw.Level = Level.Avanzado;
            rw.Title = "Sonidista";
            string actual = string.Format(@"{0} {1} {2}", rw.ID, rw.Level, rw.Title);
            string expected = "1111 Avanzado Sonidista";
            Assert.Equal(expected, actual);
        }
    }   
}