using System;
using NUnit.Framework;

namespace FixedPointy.Tests
{
    [TestFixture]
    public class FixFromDoubleTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0.1)]
        [TestCase(-0.1)]
        [TestCase(Math.PI)]
        [TestCase(Math.E)]
        public void RoundTripWorks(double value)
        {
            var fix = (Fix)value;

            var result = (double)fix;

            Assert.AreEqual(value, result, (double)Fix.Epsilon);
        }
    }
}
