using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTravellingSalesman;

namespace TheTravellingSalesman
{
    public interface ICrossover
    {
        RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance);
    }


    public class OrderBasedCrossover : ICrossover
    {

        public RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance)
        {
            int[] p1 = parent1.DNA;
            int[] p2 = parent2.DNA;
            int[] c1 = new int[p1.Length];

           

            int percentage = new Random().Next(0, 100);

            int y = 0;

            int index1 = new Random().Next(0, parent1.DNA.Length / 3);
            int index2 = new Random().Next((parent1.DNA.Length / 3), (parent1.DNA.Length / 3) + (parent1.DNA.Length / 3));
            int index3 = new Random().Next((p1.Length / 3) + (p1.Length / 3), p1.Length);


            if (crossoverChance > percentage)
            {

              

                int point1 = p1[index1];
                int point2 = p1[index2];
                int point3 = p1[index3];

                int[] points = { point1, point2, point3 };

                for (int f = 0; f < p1.Length; f++)
                {
                    if (p2[f] == point1 || p2[f] == point2 || p2[f] == point3)
                    {
                        c1[f] = points[y];
                        y++;
                    }
                    else
                    {
                        c1[f] = p2[f];
                    }
                }

                return new RouteGenome(c1, 0);
            }


            return parent1;



        }


    }



    public class PartiallyMappedCross : ICrossover
    {

        /// <summary>
        /// Inspiration for this code comes from this paper http://www.ceng.metu.edu.tr/~ucoluk/research/publications/tsp.pdf
        /// 
        /// </summary>
        /// <param name="parent1"></param>
        /// <param name="parent2"></param>
        /// <param name="crossoverChance"></param>
        /// <returns></returns>
        public RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance)
        {
            Random rand = new Random();
            int[] dna = new int[parent1.DNA.Length];
            int[] mapper = new int[parent1.DNA.Length + 1];
            int crossPoint1 = rand.Next(1, parent1.DNA.Length - 2);
            int crossPoint2 = rand.Next(1, parent1.DNA.Length - 2);
            parent1.DNA.CopyTo(dna, 0); // Copies everything to the child
            int percentage = rand.Next(0, 100);

            if (crossoverChance > percentage)
            {
                int randPoint = rand.Next(parent1.DNA.Length);

                for (int i = 0; i < dna.Length; i++)
                {
                    mapper[dna[i]] = i;
                }

                if (crossPoint1 > crossPoint2)
                {
                    int temp = crossPoint1;
                    crossPoint1 = crossPoint2;
                    crossPoint2 = temp;
                }


                for (int i = crossPoint1; i <= crossPoint2; i++)
                {
                    int parentValues = parent2.DNA[i];
                    //swap the dna in the child
                    int t = dna[mapper[parentValues]];
                    dna[mapper[parentValues]] = dna[i];
                    dna[i] = t;

                    //swap the points in the map
                    t = mapper[dna[mapper[parentValues]]];
                    mapper[dna[mapper[parentValues]]] = mapper[dna[i]];
                    mapper[dna[i]] = t;
                }



                //Completing the new generation by filling in the blanks
                for (int c = randPoint; c < dna.Length; c++)
                {
                    for (int d = 0; d < dna.Length; d++)
                    {
                        bool newGenome = true;

                        for (int e = 0; e < c; e++)
                        {
                            //To avoid city repetition
                            if (parent2.DNA[d] == dna[e])
                            {
                                newGenome = false;

                            }
                        }

                        //If the character is not already in the array
                        //it adds the character from parent 2
                        if (newGenome)
                        {
                            dna[c] = parent2.DNA[d];
                        }

                    }

                }
                return new RouteGenome(dna, 0);
            }
            //   RouteGenome child = new RouteGenome(dna,0);


            return parent1;
        }

    }



    public class RandomPointCrossover : ICrossover
    {

        public RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance)
        {
            Random random = new Random();
            //random percentage to determine if crossover is necessary
            int percentage = random.Next(0, 100);


            if (crossoverChance > percentage)
            {
                //Selecting a random point to work with
                int randPoint = random.Next(parent1.DNA.Length);
                int[] dna = new int[parent1.DNA.Length];

                //using parent 1 to add to the new generation
                //up to the random point
                for (int i = 0; i < randPoint; i++)
                {
                    dna[i] = parent1.DNA[i];
                }


                //Completing the new generation by filling in the blanks
                for (int c = randPoint; c < dna.Length; c++)
                {
                    for (int d = 0; d < dna.Length; d++)
                    {
                        bool newGenome = true;

                        for (int e = 0; e < c; e++)
                        {
                            //To avoid city repetition
                            if (parent2.DNA[d] == dna[e])
                            {
                                newGenome = false;

                            }
                        }

                        //If the character is not already in the array
                        //it adds the character from parent 2
                        if (newGenome)
                        {
                            dna[c] = parent2.DNA[d];
                        }

                    }

                }
                return new RouteGenome(dna, 0);

            }

            return parent1;


        }

    }

    public class SinglePointInversionCrossover : ICrossover
    {

        public RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance)
        {

            //random percentage to determine if crossover is necessary
            int percentage = new Random().Next(0, 100);

            if (crossoverChance > percentage)
            {
                //Selecting a random point to work with
                int randPoint = new Random().Next(parent1.DNA.Length);
                int[] dna = new int[parent1.DNA.Length];
                int index = 0;

                //using parent 1 to add to the new generation
                //up to the random point in reverse order
                for (int i = randPoint; i > -1; i--)
                {
                    dna[index] = parent1.DNA[i];
                    index++;
                }

                //Completing the new generation by filling in the blanks
                for (int c = randPoint; c < dna.Length; c++)
                {
                    for (int d = 0; d < dna.Length; d++)
                    {
                        bool newGenome = true;

                        for (int e = 0; e < c; e++)
                        {
                            //To avoid city repetition
                            if (parent2.DNA[d] == dna[e])
                            {
                                newGenome = false;

                            }
                        }

                        //If the character is not already in the array
                        //it adds the character from parent 2
                        if (newGenome)
                        {
                            dna[c] = parent2.DNA[d];
                            d = dna.Length;
                        }

                    }

                }
                return new RouteGenome(dna, 0);

            }

            return parent1;

        }

    }


    public class TwoPointInversionCrossover : ICrossover
    {



        /// <summary>
        /// Old Version
        /// </summary>
        /// <param name="parent1"></param>
        /// <param name="parent2"></param>
        /// <param name="crossoverChance"></param>
        /// <returns></returns>
        public RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance)
        {
            Random random = new Random();
            //random percentage to determine if crossover is necessary
            int percentage = new Random().Next(0, 100);
            //Selecting a random point to work with
            int randPoint1 = random.Next(0, parent1.DNA.Length / 2);
            int randPoint2 = random.Next(parent1.DNA.Length / 2, parent1.DNA.Length);
            int[] dna = new int[parent1.DNA.Length];
            int index = 0;

            if (crossoverChance > percentage)
            {
                //using parent 2 to add to the new generation
                //from the random point in reverse order
                for (int i = randPoint1; i >= 0; i--)
                {
                    dna[index] = parent2.DNA[i];
                    index++;
                }

                //Adding parent 2 to the new genome from point 2 till the end of the genome
                for (int i = randPoint2; i < parent1.DNA.Length; i++)
                {
                    dna[i] = parent2.DNA[i];

                }

                //Completing the new generation by filling in the blanks
                for (int c = randPoint1; c < dna.Length; c++)
                {
                    for (int d = 0; d < dna.Length; d++)
                    {
                        bool newGenome = true;

                        for (int e = 0; e < dna.Length; e++)
                        {
                            //To avoid city repetition
                            if (parent1.DNA[d] == dna[e])
                            {
                                newGenome = false;

                            }
                        }

                        //If the character is not already in the array
                        //it adds the character from parent 2
                        if (newGenome)
                        {
                            dna[c] = parent1.DNA[d];
                            d = dna.Length;
                        }

                    }

                }

                return new RouteGenome(dna, 0);

            }

            return parent1;


        }

    }



    public class New_RandomPointCrossover : ICrossover
    {

        Random random = new Random();
        int parentSelected = 1, percentage;
        public RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance)
        {
            percentage = random.Next(0, 100);
            //random percentage to determine if crossover is necessary
            if (percentage <= crossoverChance)
            {
                parentSelected = random.Next(1, 3);
                //Selecting a random point to work with
                int randPoint = random.Next(parent1.DNA.Length);
                int[] dna = new int[parent1.DNA.Length];
                //using parent 1 to add to the new generation
                //up to the random point
                for (int i = 0; i < randPoint; i++)
                {
                    if (parentSelected == 1)
                        dna[i] = parent1.DNA[i];
                    else
                        dna[i] = parent2.DNA[i];
                }
                //Completing the new generation by filling in the blanks
                if (parentSelected == 1)
                    dna = FillInGaps(dna, parent2, randPoint);
                else
                    dna = FillInGaps(dna, parent1, randPoint);
                return new RouteGenome(dna, 0);

            }

            return parent1;


        }

        int[] FillInGaps(int[] DNA, RouteGenome parent, int randomPoint)
        {
            int[] dna = DNA;
            for (int c = randomPoint; c < dna.Length; c++) //New dna position
            {
                for (int d = 0; d < dna.Length; d++)//Parent 2 position
                {
                    bool newGenome = true;

                    for (int e = 0; e < c; e++)//Check new dna previous numbers to get fresh number(If parent 2 has old numbers = newGenome is flase)
                    {
                        //To avoid city repetition
                        if (dna[e] == parent.DNA[d])
                        {
                            newGenome = false;

                        }
                    }
                    //If the character is not already in the array
                    //it adds the character from parent 2
                    if (newGenome)
                    {
                        dna[c] = parent.DNA[d];
                    }

                }

            }
            return dna;
        }
    }




    public class New_SinglePointInversionCrossover : ICrossover
    {
        Random random = new Random();
        int percentage;
        int randPoint = 0;
        int index = 0;
        int[] dna;
        int parentSelected = 1;
        public RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance)
        {
            //random percentage to determine if crossover is necessary
            percentage = random.Next(0, 100);

            if (percentage <= crossoverChance)
            {
                parentSelected = random.Next(1, 3);
                //Selecting a random point to work with
                randPoint = random.Next(parent1.DNA.Length);
                dna = new int[parent1.DNA.Length];
                index = 0;
                //using parent 1 to add to the new generation
                //up to the random point in reverse order
                for (int i = randPoint; i > -1; i--)
                {
                    if (parentSelected == 1)
                        dna[index] = parent1.DNA[i];
                    else
                        dna[index] = parent2.DNA[i];
                    index++;
                }
                //Completing the new generation by filling in the blanks
                if (parentSelected == 1)
                    dna = FillInGaps(dna, parent2, randPoint);
                else
                    dna = FillInGaps(dna, parent1, randPoint);
                return new RouteGenome(dna, 0);
            }
            return parent1;

        }
        int[] FillInGaps(int[] DNA, RouteGenome parent, int randomPoint)
        {
            int[] dna = DNA;
            for (int c = randomPoint + 1; c < dna.Length; c++)
            {
                for (int d = 0; d < dna.Length; d++)
                {
                    bool newGenome = true;

                    for (int e = 0; e <= c; e++)
                    {
                        //To avoid city repetition
                        if (parent.DNA[d] == dna[e])
                        {
                            newGenome = false;
                        }
                    }
                    //If the character is not already in the array
                    //it adds the character from parent 2
                    if (newGenome)
                    {
                        dna[c] = parent.DNA[d];
                        d = dna.Length;
                    }

                }

            }
            return dna;
        }
    }



    public class New_TwoPointInversionCrossover : ICrossover
    {

        Random random = new Random();
        int randPoint1, randPoint2, index, parentSelected = 1, percentage;
        int[] dna;
        public RouteGenome Crossover(RouteGenome parent1, RouteGenome parent2, int crossoverChance)
        {
            //random percentage to determine if crossover is necessary
            percentage = random.Next(0, 100);

            if (crossoverChance > percentage)
            {
                parentSelected = random.Next(1, 3);
                //Selecting a random point to work with
                randPoint1 = random.Next(0, parent1.DNA.Length / 2);
                randPoint2 = random.Next(parent1.DNA.Length / 2, parent1.DNA.Length);
                dna = new int[parent1.DNA.Length];
                index = randPoint1;

                //using parent 2 to add to the new generation
                //from the random point in reverse order
                for (int i = randPoint2; i >= randPoint1; i--)
                {
                    if (parentSelected == 1)
                        dna[index] = parent2.DNA[i];
                    else
                        dna[index] = parent1.DNA[i];
                    index++;
                }
                //Completing the new generation by filling in the blanks
                if (parentSelected == 1)
                {
                    dna = FillInGaps(dna, parent1, 0, randPoint1, randPoint2);
                    dna = FillInGaps(dna, parent1, randPoint2, dna.Length, dna.Length);
                }
                else
                {
                    dna = FillInGaps(dna, parent2, 0, randPoint1, randPoint2);
                    dna = FillInGaps(dna, parent2, randPoint2, dna.Length, dna.Length);
                }
                return new RouteGenome(dna, 0);
            }
            return parent1;
        }

        int[] FillInGaps(int[] DNA, RouteGenome parent, int start, int end, int maxRange)
        {
            int[] dna = DNA;
            for (int c = start; c < end; c++)
            {
                for (int d = 0; d < dna.Length; d++)
                {
                    bool newGenome = true;

                    for (int e = 0; e < maxRange; e++)
                    {
                        //To avoid city repetition
                        if (parent.DNA[d] == dna[e])
                        {
                            newGenome = false;
                        }
                    }
                    //If the character is not already in the array
                    //it adds the character from parent 2
                    if (newGenome)
                    {
                        dna[c] = parent.DNA[d];
                        d = dna.Length;
                    }
                }
            }
            return dna;
        }
    }


}





