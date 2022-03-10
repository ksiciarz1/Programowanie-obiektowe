﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_obiektowe
{
    class Ulamek : IEquatable<Ulamek>, IComparable<Ulamek>
    {
        private int licznik { get; }
        private int mianownik { get; }

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
        public Ulamek(Ulamek ulamek)
        {
            licznik = ulamek.licznik;
            mianownik = ulamek.mianownik;
        }

        public override string ToString()
        {
            return $"{licznik}/{mianownik}";
        }

        public int CompareTo(Ulamek u)
        {
            Ulamek temp = new Ulamek(u.licznik * this.mianownik, u.mianownik * this.mianownik);
            Ulamek temp2 = new Ulamek(this.licznik * u.mianownik, this.mianownik * u.mianownik);

            if (temp.licznik > temp2.licznik)
            {
                return 1;
            }
            else if (temp.licznik == temp2.licznik)
            {
                return 0;
            }
            else return -1;
        }

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
            Ulamek temp = new Ulamek(u.licznik * y.mianownik + y.licznik * u.mianownik, u.mianownik * y.mianownik);
            return temp;
        }

        public static Ulamek operator -(Ulamek u)
        {
            Ulamek temp = new Ulamek(-u.licznik, u.mianownik);
            return temp;
        }
        public static Ulamek operator -(Ulamek u, Ulamek y)
        {
            Ulamek temp = new Ulamek(u.licznik * y.mianownik - y.licznik * u.mianownik, u.mianownik * y.mianownik);
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
    }
}
