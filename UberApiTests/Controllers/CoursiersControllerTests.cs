using Microsoft.VisualStudio.TestTools.UnitTesting;
using UberApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberApi.Models.Repository;
using UberApi.Models.EntityFramework;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace UberApi.Controllers.Tests
{
    [TestClass()]
    public class CoursiersControllerTests
    {

        private S221UberContext _context;
        private CoursiersController _controller;
        private IDataRepository<Coursier> _coursiersRepository;
        private Mock<IDataRepository<Coursier>> _mockRepository;


        [TestMethod()]
        public void GetCoursierById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {

            Coursier coursier = new Coursier
            {
                IdCoursier = 1,
                IdEntreprise = 1,
                IdAdresse = 1,
                GenreUser = "Homme",
                NomUser = "Durant",
                PrenomUser = "Julien",
                DateNaissance = DateOnly.Parse("1988-04-25"),
                Telephone = "0601010101",
                EmailUser = "julien.durant@example.com",
                MotDePasseUser = "hasedpassword123",
                NumeroCarteVtc = "123456789012",
                Iban = "FR7630006000011234567890189",
                DateDebutActivite = DateOnly.Parse("2023-01-15"),
                NoteMoyenne = 4.5m,
                Courses = [],
                Entretiens = [],
                Horaires = [],
                IdAdresseNavigation = null,
                IdEntrepriseNavigation = null,
                ReglementSalaires = [],
                Vehicules = []
            };
            _mockRepository = new Mock<IDataRepository<Coursier>>();
            _mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(coursier);
            _controller = new CoursiersController(_mockRepository.Object);
            // Act
            var actionResult = _controller.GetCoursierAsync(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(coursier, actionResult.Value as Coursier);
        }

        [TestMethod()]
        public void GetCoursierById_NotExistingIdPassed_ReturnsRightItem_AvecMoq()
        {

            _mockRepository = new Mock<IDataRepository<Coursier>>();
            _controller = new CoursiersController(_mockRepository.Object);
            // Act
            var actionResult = _controller.GetCoursierAsync(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCoursierByEmail_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            Coursier coursier = new Coursier
            {
                IdCoursier = 1,
                IdEntreprise = 1,
                IdAdresse = 1,
                GenreUser = "Homme",
                NomUser = "Durant",
                PrenomUser = "Julien",
                DateNaissance = DateOnly.Parse("1988-04-25"),
                Telephone = "0601010101",
                EmailUser = "julien.durant@example.com",
                MotDePasseUser = "hasedpassword123",
                NumeroCarteVtc = "123456789012",
                Iban = "FR7630006000011234567890189",
                DateDebutActivite = DateOnly.Parse("2023-01-15"),
                NoteMoyenne = 4.5m,
                Courses = [],
                Entretiens = [],
                Horaires = [],
                IdAdresseNavigation = null,
                IdEntrepriseNavigation = null,
                ReglementSalaires = [],
                Vehicules = []
            };
            _mockRepository = new Mock<IDataRepository<Coursier>>();
            _mockRepository.Setup(x => x.GetByStringAsync("123456789012").Result).Returns(coursier);
            _controller = new CoursiersController(_mockRepository.Object);
            // Act
            var actionResult = _controller.GetCoursierByNumeroCarteVTCAsync("123456789012").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(coursier, actionResult.Value as Coursier);
        }

        [TestMethod]
        public void GetCoursierByEmail_NotExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            
            _mockRepository = new Mock<IDataRepository<Coursier>>();
            _controller = new CoursiersController(_mockRepository.Object);
            // Act
            var actionResult = _controller.GetCoursierByNumeroCarteVTCAsync("123456789012").Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }
    }

}
