using System;
using Xunit;

namespace TestsProject2
{
    public class UnitTest1
    {
        [Xunit.Fact]
        public void ComparingTest()
        {
            Programowanie_obiektowe.Ulamek u = new Programowanie_obiektowe.Ulamek(3, 2);
            Programowanie_obiektowe.Ulamek i = new Programowanie_obiektowe.Ulamek(5, 3);
            Programowanie_obiektowe.Ulamek o = new Programowanie_obiektowe.Ulamek(1, 3);
            Programowanie_obiektowe.Ulamek p = new Programowanie_obiektowe.Ulamek(1, 4);

            bool isGreater = false;
            if (i.CompareTo(u) > 0)
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
            Programowanie_obiektowe.Ulamek u = new Programowanie_obiektowe.Ulamek(1, 2);
            Programowanie_obiektowe.Ulamek y = new Programowanie_obiektowe.Ulamek(2, 3);

            Assert.Equal(0, u.RoundDown());
            Assert.Equal(1, y.RoundUp());
        }

        [Fact]
        public void OperatorTests()
        {
            Programowanie_obiektowe.Ulamek ulamek1 = new Programowanie_obiektowe.Ulamek(1, 2);
            Programowanie_obiektowe.Ulamek ulamek2 = new Programowanie_obiektowe.Ulamek(3, 2);

            Assert.Equal("3/4", (ulamek1 * ulamek1).ToString());
            Assert.Equal("8/4", (ulamek1 + ulamek2).ToString());
        }
    }
}
