using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA1070913.FastFoodStore.Store
{
    class Mcdonalds : BaseStore
    {
        public Mcdonalds():base("麥當勞")
        { }

        public override string OrderMeal(int choice)
        {
            string a = "";
            switch (choice)
            {
                case 1: a = "大麥克"; break;
                case 2: a = "麥香雞"; break;
                case 3: a = "麥香魚"; break;
                case 4: a = "勁辣雞腿堡"; break;
                default: a = "無此選項！"; break;
            }
            return a;
        }
    }
}
