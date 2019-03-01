using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Unit
{
    [TestClass]
    public class UnitTest1
    {
        public const string valueToTest = "test";
        public string expected;
        public string dbExpected;

        [TestInitialize]
        public void TestInitialize()
        {
            expected = valueToTest + Environment.NewLine;
            dbExpected = string.Format("Saved value({0}) to db.{1}", valueToTest, Environment.NewLine);
        }

        [TestMethod]
        public void FactoryGetWriterShouldReturnConsole()
        {
            var sut = new API.Factory();
            PrivateObject factory = new PrivateObject(sut);
            var returnObj = factory.Invoke("GetWriter", API.OutputWriters.console);
            Assert.AreEqual(typeof(API.ConsoleWriter), returnObj.GetType());
        }

        [TestMethod]
        public void FactoryGetWriterShouldReturnDB()
        {
            var sut = new API.Factory();
            PrivateObject factory = new PrivateObject(sut);
            var returnObj = factory.Invoke("GetWriter", API.OutputWriters.database);
            Assert.AreEqual(typeof(API.DBWriter), returnObj.GetType());
        }

        [TestMethod]
        public void FactoryShouldWriteToConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var sut = new API.Factory();
                sut.WriteOutput(API.OutputWriters.console, valueToTest);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void FactoryShouldWriteToDB()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var sut = new API.Factory();
                sut.WriteOutput(API.OutputWriters.database, valueToTest);
                Assert.AreEqual<string>(dbExpected, sw.ToString());
            }
        }

        [TestMethod]
        public void InjectorShouldWriteToConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var sut = new API.Injection(new API.ConsoleWriter());
                sut.WriteOutput(valueToTest);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void InjectorShouldWriteToDB()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var sut = new API.Injection(new API.DBWriter());
                sut.WriteOutput(valueToTest);
                Assert.AreEqual<string>(dbExpected, sw.ToString());
            }
        }

        [TestMethod]
        public void ConsoleWriterShouldWriteToConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                API.IWriter sut = new API.ConsoleWriter();
                sut.WriteOutput(valueToTest);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void DBWriterShouldWriteToDB()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                API.IWriter sut = new API.DBWriter();
                sut.WriteOutput(valueToTest);
                Assert.AreEqual<string>(dbExpected, sw.ToString());
            }
        }
    }
}
