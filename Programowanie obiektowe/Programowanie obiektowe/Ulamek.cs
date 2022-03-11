using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe
{
    public class Ulamek : IEquatable<Ulamek>, IComparable<Ulamek>
    {
        private int licznik { get; }
        private int mianownik { get; }

        /// <summary>
        /// Creates an empty Ulamek with licznik = 0 and mianownik = 1
        /// </summary>
        public Ulamek()
        {
            licznik = 0;
            mianownik = 1;
        }

        public Ulamek(int licznik, int mianownik)
        {
            this.licznik = licznik;
            this.mianownik = mianownik;
        }
        /// <summary>
        /// Coppies Ulamek to new object
        /// </summary>
        /// <param name="ulamek"></param>
        public Ulamek(Ulamek ulamek)
        {
            licznik = ulamek.licznik;
            mianownik = ulamek.mianownik;
        }
        /// <summary>
        /// Presents Ulamek as String with fromat "licznik/mianownik"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{licznik}/{mianownik}";
        }
        /// <summary>
        /// Compares this object to other Ulamek
        /// </summary>
        /// <param name="u">Ulamek to be compared to</param>
        /// <returns>1 if greater, 0 if equal and -1 if lesser</returns>
        public int CompareTo(Ulamek u)
        {
            if (this.licznik == u.licznik)
            {
                if (this.mianownik > u.mianownik)
                {
                    return -1;
                }
                else if (this.mianownik < u.mianownik)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (this.mianownik == u.mianownik)
            {
                if (this.licznik > u.licznik)
                {
                    return 1;
                }
                else if (this.mianownik < u.mianownik)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                Ulamek temp = new Ulamek(this.licznik * u.mianownik, this.mianownik * u.mianownik);
                Ulamek temp2 = new Ulamek(u.licznik * this.mianownik, u.mianownik * this.mianownik);

                if (temp.licznik > temp2.licznik)
                {
                    return 1;
                }
                else if (temp.licznik < temp2.licznik)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Check if ulamek are equal
        /// </summary>
        /// <param name="u"></param>
        /// <returns>true if equal, false otherwise</returns>
        public bool Equals(Ulamek u)
        {
            if (u.licznik == this.licznik && u.mianownik == this.mianownik)
            {
                return true;
            }
            return false;

        }

        public static Ulamek operator +(Ulamek u)
        {
            Ulamek temp = new Ulamek(u.licznik, u.mianownik);
            return temp;
        }
        public static Ulamek operator +(Ulamek u, Ulamek y)
        {
            Ulamek temp;
            if (u.mianownik == y.mianownik)
            {
                temp = new Ulamek(u.licznik + y.licznik, u.mianownik);
            }
            else
            {
                temp = new Ulamek(u.licznik * y.mianownik + y.licznik * u.mianownik, u.mianownik * y.mianownik);
            }
            return temp;
        }

        public static Ulamek operator -(Ulamek u)
        {
            Ulamek temp = new Ulamek(-u.licznik, u.mianownik);
            return temp;
        }
        public static Ulamek operator -(Ulamek u, Ulamek y)
        {
            Ulamek temp;
            if (u.mianownik == y.mianownik)
            {
                temp = new Ulamek(u.licznik - y.licznik, u.mianownik);
            }
            else
            {
                temp = new Ulamek(u.licznik * y.mianownik - y.licznik * u.mianownik, u.mianownik * y.mianownik);
            }
            return temp;
        }

        public static Ulamek operator *(Ulamek u, Ulamek y)
        {
            Ulamek temp = new Ulamek(u.licznik * y.licznik, u.mianownik * y.mianownik);
            return temp;
        }
        public static Ulamek operator /(Ulamek u, Ulamek y)
        {
            Ulamek temp = new Ulamek(u.licznik * y.mianownik, u.mianownik * y.licznik);
            return temp;
        }
        /// <summary>
        /// Rounds Ulamek Up to closest int number
        /// </summary>
        /// <returns></returns>
        public int RoundUp()
        {
            int tempLicznik = licznik;
            while (tempLicznik % mianownik != 0)
            {
                tempLicznik++;
            }
            return tempLicznik / mianownik;
        }
        /// <summary>
        /// Round Ulamek Down to closest int number
        /// </summary>
        /// <returns></returns>
        public int RoundDown()
        {
            int tempLicznik = licznik;
            while (tempLicznik % mianownik != 0)
            {
                tempLicznik--;
            }
            return tempLicznik / mianownik;
        }
    }
}
