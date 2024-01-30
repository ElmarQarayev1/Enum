using System;
namespace EnumTask
{
	public class ProductList
	{
		private Product[] _products1 = new Product[0];
		public ProductList()
		{

		}
		public ProductList(Product[] products )
		{
			_products1 = products;

		}
		public Product this[int i]
		{
			get => _products1[i];
			set
			{
				if (!HasSameId(value.No))
				{
					_products1[i] = value;
				}
				else
				{

					throw new IsExceptionInProduct();

				}
			}
		}
		public bool HasSameId(int no)
		{
			foreach (var item in _products1)
			{
				if (item != null && item.No == no)
				{
					return true;
				}

			}
			return false;

		}

	}
}

