using System;
using EmployeeDetails.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeUnitTest
{
    [TestClass]
    public class APIUnitTest
    {
        [TestMethod]
        public void GETALLUsersList()
        {
            var RestHelper = new RestHelper();
            var response = RestHelper.GetALL();
            Assert.IsNotNull(response);

        }
        [TestMethod]
        public void GETUsersList()
        {
            var RestHelper = new RestHelper();
            var response = RestHelper.Get("123");
            Assert.IsNotNull(response);

        }
       
    }
}
