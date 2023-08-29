using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public abstract class ACompositeProduct: AProduct
    {
        protected ACompositeProduct(string name, int price) : base(name, price)
        {
        }

        public abstract void Add(AProduct product);
        public abstract void Remove(AProduct product);

         
    }

    public abstract class AProduct
    {
        protected AProduct(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get;  private set; }
        public int Price { get;  private set; }
        public virtual string GetPrice()
        {
            return $"El precio de {Name} es {Price.ToString("N2")}";
        }
    }

    public class SimpleProduct2 : AProduct
    {
        public SimpleProduct2(string _name, int _price):base(_name, _price)
        {
        }

    }

    public class CompositeProduct2 : ACompositeProduct
    {
        List<AProduct> _products = new List<AProduct>();

        public CompositeProduct2(string name, int price = 0) : base(name, price)
        {
        }

        public override string GetPrice()
        {
            return $"El precio de {Name} es {_products.Sum(o => o.Price).ToString("N2")}";
        }
        public override void Add(AProduct product)
        {
            _products.Add(product);
        }

        public override void Remove(AProduct product)
        {
            _products.Remove(product);
        }
    }
}
