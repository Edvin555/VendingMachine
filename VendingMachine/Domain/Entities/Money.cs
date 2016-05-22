using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     
    public struct Money
    {
        public int Euros { get; set; }
        public int Cents { get; set; }

        public static bool operator <(Money m1, Money m2)
        {
            int m1TotalCents = m1.Cents + m1.Euros * 100;
            int m2TotalCents = m2.Cents + m2.Euros * 100;
            if (m1TotalCents < m2TotalCents) return true;
            else return false;
        }

        public static bool operator >(Money m1, Money m2)
        {
            int m1TotalCents = m1.Cents + m1.Euros * 100;
            int m2TotalCents = m2.Cents + m2.Euros * 100;
            if (m1TotalCents > m2TotalCents) return true;
            else return false;
        }

        public static Money operator -(Money m1, Money m2)
        {
            int m1TotalCents = m1.Cents + m1.Euros * 100;
            int m2TotalCents = m2.Cents + m2.Euros * 100;
            
            Money result = new Money() { Cents = (m1TotalCents - m2TotalCents) % 100, Euros = (m1TotalCents - m2TotalCents) / 100 };           
            return result;
        }
    }
}
