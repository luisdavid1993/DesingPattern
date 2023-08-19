using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracFactoryPattern
{
    //Holiday Discount
    //Sat and Sunday Discount
    //No Tax
    //Local Tax
    //State Tax
    //Hand delivery
    //Courier (Mensajero)
    public interface ICustomer
    {
        decimal TotalBill();
    }

    public interface ICorporateType
    {
        decimal CalculateCredit();
    }

    public interface IDiscount
    {
        decimal Calculate();
    }
    public interface ITax
    {
        decimal Calculate();
    }
    public interface IDelivery
    {
        decimal Calculate();
    }



    public class PropCorporate : ICorporateType
    {
        public decimal CalculateCredit()
        {
            return 6;
        }
    }

    public class PublicCorporate : ICorporateType
    {
        public decimal CalculateCredit()
        {
            return 5;
        }
    }

    public class HolidayDiscount : IDiscount
    {
        public decimal Calculate()
        {
            return 5;
        }
    }
    public class WeeklyDiscount : IDiscount
    {
        public decimal Calculate()
        {
            return 4;
        }
    }
    public class NoTax : ITax
    {
        public decimal Calculate()
        {
            return 0;
        }
    }
    public class LocalTax : ITax
    {
        public decimal Calculate()
        {
            return 2;
        }
    }
    public class StateTax : ITax
    {
        public decimal Calculate()
        {
            return 1;
        }
    }
    public class HandDelivery : IDelivery
    {
        public decimal Calculate()
        {
            return 2;
        }
    }
    public class Courier : IDelivery
    {
        public decimal Calculate()
        {
            return 3;
        }
    }

    public class Customer : ICustomer
    {
        private decimal TotalPurchase { get; }
        private IDiscount _discount;
        private ITax _tax;
        private IDelivery _delivery;

        public Customer(IDiscount discount, ITax tax, IDelivery delivery)
        {
            this._tax = tax;
            this._discount = discount;
            this._delivery = delivery;
        }
        public virtual decimal TotalBill()
        {
            return TotalPurchase + 
                   _tax.Calculate() + 
                   _delivery.Calculate() -
                   _discount.Calculate(); // there is a some big claculation
        }


    }

    public class CorporateCustomer : Customer
    {

        private ICorporateType _corporate;
        public CorporateCustomer(IDiscount discount, 
                                 ITax tax, 
                                 IDelivery delivery,
                                 ICorporateType corporateType) : base(discount, tax, delivery)
        {
         this._corporate = corporateType;
        }

        public override decimal TotalBill()
        {
            return base.TotalBill() - _corporate.CalculateCredit();
        }
    }
}
