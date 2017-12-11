using System;
using System.Drawing;
using TheTravellingSalesman;
using System.Threading.Tasks;
using System.Threading;

namespace TheTravellingSalesman
{
    class Genetic_Algorithm
    {
        

        #region Variables
        public static int PopSize { get; set; }
        public static int CityCount { get; set; }
        public static Point[] CityPoints { get; set; }
        public static int GenCount { get; set; }
        public static int GenTotal { get; set; }
        public static double TotalLength { get; set; }
        public static int TotalFitness { get; set; }
        public static RouteGenome Best { get; set; }
        public static RouteGenome Worst { get; set; }
        public static ISelection Selection { get; set; }
        public static ICrossover Crossover { get; set; }
        public static IMutate Mutate { get; set; }
        public static int CrossoverPercent { get; set; }
        public static int MutatePercent { get; set; }
        public static int ElitePercent { get; set; }
        public RouteGenome[] currentGen;
        public int[] dna = new int [CityCount];
        Random randNum = new Random();
#endregion

        /// <summary>
        ///Main Loop to run (Epoch)
        /// </summary>
        public void Begin()
        {           
            RouteGenome[] nextGen = new RouteGenome[PopSize];
            double totalLength = 0;
           
            
            for (int c = 0; c < PopSize; c++)
            {
                //creation of initial population
                CreateGenome();
                //calculating length
                double length = CalcLength(dna, CityPoints);
                nextGen[c] = new RouteGenome(dna, length);
                //including the length to the total length
                totalLength += length;

            }           
            //determining total length of all the genomes combined
            TotalLength = totalLength;  
          
            int totalFit = 0;
            //Loop to calculate the genomes fitness and total fitness of the generation
            for (int i = 0; i < PopSize; i++)
            {
                //Makes it fucking fast
                nextGen[i].Fitness = CalcFitness(nextGen[i].Length/10, TotalLength/10);
                totalFit += nextGen[i].Fitness;
            }
            TotalFitness = totalFit ;

            //The genomes are in order from best to worst, 
            //therefore genome at index 0 would be the most fit 
            //and the genome at the last index will be the least fit
            Sort(nextGen);            
            Best = nextGen[0];
            Worst = nextGen[PopSize - 1];
                    
            //Continuing to the next generation count
            GenCount++;     
                 
            //setting current gen to the newly generated next gen
            currentGen = nextGen;
          

        }

        #region Genome Creation and Breeding
        /// <summary>
        /// Method to Generate initial genomes
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public void CreateGenome()
        {
            dna = new int[CityCount];
            bool newDna;
            int city = 0;
            
                for (int i = 0; i < CityCount; i++)
                {
                    //avoid repitition
                    newDna = false;
                    while (!newDna)
                    {
                        newDna = true;
                        //generating a random city/gene to add to the dna/genome
                        city = randNum.Next(0,CityCount);

                        for (int j = 0; j < i; j++)
                        {
                            if (dna[j] == city)
                            {
                                newDna = false;
                                break;
                            }
                        }
                    }
                    //adding the city to the dna/genome
                    dna[i] = city;
                }
             
            }                   
        
        //Creating the next generation
        public void NextGeneration()
        {
            
            int maxElite = 0;
            RouteGenome[] nextGen = new RouteGenome[PopSize];

            //Determining if elite percentage is active
            if (ElitePercent > 0)
            {
                maxElite = (PopSize * ElitePercent) / 100;
            }
            else
                 maxElite = (PopSize) / 100;


            double totalLength = 0;
            double length = 0;
           
            //making copies of the elites based on the percentage chosen by user
            for (int c = 0; c < maxElite; c++)
            {
                nextGen[c] = currentGen[c];
                totalLength += nextGen[c].Length;
            }

            //creating the rest of the next generation
            for (int i = maxElite; i < PopSize; i++)
            {
                 //Selection
                RouteGenome parent1 = Selection.Select(currentGen, TotalFitness);
                RouteGenome parent2 = Selection.Select(currentGen, TotalFitness);
                //to avoid two of the same parents
                while (parent2.DNA == parent1.DNA)
                {
                     parent2 = Selection.Select(currentGen, TotalFitness);
                }

                //Crossover
                RouteGenome child = Crossover.Crossover(parent1, parent2, CrossoverPercent);

                //Mutate
                child = Mutate.Mutate(child, MutatePercent);

                //calculation of new genomes length
                length = CalcLength(child.DNA, CityPoints);
                child.Length = length;
                //saving the child to next generation
                nextGen[i] = child;
                totalLength += length;
            }

            TotalLength = totalLength;
            
            //Calculating the next generations fitness
            int totalFit = 0;
            for (int j = 0; j < PopSize; j++)
            {
                nextGen[j].Fitness = CalcFitness(nextGen[j].Length/5, totalLength/5);
                totalFit += nextGen[j].Fitness;
            }

            TotalFitness = totalFit;

            //The genomes are in order from best to worst, 
            //therefore genome at index 0 would be the most fit 
            //and the genome at the last index will be the least fit
            Sort(nextGen);
            Best = nextGen[0];
            Worst = nextGen[PopSize - 1];

            GenCount += 1;

           
          
            //Setting the current gen to next gen
            currentGen = nextGen;              
        }
        #endregion

        #region Genome Functions
        /// <summary>
        /// Method to sort Genomes by length
        /// This will put the best genomes at the lower indexes.
        /// making it easier to apply elitism and determine the current best genome.
        /// </summary>
        /// <param name="genome"></param>
        public void Sort(RouteGenome[] genome)
        {
            bool sorted = false;
            int c = genome.Length;

            while (!sorted)
            {
                sorted = true;

                for (int i = 1; i < c; i++)
                {
                    if (genome[i - 1].Length > genome[i].Length)
                    {
                        sorted = false;
                        RouteGenome tempGenome = genome[i - 1];
                        genome[i - 1] = genome[i];
                        genome[i] = tempGenome;
                    }
                }
                c--;

            }
        }


        //Method to calculate the genomes fitness.
        //Using the genome length devided by the generation total length
        public int CalcFitness(double length, double totalLength)
        {

            return (int)Math.Round(totalLength / length, 0);
        }

        /// <summary>
        /// Calculate the length of the line
        /// between 2 cities
        /// </summary>
        /// <param name="dna"></param>
        /// <param name="cityPoints"></param>
        /// <returns></returns>
        public double CalcLength(int[] dna, Point[] cityPoints)
        {
            double length = 0;

            for (int i = 1; i < dna.Length; i++)
            {
                //using the distance pythagoras theorem
                length += CalcDistance(cityPoints[dna[i - 1]], cityPoints[dna[i]]);
            }

            length += CalcDistance(cityPoints[dna[dna.Length - 1]], cityPoints[dna[0]]);
            return length;

        }

        /// <summary>
        /// Calculate the Distance between 2 city points
        /// using Pythagoras theorem
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public double CalcDistance(Point point1, Point point2)
        {

            int X = Math.Abs(point1.X - point2.X);
            int Y= Math.Abs(point1.Y - point2.Y);
            return Math.Sqrt(X * X + Y * Y);
        }
        #endregion
    }
}
