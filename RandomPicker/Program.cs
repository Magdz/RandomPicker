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

        public static List<String> OriginalList { get; private set; } = new List<String>();

        public static List<String> PickingList { get; private set; }= new List<String>();

        private static bool DeleteOnPick = true;

        public static void deleteList()
        {
            PickingList.Clear();
            OriginalList.Clear();
        }
        public static void AddPick(string Record)
        {
            PickingList.Add(Record);
            OriginalList.Add(Record);
        }

        public static string getPick(int index)
        {
            String Picked = PickingList[index].ToString();
            if (DeleteOnPick) PickingList.Remove(Picked);
            return Picked;
        }

        public static void setPickingList()
        {
            PickingList.AddRange(OriginalList);
        }

        public static int getLength()
        {
            return PickingList.Count;
        }
    }
}
