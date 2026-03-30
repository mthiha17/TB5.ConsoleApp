using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB5.ConsoleApp_Database.AppDbContextModels;

namespace TB5.ConsoleApp.EFCoreSample
{
    public class EFCoreService
    {
        private readonly AppDbContext db = new AppDbContext();

        public void Read()
        {
            List<TblProduct> lst = db.TblProducts.ToList();

            foreach (TblProduct item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
            }
        }

        public void Edit()
        {
            TblProduct? itemProduct = db.TblProducts.Where(x => x.Id == 1).FirstOrDefault();
            if (itemProduct is null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine(itemProduct.Id);
            Console.WriteLine(itemProduct.Name);
            Console.WriteLine(itemProduct.Price);
        }

        public void Create()
        {
            TblProduct product = new TblProduct()
            {
                Name = "test",
                Price = 10000
            };
            db.TblProducts.Add(product);
            int result = db.SaveChanges();
            string message = result > 0 ? "Product created successfully." : "Failed to create product.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            TblProduct? itemProduct = db.TblProducts.Where(x => x.Id == 1).FirstOrDefault();
            if (itemProduct is null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            itemProduct.Price = 2000;
            int result = db.SaveChanges(); // update
            string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            TblProduct? itemProduct = db.TblProducts.Where(x => x.Id == 1).FirstOrDefault();
            if (itemProduct is null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            db.TblProducts.Remove(itemProduct);
            int result = db.SaveChanges(); // update
            string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
            Console.WriteLine(message);
        }
    }
}
