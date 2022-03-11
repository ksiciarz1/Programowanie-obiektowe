using System;
using Xunit;
using Programowanie_obiektowe;

namespace TestsProject2
{
    public class UnitTest1
    {
        [Fact]
        public void toStringTest()
        {
            Ulamek u = new Ulamek(1, 2);
            Assert.Equal("1/2", u.ToString());

            Ulamek y = new Ulamek(3, 4);
            Assert.Equal("3/4", y.ToString());

            Ulamek t = new Ulamek(8, 4);
            Assert.Equal("8/4", t.ToString());
        }

        [Fact]
        public void ComparisonTest()
        {
            Ulamek u = new Ulamek(3, 2);
            Ulamek i = new Ulamek(5, 5);
            Ulamek o = new Ulamek(1, 3);
            Ulamek p = new Ulamek(1, 4);

            bool isGreater = false;
            if (u.CompareTo(i) > 0)
            {
                isGreater = true;
            }

            Assert.True(isGreater);

            isGreater = false;
            if (o.CompareTo(p) > 0)
            {
                isGreater = true;
            }

            Assert.True(isGreater);
        }

        [Fact]
        public void RoundingTest()
        {
            Ulamek u = new Ulamek(1, 2);
            Ulamek y = new Ulamek(2, 3);

            Assert.Equal(0, u.RoundDown());
            Assert.Equal(1, y.RoundUp());
        }

        [Fact]
        public void OperatorTests()
        {
            Ulamek u = new Ulamek(1, 2);
            Ulamek y = new Ulamek(3, 2);

            Assert.Equal("3/4", (u * y).ToString());
            Assert.Equal("4/2", (u + y).ToString());

            Assert.Equal("-2/2", (u - y).ToString());
            Assert.Equal("2/6", (u / y).ToString());
        }
    }
}
