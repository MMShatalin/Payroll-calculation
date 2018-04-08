using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Расчет_зарплаты
{
    [Serializable]
    class Sum_Dinner
    {
        public double MyNewDineer;
        public List<double> MyDinners;
        

        public Sum_Dinner()
        {
            MyDinners = new List<double>();         
        }

    }
}
