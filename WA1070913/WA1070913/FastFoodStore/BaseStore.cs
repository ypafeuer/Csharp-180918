using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA1070913.FastFoodStore
{
    abstract class BaseStore : IStore
    {
        private string name;
        public string Name
        {
            get { return this.name; }
        }

        public BaseStore(string name)
        {
            this.name = name;
        }

        public abstract string OrderMeal(int choice);        
    }
}
