using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FactoryParttern
{
    //interface for creating objects
    public interface IFactory
    {
        IDiscount CreateDiscount();
        ITax CreateTax();
        IDelivery CreateDelivery();

        ICustomer CreateCustomer();//IDiscount discount, ITax tax, IDelivery delivery
    }
    //The Factory method
    public class FactoryBase : IFactory
    {
        public virtual ICustomer CreateCustomer()
        {
           return new Customer(CreateDiscount(), CreateTax(), CreateDelivery());
        }

        public virtual IDelivery CreateDelivery()
        {
            return new Courier();
        }

        public virtual IDiscount CreateDiscount()
        {
            return new WeeklyDiscount();
        }

        public virtual ITax CreateTax()
        {
            return  new LocalTax();
        }
    }

    public class FactoryCustomerNoTax : FactoryBase
    {
        public override ITax CreateTax()
        {
            return new NoTax();
        }

    }

    public class FactoryCustomerHolidayDiscount : FactoryBase
    {
        public override IDiscount CreateDiscount()
        {
            return new HolidayDiscount();
        }
    }




    // Lazy Loading, key Lazy
    // UnityContainer is a librery for help in object creation

    /// <summary>
    /// The Factory Method defines an interface for creating objects
    /// /but lets subclasses decide which classes to instantiate. 
    /// The Factory method lets a class defer instantiation to subclass.
    /// </summary>
    /// <param name="args"></param>
    public class Factory
    {
        private static Lazy<UnityContainer> container = new Lazy<UnityContainer>();

        static Factory()
        {
            container.Value.RegisterType<IFactory, FactoryBase>("Customer");
            container.Value.RegisterType<IFactory, FactoryCustomerNoTax>("NoTax");
            container.Value.RegisterType<IFactory, FactoryCustomerHolidayDiscount>("HoliDay");
        }
        public static ICustomer Create(string name)
        {
            return container.Value.Resolve<IFactory>(name).CreateCustomer();
        }
    }
}
