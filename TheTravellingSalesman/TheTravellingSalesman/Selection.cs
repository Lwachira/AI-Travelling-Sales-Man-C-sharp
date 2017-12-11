using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TheTravellingSalesman
{
    
    //Selection interface. Encapsulating the different selection behaviours
    public interface ISelection
    {
        RouteGenome Select(RouteGenome[] genome, int totalFitness);
    }


    //Tournament Selection
    public class TournamentSelection : ISelection
    {
        Random ranNum = new Random();

        public RouteGenome Select(RouteGenome[] genome, int length)
        {
            //Random number to between 0 and genome length
            int count = ranNum.Next(0, genome.Length);
            RouteGenome best = genome[0];
            int selected = 0;

            for (int i = 0; i < count; i++)
            {
                //Comparing the current genome with the best genomes length
                //if greater, this genome will be selected
                //within the for loop. Different genomes may trigger this 
                //if statement and therefore win the fight and become the "stronger" genome.
                if (genome[i].Length > best.Length)
                    selected = i;
                best = genome[i];
            }

            return genome[selected];
        }
    }


    //RouletteWheel Selection method
    public class RouletteWheelSelection : ISelection
    {
        Random ranFit = new Random();

        public RouteGenome Select(RouteGenome[] genome, int totalFitness)
        {
            int pos = 0;
            //generating a random fitness
            int randomFitness = ranFit.Next(0, totalFitness);

            while (randomFitness >= 0 && pos < genome.Length)
            {
                //removing the current genome fitness from random fitness
                randomFitness -= genome[pos].Fitness;

                //if fitness is less than 0 after the last loop
                //return the last genome that made random fitness 0
                if (randomFitness < 0)
                {

                    return genome[pos];
                }
                //increasing the position every time loop reaches the end
                pos++;
            }

            return genome[genome.Length - 1];
        }
    }


    //SUS Selection method
    public class StochasticUniversalSamplingSelection : ISelection
    {
        Random ranFit = new Random();

        public RouteGenome Select(RouteGenome[] genome, int totalFitness)
        {
            int pos = 0;
            int randomFitness = ranFit.Next(0, totalFitness);

            while (randomFitness >= 0 && pos < genome.Length)
            {
                randomFitness -= genome.Length;

                if (randomFitness < 0)
                    return genome[pos];

                pos++;
            }

            return genome[genome.Length - 1];
        }
    }
}
