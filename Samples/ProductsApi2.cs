﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Framework;

namespace Samples
{
    public class ProductsApi2
    {
        private static List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product Get(int id)
        {
            lock (_products)
            {
                return _products.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Post(Product product)
        {
            lock (_products)
            {
                _products.Add(product);
            }
        }

        public void Delete(int id)
        {
            lock (_products)
            {
                _products.RemoveAll(p => p.Id == id);
            }
        }
    }
}
