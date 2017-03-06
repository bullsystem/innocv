using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Configuration;
using Newtonsoft.Json;

namespace Innocv.WebApi.Test
{
    /// <summary>
    /// Summary description for UsersControllerTest
    /// </summary>
    [TestClass]
    public class UsersControllerTest
    {
        private TestContext context;
        private WebClient webClient;

        public UsersControllerTest()
        {
            this.webClient = new WebClient();
            this.webClient.BaseAddress = ConfigurationManager.AppSettings["BaseUrl"];
        }

        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return this.context; }
            set { this.context = value; }
        }

        [TestMethod]
        public void Delete()
        {
            try
            {
                var response = this.webClient.UploadString("Users/Remove/2", "DELETE", String.Empty);
                Assert.Inconclusive();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void GetAll()
        {
            try
            {
                var response = this.webClient.DownloadString("Users/GetAll");

                if (String.IsNullOrEmpty(response))
                {
                    Assert.Inconclusive();
                }
                else
                {
                    Assert.AreNotEqual(JsonConvert.DeserializeObject(response), null);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void GetOne()
        {
            try
            {
                var response = this.webClient.DownloadString("Users/Get/1");

                if (String.IsNullOrEmpty(response))
                {
                    Assert.Inconclusive();
                }
                else
                {
                    Assert.AreNotEqual(JsonConvert.DeserializeObject(response), null);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Insert()
        {
            try
            {
                var response = this.webClient.UploadString("Users/Create", "POST", "{ \"Birthdate\":\"1900-01-01T00:00:00\", \"Name\":\"Carlos\" }");

                if (String.IsNullOrEmpty(response))
                {
                    Assert.Inconclusive();
                }
                else
                {
                    Assert.AreNotEqual(JsonConvert.DeserializeObject(response), null);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Update()
        {
            try
            {
                var response = this.webClient.UploadString("Users/Update/2", "PUT", "{ \"Birthdate\":\"1900-01-01T00:00:00\", \"Name\":\"Carlos Actualizado\" }");

                if (String.IsNullOrEmpty(response))
                {
                    Assert.Inconclusive();
                }
                else
                {
                    Assert.AreNotEqual(JsonConvert.DeserializeObject(response), null);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
