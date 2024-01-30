using System.Reflection;

namespace EnumTask;

class Program
{
    static void Main(string[] args)
    {


        //var assembly = Assembly.GetCallingAssembly();
        //Product product1 = new Product();
        //var type = typeof(Product);
        //Console.WriteLine(CheckClass(type,assembly));

        //bool CheckClass(Type classType, Assembly assembly)
        //{
        //    foreach (var type in assembly.GetTypes())
        //    {
        //        if (type == classType) return true;
        //    }

        //    return false;
        //}

        //foreach (var item in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        //{
        //    Console.WriteLine(item.Name);

        //}
        
        Student std1 = new Student { Fullname = "Fullname1" };
        Student std2 = new Student { Fullname = "Fullname2" };
        Student std3 = new Student { Fullname = "Fullname3" };
        Teacher tch1 = new Teacher(150) { Fullname = "Fullname4" };
        Teacher tch2 = new Teacher(2500) { Fullname = "Fullname5" };
        Teacher tch3 = new Teacher(4500) { Fullname = "Fullname6" };
        Engineer eng1 = new Engineer(1234) { Fullname = "eduard" };
        Engineer eng2 = new Engineer(123) { Fullname = "eduard" };
        Engineer eng3 = new Engineer(12) { Fullname = "eduard" };

        Humans[] humans = new Humans[] { std1, std2, std3, tch1, tch2, tch3, eng1, eng2, eng3 };

        Console.WriteLine(Calc(humans));

        string countStr;
        int count;
        do
        {
            Console.WriteLine("nece eded Product yaradacaqsiniz?");
            countStr = Console.ReadLine();

        } while (!int.TryParse(countStr, out count));
        Product[] products = new Product[count];
        ProductList productList = new ProductList(products);

        for (int i = 0; i < count; i++)
        {
            string productName;
            do
            {
                Console.WriteLine("productun adini qeyd edin:");
                productName = Console.ReadLine();

            } while (!CheckName(productName));
           
            string priceStr;
            int price;
            do
            {
                Console.WriteLine("productun qiymetini daxil edin:");
                priceStr = Console.ReadLine();

            } while (!int.TryParse(priceStr, out price)|| price<0);

            string typeStr;
            do
            {
               Console.WriteLine("Product type'ni daxil edin:");
                typeStr = Console.ReadLine();
              
            } while ( String.IsNullOrWhiteSpace(typeStr)|| !Enum.IsDefined(typeof(ProductType), typeStr));

            ProductType productType = (ProductType)Enum.Parse(typeof(ProductType), typeStr);

            Product product = new Product
            {
                Name = productName,
                Price = price,
                Type = productType,
            };
            try
            {
                productList[i] = product;
                Console.WriteLine("elave edildi");
            }
            catch (IsExceptionInProduct)
            {
                Console.WriteLine("eyni nomreli product elave edil bilmez!");
            }
        }

        for (int i = 0; i < products.Length; i++)
        {
            Console.WriteLine($"no:{products[i].No}-name:{products[i].Name}-price:{products[i].Price}-type:{products[i].Type}");

        }
      
        Console.ReadLine();
    }

     static bool CheckName(string name)
    {
        if (String.IsNullOrWhiteSpace(name)) return false;

        for (int i = 0; i < name.Length; i++)
        {
            if (!char.IsLetter(name[i]))
                return false;
        }

        return true;
    }
    static int Calc(object[] objects)
    {
       int total = 0;
        foreach (var item in objects)
        {
            var salaryField = item.GetType().GetField("_salary", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (salaryField != null)
            {
                total +=(int)salaryField.GetValue(item);
            }
        }
        return total;
    }
    
 
}

