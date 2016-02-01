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

        public static void deletePick(String item)
        {
            PickingList.Remove(item);
            OriginalList.Remove(item);
        }

        public static string getPick()
        {
            Shuffle();
            String Picked = PickingList[0].ToString();
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

        private static void Shuffle()
        {
            for (int i = 0; i < PickingList.Count; ++i)
            {
                int Key = new Random().Next(i + 1);
                String Temp = PickingList[i];
                PickingList[i] = PickingList[Key];
                PickingList[Key] = Temp;
            }
        }
    }
}
