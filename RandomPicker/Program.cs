using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPicker
{
    class Program
    {
        private static ArrayList PickingList = new ArrayList();

        public static void AddPick(String Record)
        {
            PickingList.Add(Record);
        }
    }
}
