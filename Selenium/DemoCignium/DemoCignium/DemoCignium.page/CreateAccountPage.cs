﻿using DemoCignium.DemoCignium.driver;
using DemoCignium.DemoCignium.entidades;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCignium.pe.com.test.demoCignium.page
{
    public class CreateAccountPage
    {
        //private string urlInicial;
        private IWebDriver driver = null;
        private readonly By btnSign = By.LinkText("Sign in");
        private readonly By txtEmail = By.Id("email_create");
        private readonly By btnSubmit = By.Id("SubmitCreate");
        private readonly By txtFirstName = By.Id("customer_firstname");
        private readonly By txtLastName = By.Id("customer_lastname");
        private readonly By txtPass = By.Id("passwd");
        private readonly By txtAddress = By.Id("address1");
        private readonly By txtCity = By.Id("city");      
        private readonly By txtPostal = By.Id("postcode");        
        private readonly By txtPhone = By.Id("phone_mobile");
        private readonly By txtAlias = By.Id("alias");
        private readonly By btnSubmitAccount = By.Id("submitAccount");
        private readonly By headerName = By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a/span");
        private readonly By btnLogout = By.ClassName("logout");

        public CreateAccountPage(String navegador, String urlInicial, bool remoto)
        {
            this.driver = DemoDriver.InicializarDriver(navegador,remoto);
            this.driver.Url = urlInicial;
        }

        public Tuple<string, string,bool> Crear(Cuenta cuenta) {
            bool rpta = false;
            driver.FindElement(btnSign).Click();            
            driver.FindElement(txtEmail).SendKeys(cuenta.Email);
            driver.FindElement(btnSubmit).Click();
            Thread.Sleep(2000);
            driver.FindElement(txtFirstName).SendKeys(cuenta.FirstName);
            driver.FindElement(txtLastName).SendKeys(cuenta.LastName);
            driver.FindElement(txtPass).SendKeys(cuenta.Password);
            driver.FindElement(txtAddress).SendKeys(cuenta.Address);
            driver.FindElement(txtCity).SendKeys(cuenta.City);
            var cboState = new SelectElement(driver.FindElement(By.Id("id_state")));
            cboState.SelectByText(cuenta.State);
            driver.FindElement(txtPostal).SendKeys(cuenta.CodigoPostal);
            var cboCountry = new SelectElement(driver.FindElement(By.Id("id_country")));
            cboCountry.SelectByText(cuenta.Country);
            driver.FindElement(txtPhone).SendKeys(cuenta.Phone);
            driver.FindElement(txtAlias).SendKeys(cuenta.Alias);
            driver.FindElement(btnSubmitAccount).Click();
            var nameAccount = driver.FindElement(headerName).Text;
            string urlObtenida = driver.Url;            
            if (driver.FindElement(btnLogout).Displayed)
            {
                rpta = true;
            }
            return Tuple.Create(nameAccount, urlObtenida,rpta);

        }

  
        public void CerrarPagina()
        {
            DemoDriver.CerrarPagina(driver);
        }

    }
}
