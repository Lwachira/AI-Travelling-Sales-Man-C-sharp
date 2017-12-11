using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravellingSalesman
{
    public class RouteGenome
    {
              
        public int[] DNA { get; set; }
        public double Length { get; set; }
        public int Fitness { get; set; }

        public RouteGenome(int [] dna, double length)
        {
            this.DNA = dna;
            this.Length = length;
        }
                

    }
}
