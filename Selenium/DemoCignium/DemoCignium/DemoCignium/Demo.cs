using DemoCignium.DemoCignium.entidades;
using DemoCignium.pe.com.test.demoCignium.page;
using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCignium
{
    [TestFixture]
    public class Demo
    {

        private IWebDriver driver = null;
        private bool acceptNextAlert = true;

        private readonly string urlInicial = "http://automationpractice.com/index.php?";
        private CreateAccountPage createAccountPage;


        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void CrearCuenta()
        {
            createAccountPage = new CreateAccountPage("chrome", urlInicial, false);

            Cuenta cuenta = new Cuenta();
            cuenta.Email = "msandoval5" +
                "@cignium.com";
            cuenta.FirstName = "Tatiana";
            cuenta.LastName = "Sandoval";
            cuenta.Password = "abcdABCD1234";
            cuenta.Address = "Arbol #3";
            cuenta.CodigoPostal = "00000";
            cuenta.Alias = "Dikas es mi pastor";
            cuenta.Country = "United States";
            cuenta.State = "Alaska";
            cuenta.City = "Lima";
            cuenta.Phone = "15184851";

            var resultado = createAccountPage.Crear(cuenta);
            String nombre = resultado.Item1;
            String urlEsperada = "?controller=my-account";
            String urlObtenida = resultado.Item2;
            Assert.AreEqual(cuenta.FirstName+" "+cuenta.LastName, nombre);
            Assert.IsTrue(urlObtenida.Contains(urlEsperada));
            Assert.IsTrue(resultado.Item3);
        }


        [TearDown]
        public void CloseBrowser()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

   }

    

}


