using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AbstracFactoryPattern
{

    // Lazy Loading, key Lazy
    // UnityContainer is a librery for help in object creation

    /// <summary>
    /// Abstrac factory Pattern
    /// Provide an interface for creating families of related or dependent objects without specifying their concrete class.
    /// 
    /// ICustomer = interface for creating families of related or dependent objects
    /// </summary>
    /// <param name="args"></param>
    public class Factory
    {
        private static Lazy<UnityContainer> normalCustomer = new Lazy<UnityContainer>();
        private static Lazy<UnityContainer> corporateCustomer = new Lazy<UnityContainer>();

        static Factory()
        {
            normalCustomer.Value.RegisterType<IFactory, FactoryBase>("Customer");
            normalCustomer.Value.RegisterType<IFactory, FactoryCustomerNoTax>("NoTax");
            normalCustomer.Value.RegisterType<IFactory, FactoryCustomerHolidayDiscount>("HoliDay");


            corporateCustomer.Value.RegisterType<IFactoryCorporate, FactoryCorporateBase>("CorporatePublic");
            corporateCustomer.Value.RegisterType<IFactoryCorporate, PrivateCorporatePrivate>("CorporatePrivate");
        }
        public static ICustomer CreateNormalCustomer(string name)
        {
            return normalCustomer.Value.Resolve<IFactory>(name).CreateCustomer();
        }
        public static ICustomer CreateCorporateCustomer(string name)
        {
            return corporateCustomer.Value.Resolve<IFactoryCorporate>(name).CreateCustomer();
        }
    }



    //-----------------------------Normal Customer Factory----------------------------  INICIO --------------

    #region Normal Customer Factory
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
            return new LocalTax();
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

    #endregion


    //-----------------------------Corporate Factory----------------------------  INICIO --------------


    #region Corporate Factory

    public interface IFactoryCorporate : IFactory
    {
        ICorporateType CreateCorporateType();
    }

    public class FactoryCorporateBase : IFactoryCorporate
    {

        public virtual ICustomer CreateCustomer()
        {
            return new CorporateCustomer(CreateDiscount(), CreateTax(), CreateDelivery(), CreateCorporateType());
        }

        public virtual ICorporateType CreateCorporateType()
        {
            return new PublicCorporate();
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
            return new LocalTax();
        }
    }


    public class PrivateCorporatePrivate : FactoryCorporateBase
    {
        public override ICorporateType CreateCorporateType()
        {
            return new PropCorporate();
        }
    }

    #endregion
}
