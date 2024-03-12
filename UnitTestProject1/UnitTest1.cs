using DZ1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void addTest()
        {
            //addClass adcl = new addClass("Зарплата", "67387462");
            var name = "Зарплата";
            var phone = "67387462";
            bool expected = false;
            bool actual;

            addClass addClass = new addClass();

            addClass.insertContact(name, phone);
        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void connTest()
        {
            bool expected = true;
            bool actual;
 
        }
    }
}
