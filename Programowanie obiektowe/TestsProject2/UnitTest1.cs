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

        [Fact]
        public void SortingTest()
        {
            Ulamek[] ulamekArray = new Ulamek[] { new Ulamek(5, 6), new Ulamek(1, 2), new Ulamek(4, 5), new Ulamek(6, 7) };
            bool isSorted = true;

            for (int i = 0; i < ulamekArray.Length; i++)
            {
                for (int j = 0; j < ulamekArray.Length; j++)
                {
                    if (j + 1 < ulamekArray.Length)
                    {
                        if (ulamekArray[j].CompareTo(ulamekArray[j + 1]) > 0)
                        {
                            Ulamek temp = ulamekArray[j];
                            ulamekArray[j] = ulamekArray[j + 1];
                            ulamekArray[j + 1] = temp;
                        }
                    }
                }
            }

            for (int i = 0; i < ulamekArray.Length; i++) // Checking if array was sorted
            {
                if (i + 1 < ulamekArray.Length)
                {
                    if (ulamekArray[i].CompareTo(ulamekArray[i + 1]) == 1)
                    {
                        isSorted = false;
                    }
                }
            }

            Assert.True(isSorted);
        }
    }
}
