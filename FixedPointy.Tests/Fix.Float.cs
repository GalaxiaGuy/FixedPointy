using System;
using NUnit.Framework;

namespace FixedPointy.Tests
{
    [TestFixture]
    public class FixFromFloatTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0.1f)]
        [TestCase(-0.1f)]
        [TestCase((float)Math.PI)]
        [TestCase((float)Math.E)]
        public void RoundTripWorks(float value)
        {
            var fix = (Fix)value;

            var result = (float)fix;

            Assert.AreEqual(value, result, (double)Fix.Epsilon);
        }
    }
}
