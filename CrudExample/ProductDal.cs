using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample
{
    public class ProductDal
    {
      
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }
        }
        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }
        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
            }
        }
        //max ve min fiyat bilgisine göre arama
        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
            }
        }
        /**tek ürün, data yoksa null değilse kendisi 
         * (FirstOrDefault ve SingleOrDefault aynı tek data döndürür
         * ama birden fazla olunca single hata veriri)*/
        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Products.SingleOrDefault(p => p.Id == id);
                return result;
            }
        }
        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                // context.Products.Add(product);//ekle
                var entity = context.Entry(product);//burda benim gönderdiğim productı Vtabnındaki productla eşitliyor
                entity.State = EntityState.Added;
                context.SaveChanges();//veri tabanına kaydet
            }
        }
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);//burda benim gönderdiğim productı Vtabnındaki productla eşitliyor
                entity.State = EntityState.Modified;
                context.SaveChanges();//veri tabanına kaydet
            }
        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);//burda benim gönderdiğim productı Vtabnındaki productla eşitliyor
                entity.State = EntityState.Deleted;
                context.SaveChanges();//veri tabanına kaydet
            }
        }
    }
}

