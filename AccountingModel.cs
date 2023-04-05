using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        public AccountingModel()
        {
            price = 0;
            nightsCount = 1;
            discount = 0;
            total = 0;
        }

        private double price;
        private int nightsCount;
        private double discount;
        private double total;

        public double Price
        {
            get { return price; }
            set 
            {
                if (value < 0) throw new ArgumentException();
                price = value;
                Notify(nameof(Price));
                total = price * nightsCount * (1 - discount / 100);
                Notify(nameof(Total));
            }
        }

        public int NightsCount
        {
            get { return nightsCount; }
            set 
            {
                if (value <= 0) throw new ArgumentException();
                nightsCount = value;
                Notify(nameof(NightsCount));
                total = price * nightsCount * (1 - discount / 100);
                Notify(nameof(Total));
            }
        }

        public double Discount
        {
            get { return discount; }
            set 
            {
                if (value > 100) throw new ArgumentException();
                discount = value;
                Notify(nameof(Discount));
                total = price * nightsCount * (1 - discount / 100);
                Notify(nameof(Total));
            }
        }

        public double Total
        {
            get { return total; }
            set 
            {
                if (value < 0) throw new ArgumentException();
                total = value;
                Notify(nameof(Total));
                discount = (1 - total / (price * nightsCount)) * 100;
                Notify(nameof(Discount));
            }  
        }
    }
}
