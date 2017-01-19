using System;
using NUnit.Framework;

namespace FixedPointy.Tests
{
    [TestFixture]
    public class FixCtorTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void FixConstructorWorks(int raw)
        {
            var fix = new Fix(raw);

            Assert.AreEqual(fix.Raw, raw, "Raw value is not correct");
        }
    }
}
