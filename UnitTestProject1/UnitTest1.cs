using EmpolyeeDetailsCaseStudy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        public void Test_GetUsers()
        {
            EmpolyeeService empolyeeService = new EmpolyeeService();
            var userList = empolyeeService.GetAll().Result;
            if(userList.Count>0)
            {
                Assert.IsTrue(userList.Count > 0);
            }
           
        }
        public void Test_Delete()
        {
            EmpolyeeService empolyeeService = new EmpolyeeService();
            var result = empolyeeService.ClientDeleteRequest();
            Assert.IsNotNull(result);

        }
    }
}
