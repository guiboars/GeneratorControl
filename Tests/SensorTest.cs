using GeneratorControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for SensorTest and is intended
    ///to contain all SensorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SensorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Sensor Constructor
        ///</summary>
        [TestMethod()]
        public void SensorConstructorTest()
        {
            var target = new Sensor.Sensor();
            Assert.IsNotNull(target); // this should be sufficient for now.
        }

        /// <summary>
        ///A test for Status
        ///</summary>
        [TestMethod()]
        public void StatusTest()
        {
            var sensorFalse = new Sensor.Sensor() { Status = false };
            var sensorTrue = new Sensor.Sensor() { Status = true };
            Assert.IsNotNull(sensorFalse);
            Assert.IsNotNull(sensorTrue);
            Assert.IsTrue(sensorTrue.Status);
            Assert.IsFalse(sensorFalse.Status);
        }
    }
}
