using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA1070913.FastFoodStore.Customer
{
    class Customer
    {
        private string name;
        public string Name
        {
            get { return this.name; }
        }

        public Customer(string name)
        {
            this.name = name;
        }

        public string BuyMeal(BaseStore store, int choice)
        {
            return string.Format("{0} 前往 {1} 點了：{2}"
                , this.name
                , store.Name
                , store.OrderMeal(choice));
        }

    }
}
