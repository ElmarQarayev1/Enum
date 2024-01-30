using System;
namespace EnumTask
{
	public class Product
	{
        public Product()
        {
            _staticNo++;
            No = _staticNo;
        }
        private static int _staticNo;
        public readonly int No;
        public string Name;
        public double Price;
        public ProductType Type;
    }
}

