using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext dbContext;


        //private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            //this.dbContext = dbContext;
            // dbContext = new ApplicationDbContext();
            //_dbContext = dbContext;
        }
        public int Add(Product product)
        {
            dbContext.Products.Add(product);
            return dbContext.SaveChanges();
        }

        public int Delete(Product product)
        {
            dbContext.Products.Remove(product);
            return dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.AsNoTracking().ToList();

        }

        public Product GetById(int id)
        {
            /*var product = dbContext.Products.Local.Where(p=>p.Id == id).FirstOrDefault();
            if (dep is null)
            {
                dep = dbContext.Products.Where(p=>p.Id == id).FirstOrDefault();
            }*/
            //return dbContext.Products.Where(p=>p.Id == id).FirstOrDefault();
            return dbContext.Products.Find(id);
        }

        public int Update(Product product)
        {
            dbContext.Products.Update(product);
            return dbContext.SaveChanges();
        }
    }
}
