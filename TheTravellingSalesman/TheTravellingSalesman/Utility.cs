using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravellingSalesman
{

    /// <summary>
    /// Credits goes to : https://github.com/nsadawi/GeneticAlgorithm/blob/master/src/Utility.java
    /// 
    /// </summary>
    public class Utility
    {

        public static bool ArrayContains(int []arr ,int e)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == e)
                {
                    return true;
                }
            }
            return false;
        }

        public static void rotate(int []arr, int order)
        {
            int offset = arr.Length - order % arr.Length;
            if (offset  > 0)
            {
                int [] copy = (int[])arr.Clone();
                for (int i = 0; i < arr.Length; i++)
                {
                    int j = (i + offset) % arr.Length;
                    arr[i] = copy[j];
                }
            }
        }
    }
}
