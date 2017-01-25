using System;
using System.Collections;
using NUnit.Framework;

namespace FixedPointy.Tests
{
    [TestFixture]
    public class FixMathSqrtTests
    {
        [Test, TestCaseSource(typeof(InterestingSqrtValues), nameof(InterestingAngles.TestCases))]
        public void SqrtWorks(double value)
        {
            var expected = Math.Sqrt(value);

            var result = (double)FixMath.Sqrt((Fix)value);

            Assert.AreEqual(expected, result, (double)Fix.Epsilon * 4);
        }
    }

    public static class InterestingSqrtValues
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return 0;
                yield return Math.E;
                yield return Math.PI;
                for (int i = 1; i < 30; i++)
                {
                    yield return i;
                    yield return 1000 * i;
                    yield return 1000.1 * i;
                    yield return 0.1 * i;
                    yield return 0.002 * i;
                }
            }
        }
    }
}
