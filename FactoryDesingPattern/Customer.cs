using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesingPattern
{
    public interface ICustomer
    {
        decimal TotalBill();
    }

    public class Customer: ICustomer
    {
        public  decimal TotalBill()
        {
            return 10; // there is a some big claculation
        }


    }

    public class GoldCustomer : ICustomer
    {
        public decimal TotalBill()
        {
            return 20; // there is a some big claculation
        }
    }

    public class DiscountedCustomer: ICustomer
    {
        public  decimal TotalBill()
        {
            return 5;
        }
    }

    public class SpecialCustomer : ICustomer
    {
        public decimal TotalBill()
        {
            return 30;
        }
    }
}
