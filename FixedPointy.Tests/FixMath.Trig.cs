using System;
using System.Collections;
using NUnit.Framework;

namespace FixedPointy.Tests
{
    [TestFixture]
    public class FixMathTrigTests
    {
        [Test, TestCaseSource(typeof(InterestingAngles), nameof(InterestingAngles.TestCases))]
        public void SinWorks(double value)
        {
            var expected = Math.Sin(value * Math.PI / 180.0);

            var result = (double)FixMath.Sin((Fix)value);

            Assert.AreEqual(expected, result, (double)Fix.Epsilon);
        }

        [Test, TestCaseSource(typeof(InterestingAngles), nameof(InterestingAngles.TestCases))]
        public void CosWorks(double value)
        {
            var expected = Math.Cos(value * Math.PI / 180.0);

            var result = (double)FixMath.Cos((Fix)value);

            Assert.AreEqual(expected, result, (double)Fix.Epsilon);
        }

        [Test, TestCaseSource(typeof(InterestingAngles), nameof(InterestingAngles.TestCases))]
        public void TanWorks(double value)
        {
            var expected = Math.Tan(value * Math.PI / 180.0);

            if (expected > Fix.MAX_INTEGER || expected < Fix.MIN_INTEGER)
            {
                Assert.Throws<OverflowException>(() =>
                {
                    var _ = (double)FixMath.Tan((Fix)value);
                });
            }
            else
            {
                var result = (double)FixMath.Tan((Fix)value);

                Assert.AreEqual(expected, result, 2 * (double)Fix.Epsilon);
            }
        }
    }

    public static class InterestingAngles
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return 0;
                for (int i = 1; i < 30; i++)
                {
                    yield return i;
                    yield return -i;
                    yield return 45 * i;
                    yield return -720 * i;
                    yield return i / 2.0;
                    yield return -i / 10.0;
                }
            }
        }
    }
}
