using System;
using Xunit;
using Ignis.Models;
using Ignis.Areas.Identity.Data;
using Microsoft.Extensions;

namespace Ignis.Areas.Identity.Data
{
    public class UserTests
    {
        [Fact]
        public void TestApplicationUser()
        {
            ApplicationUser appUser = new ApplicationUser();
            appUser.Id ="1234";
            appUser.Name = "Juan Perez";
            appUser.DOB = new DateTime(1988, 12, 11);
            appUser.Role = "Fotografo";
            string actual = string.Format(@"{0} {1} {2} {3}", appUser.Id, appUser.Name, appUser.DOB.ToShortDateString(), appUser.Role);
            string expected = "1234 Juan Perez 12/11/1988 Fotografo";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestClient()
        {
            Client client1 = new Client();
            client1.Projects = 3;
            client1.Id ="1235";
            client1.Name = "Maria Rodriguez";
            client1.DOB = new DateTime(1990, 10, 20);
            client1.Role = "Editor";
            string actual = string.Format(@"{0} {1} {2} {3} {4}", client1.Id, client1.Name, client1.DOB.ToShortDateString(), client1.Role, client1.Projects);
            string expected = "1235 Maria Rodriguez 10/20/1990 Editor 3";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTecnico()
        {
            Tecnico tec1 = new Tecnico();
            tec1.Available = true;
            tec1.AverageRanking = 4;
            tec1.WorkedHours = 40;
            tec1.TotalWorks = 12;
            string actual = string.Format(@"{0} {1} {2} {3}", tec1.Available, tec1.AverageRanking, tec1.WorkedHours, tec1.TotalWorks);
            string expected = "True 4 40 12";
            Assert.Equal(expected, actual);
        }
    }
}
