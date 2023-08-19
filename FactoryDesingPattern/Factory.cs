using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FactoryDesingPattern
{
    public static class Factory
    {
        //Lazy Loading, key Lazy
        // UnityContainer is a librery for help in object creation
        //Simple Factory, is not a Pattern
        private static Lazy<UnityContainer> container = new Lazy<UnityContainer>();
        static Factory()
        {
            container.Value.RegisterType<ICustomer, Customer>("Customer");
            container.Value.RegisterType<ICustomer, GoldCustomer>("Gold");
            container.Value.RegisterType<ICustomer, DiscountedCustomer>("Discounted");
            container.Value.RegisterType<ICustomer, SpecialCustomer>("Special");
        }
        public static ICustomer Create(string name)
        {
            return container.Value.Resolve<ICustomer>(name);
        }
    }
}
