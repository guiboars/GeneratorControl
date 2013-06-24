using Generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for GeneratorTest and is intended
    ///to contain all GeneratorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeneratorTest
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
        ///A test for Generator Constructor
        ///</summary>
        [TestMethod()]
        public void GeneratorConstructorTest()
        {
            var target = new Generator.Generator();
            Assert.IsNotNull(target);
            // verify that the fuel, choke and vibration sensors are initialized correctly.
            Assert.IsTrue(target.HasFuel);
            Assert.IsTrue(target.IsChoked);
            Assert.IsFalse(target.IsRunning);
        }

        /// <summary>
        ///A test for HasFuel
        ///</summary>
        [TestMethod()]
        public void HasFuelTest()
        {
            var target = new Generator.Generator();
            Assert.IsTrue(target.HasFuel);
        }

        /// <summary>
        /// Test fuel operations.
        ///</summary>
        [TestMethod()]
        public void FuelTest()
        {
            var target = new Generator.Generator();
            Assert.IsTrue(target.HasFuel);
            target.DrainFuel();
            Assert.IsFalse(target.HasFuel);
            target.Refuel();
            Assert.IsTrue(target.HasFuel);
        }

        /// <summary>
        /// Test starting operations.
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            var target = new Generator.Generator();
            target.Start();
            Assert.IsTrue(target.IsRunning,"Generator unable to start! (attempt 1)");
            Assert.IsFalse(target.IsChoked); // should not have choke engaged.
            Assert.IsFalse(target.HasFuel); // if it started, it ran and used up all the fuel.
            
            target.Start(); // a second attempt should not change values on target.
            Assert.IsTrue(target.IsRunning, "Generator not started!");
            Assert.IsFalse(target.IsChoked); // should not have choke engaged.
            Assert.IsFalse(target.HasFuel); // if it started, it ran and used up all the fuel.

            target.Stop();
            Assert.IsFalse(target.IsRunning);  // Now, it should be stopped.
            Assert.IsFalse(target.IsChoked);  // the choke is still disengaged.
            Assert.IsFalse(target.HasFuel); // there should be no fuel.

            target.Start(); // this should not work because there is no fuel.
            Assert.IsFalse(target.IsRunning);  // It should remain stopped.
            Assert.IsFalse(target.IsChoked);  // the choke is still disengaged.
            Assert.IsFalse(target.HasFuel); // there is still no fuel.

            target.Refuel();
            Assert.IsTrue(target.HasFuel);  // now, we should be able to start it.

            target.Start();
            Assert.IsTrue(target.IsRunning, "Generator unable to start! (attempt 2)");
            Assert.IsFalse(target.IsChoked); // should not have choke engaged.
            Assert.IsFalse(target.HasFuel); // if it started, it ran and used up all the fuel.
        }

        /// <summary>
        /// Test operation of the choke.
        ///</summary>
        [TestMethod()]
        public void ChokeTest()
        {
            var target = new Generator.Generator();
            Assert.IsTrue(target.IsChoked);
            target.DisengageChoke();
            Assert.IsFalse(target.IsChoked);
            target.EngageChoke();
            Assert.IsTrue(target.IsChoked);
        }

    }
}
