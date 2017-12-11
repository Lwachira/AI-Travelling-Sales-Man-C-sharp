using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravellingSalesman
{
    public interface IMutate
    {
        RouteGenome Mutate(RouteGenome genome, int mutateChance);
    }

    //Complete working mutation
    public class RandomPointMutation : IMutate
    {
        public RouteGenome Mutate(RouteGenome genome, int mutateChance)
        {
            int percentage = new Random().Next(0, 100);
            Random ran = new Random();

            if (mutateChance > percentage)
            {
                //Selecting 2 random positions to swop
                int pos1 = ran.Next(0, genome.DNA.Length);
                int pos2 = ran.Next(0, genome.DNA.Length);

                //Swopping gene positions
                int tempPos = genome.DNA[pos1];
                genome.DNA[pos1] = genome.DNA[pos2];
                genome.DNA[pos2] = tempPos;
            }

            return genome;
        }
    }

    public class DisplacementMutation : IMutate
    {
        //Complete working mutation
        public RouteGenome Mutate(RouteGenome genome, int mutateChance)
        {

            Random ran = new Random();
            int[] dna = genome.DNA;
            int[] child = new int[dna.Length];
            int point1 = ran.Next(2, genome.DNA.Length / 2);
            int point2 = ran.Next(point1 + 1, dna.Length);

            int index = point1;

            int percent = new Random().Next(100);

            if (mutateChance > percent)
            {
                //moving the selected genes to the beginning of the genome
                for (int c = 0; c < point2 - point1; c++)
                {
                    child[c] = dna[index];
                    index++;
                }
                index = 0;
                //adding the missing genomes to the child from where the child ended
                for (int i = point2 - point1; i < point2; i++)
                {
                    child[i] = dna[index];
                    index++;
                }
                //filling in the genome from the 2nd position till the end
                for (int j = point2; j < dna.Length; j++)
                {
                    child[j] = dna[j];
                }
                genome.DNA = child;

            }
            return genome;
        }
    }

    public class InversionDisplacementMutation : IMutate
    {

        public RouteGenome Mutate(RouteGenome genome, int mutateChance)
        {
            Random ran = new Random();
            int[] dna = genome.DNA;
            int[] child = new int[dna.Length];

            //Selecting 2 points 
            int point1 = ran.Next(1, genome.DNA.Length / 2);
            int point2 = ran.Next(point1 + 1, dna.Length);
            int index = point1;


            int percent = new Random().Next(100);

            if (mutateChance > percent)
            {

                //Inverting the genes
                for (int c = point2; c > point1; c--)
                {
                    child[index] = dna[c];
                    index++;
                }

                for (int i = point1; i >= 0; i--)
                {
                    child[i] = dna[i];

                }
                //completing the genome with the left over genes
                for (int j = point2; j < dna.Length; j++)
                {
                    child[j] = dna[j];

                }
                genome.DNA = child;

            }
            return genome;
        }


    }


    /// <summary>
    /// Inspired by last years group Athi & Aya
    /// Removed some unneeded complexity 
    /// They made a few mistakes that caused theres tsp to crap out before 300 generations
    /// 
    /// </summary>
    public class InversionMutation : IMutate
    {
        public RouteGenome Mutate(RouteGenome genome, int mutateChance)
        {
            int[] array1 = genome.DNA;

            Random ran = new Random();

            int point1 = ran.Next(1, array1.Length - 1);



            int point2 = point1;


            int max = Math.Max(point1, point2);
            int min = Math.Min(point2, point1);

            int middle = 0;
            int afterCounter = 0;
            int middleCounter = 0;
            int beforeCounter = min;
            int[] swappedArray = new int[array1.Length];

            int percent = new Random().Next(100);

            if (mutateChance > percent)
            {
                for (int i = min; i <= max; i++)
                {
                    middle++;
                }

                int[] beforeArray = new int[middle];
                int[] afterArray = new int[middle];


                for (int i = 0; i < beforeArray.Length; i++)
                {
                    //Invert the genes before
                    beforeArray[i] = array1[beforeCounter];
                    beforeCounter++;
                }



                for (int e = beforeArray.Length; e > 0; e--)
                {
                    //Invert the genes After
                    afterArray[afterCounter] = beforeArray[e - 1];
                    afterCounter++;
                }


                for (int w = 0; w < array1.Length; w++)
                {
                    //Complies the genes in correct sequence
                    if (w >= min && w <= max)
                    {
                        swappedArray[w] = afterArray[middleCounter];
                        middleCounter++;
                    }
                    else
                    {
                        swappedArray[w] = array1[w];
                    }

                }
                genome.DNA = swappedArray;

            }



            return genome;
        }
    }

    /// <summary>
    /// Inspired by last years group Athi & Aya
    /// Removed some unneeded complexity 
    /// They made a few mistakes that caused theres tsp to crap out before 300 generations
    /// Adding the if statement makes it super fast
    /// </summary>
    public class ScrumbledMutation : IMutate
    {

        public RouteGenome Mutate(RouteGenome genome, int mutateChance)
        {
            int[] myArray = genome.DNA;
            int[] newArray = new int[myArray.Length];
            int pos1, pos2;

            Random random = new Random();

            pos1 = random.Next(1, genome.DNA.Length - 1);

            pos2 = pos1;


            int[] middle = new int[pos2 - pos1];

            int[] left = new int[pos1];
            int[] right = new int[myArray.Length - pos2];

            int[] holder = new int[myArray.Length];

            int count = 0;

            int[] storeRand = new int[myArray.Length];

            if (mutateChance > new Random().Next(100))
            {
                for (int x = pos1; x < pos2; x++)
                {
                    middle[count] = myArray[x];
                    count++;
                }

                for (int v = 0; v < pos1; v++)
                {
                    storeRand[v] = myArray[v];

                }

                var rnd = new Random();

                for (int i = 0; i < middle.Length; ++i)
                {
                    int index = rnd.Next(middle.Length);
                    // swap
                    int temp = middle[index];
                    middle[index] = middle[i];
                    middle[i] = temp;


                }


                int counter = 0;

                for (int p1 = pos1; p1 < middle.Length + pos1; p1++)
                {
                    storeRand[p1] = middle[counter];
                    counter++;
                }

                for (int p2 = pos2; p2 < myArray.Length; p2++)
                {
                    storeRand[p2] = myArray[p2];
                }

                genome.DNA = storeRand;
            }



            return genome;

        }


    }



    public class InsertionMutation : IMutate
    {
        public RouteGenome Mutate(RouteGenome genome, int mutateChance)
        {
            Random ran = new Random();
            int[] dna = genome.DNA;
            int[] child = new int[dna.Length];
            int point1, point2 = 0;
            do
            {
                point1 = ran.Next(0, genome.DNA.Length / 2);
                point2 = ran.Next(point1 + 1, dna.Length);
            } while (point1 == point2);
            if (point2 == point1)
            {
                point2 = ran.Next(point1 + 1, dna.Length);
            }
            int temp = 0;
            temp = dna[point1];
            int percent = new Random().Next(100);
            if (mutateChance > percent)
            {
                for (int i = 0; i < dna.Length; i++)
                {
                    child[i] = dna[i];
                }
                for (int i = point1; i < point2; i++)
                {
                    child[i] = dna[i + 1];
                }
                child[point2] = temp;
                genome.DNA = child;
            }
            return genome;
        }
    }
}


