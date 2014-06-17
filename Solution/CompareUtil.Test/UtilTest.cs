using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompareUtil.Test {

    [TestClass]
    public class UtilTest {

        private Util _util = null;

        [TestInitialize]
        public void UtilTestSetup() {
            _util = new Util();
        }

        [TestCleanup]
        public void UtilTestSetup() {
            _util = null;
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void ComparingApplesAndOranges_ExpectingNotEqual() {

            var result = _util.Compare("Apples", "Oranges");
            Assert.AreEqual(result, "Not Equal");
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void ComparingTwoAndTwo_ExpectingEqual() {

            var result = _util.Compare(2, 2);
            Assert.AreEqual(result, "Equal");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(NullReferenceException))]
        public void ComparingNullAndEmpty_ExpectingException() {

            var result = _util.Compare(null as string, string.Empty);
            Assert.AreEqual(result, false);
        }
    }
}
