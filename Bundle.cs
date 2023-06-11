using System;
using System.Linq;

namespace Task1
{
    public struct Bundle
    {
        private static int[] acceptableBanknotes = new[]
        {
            1, 2, 5, 10, 50, 100, 200, 500, 1000, 2000, 5000
        };
        private int _banknoteType;
        public int BanknoteType
        {
            get => _banknoteType;
            set
            {
                if (!acceptableBanknotes.Contains(value))
                    throw new ArgumentException("Значение должно быть в списке допустимых купюр");
                _banknoteType = value;
            }
        }
        
        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение должно быть неотрицательным");
                _count = value;
            }
        }

        public int Sum => _count * _banknoteType;

        public Bundle(int banknoteType, int count)
        {
            _banknoteType = banknoteType;
            _count = count;
        }

        public override string ToString()
        {
            return $"{Count} x {BanknoteType} р.";
        }

        public override bool Equals(object other)
        {
            if (other is not Bundle)
                throw new ArgumentException("Объект должен быть Bundle");
            var bundle = (Bundle)other;
            return bundle.Count == Count && bundle.BanknoteType == BanknoteType; 
;        }
        
        public static bool operator ==(Bundle x, Bundle y) => x.Equals(y);
        public static bool operator !=(Bundle x, Bundle y) => !x.Equals(y);
        
        public static Bundle operator +(Bundle x, Bundle y)
        {
            if (x.BanknoteType != y.BanknoteType)
                throw new ArgumentException("Тип банкнот должен быть одинаковым");
            return new Bundle(x.BanknoteType, x.Count + y.Count);
        }
        
        public static Bundle operator -(Bundle x, Bundle y)
        {
            if (x.BanknoteType != y.BanknoteType)
                throw new ArgumentException("Тип банкнот должен быть одинаковым");
            if (x.Sum < y.Sum)
                throw new ArgumentException("Сумма вычета не должна быть больше изначальной");
            return new Bundle(x.BanknoteType, x.Count - y.Count);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}