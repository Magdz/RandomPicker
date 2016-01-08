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
        private static bool DeleteOnPick = true;

        public static void AddPick(string Record)
        {
            PickingList.Add(Record);
        }

        public static string getPick(int index)
        {
            String Picked = PickingList[index].ToString();
            if (DeleteOnPick) PickingList.Remove(Picked);
            return Picked;
        }

        public static int getLength()
        {
            return PickingList.Count;
        }
    }
}
