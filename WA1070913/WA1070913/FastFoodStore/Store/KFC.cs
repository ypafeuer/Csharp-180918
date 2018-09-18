using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA1070913.FastFoodStore.Store
{
    class KFC : BaseStore
    {
        public KFC() : base("肯德基")
        { }

        public override string OrderMeal(int choice)
        {
            string a = "";
            switch (choice)
            {
                case 1: a = "卡拉雞腿堡"; break;
                case 2: a = "全家餐"; break;
                case 3: a = "蛋塔"; break;
                case 4: a = "上校雞塊"; break;
                default: a = "無此選項！"; break;
            }
            return a;
        }
    }
}