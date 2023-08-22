using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public abstract class Product
    {
        protected Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public abstract void Add(Product product);
        public abstract void Remove(Product product);

        public abstract string GetPrice();
    }

    public class SimpleProduct : Product
    {
        public SimpleProduct(string name, int price) : base(name, price)
        {
        }

        public override void Add(Product product)
        {
            // Operación no se puede realizar porqué es el elemento que se encuentra mas abajo en la jerarquía

        }

        public override void Remove(Product product)
        {
            // Operación no se puede realizar porqué es el elemento que se encuentra mas abajo en la jerarquía
        }

        public override string GetPrice()
        {
            return $"El precio de {Name} es {Price.ToString("N2")}";
        }

    }

    public class CompositeProduct : Product
    {
        List<Product> _products = new List<Product>();

        public CompositeProduct(string name) : base(name, 0)
        {
        }

        public override void Add(Product product)
        {
            _products.Add(product);
        }

        public override string GetPrice()
        {
            return $"El precio de {Name} es {_products.Sum(o => o.Price).ToString("N2")}";
        }

        public override void Remove(Product product)
        {
            _products.Remove(product);
        }
    }

}
