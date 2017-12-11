using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TheTravellingSalesman
{
    public partial class TSPForm : Form
    {        
        private Genetic_Algorithm GA;
        private int sizeOfPoint = 3;    
        private int margin = 3;
        private bool paused;
        private bool nextGen;
        private bool randomCities = true;
        private bool stop;
        private string file = "50CityList.txt";
        private int desiredDistance = 0;
        StreamWriter writer;
        private Random random = new Random();
        int numCities;


        public TSPForm()
        {

            InitializeComponent();
            
            //Default settings
            Genetic_Algorithm.PopSize = 200;
            Genetic_Algorithm.CrossoverPercent = 70;
            Genetic_Algorithm.MutatePercent = 7;
            Genetic_Algorithm.GenTotal = 500;
            Genetic_Algorithm.ElitePercent = 2;
            Genetic_Algorithm.CityCount = 20;           
            Genetic_Algorithm.Selection = new RouletteWheelSelection();
            Genetic_Algorithm.Crossover = new RandomPointCrossover();
            Genetic_Algorithm.Mutate = new RandomPointMutation();
            desiredDistance = 625;                       
            GA = new Genetic_Algorithm();
           
        

        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
            Point[] cityPoints = new Point[Genetic_Algorithm.CityCount];
          
            if (!randomCities)
            {
                try
                {
                    //loading cities from file
                    LoadCities(file);
                    Genetic_Algorithm.CityCount = numCities;
                    pb1.Invalidate();
                    paused = false;
                }
                catch (Exception ex)
                {

                    
                }
                
            }

            else
            {
                Genetic_Algorithm.CityCount = int.Parse(tbCityNum.Text);
                cityPoints = new Point[Genetic_Algorithm.CityCount];
                int randNum;                
                
                for (int i = 0; i < Genetic_Algorithm.CityCount; i++)
                {
                    //creating random city points
                    cityPoints[i] = new Point(randNum=random.Next(margin, pb1.ClientSize.Width - margin), randNum = random.Next(margin, pb1.ClientSize.Height - margin) + DateTime.Today.Millisecond * DateTime.Today.Millisecond + 50);
                    
                }
                Genetic_Algorithm.CityPoints = cityPoints;
                pb1.Invalidate();
               
            }
       
        }


        private void btnStart_Click(object sender, EventArgs e)
        {

            try
            {
                Genetic_Algorithm.GenCount = 0;
                Genetic_Algorithm.TotalFitness = 0;
                Genetic_Algorithm.Best = null;
                //the start of the genetic algorithm
                Task.Factory.StartNew(() => Display());
                writer = new StreamWriter("TheRoute.txt");

                
            }
            catch (Exception)
            {
              
               
                
            }
         
              
            
           
          
         

        }
       
        //Reading and loading cities from file
        private void LoadCities(string fileName)
        {
            List<Point> points = new List<Point>();
           
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    //reading cities from file and saving them to memory
                    string[] readLine = reader.ReadLine().Split(',');
                    points.Add(new Point(int.Parse(readLine[1])*2  , int.Parse(readLine[2]) *2));
                    numCities = int.Parse(readLine[0]);
                }
                
            }
            Genetic_Algorithm.CityPoints = points.ToArray();
        }

              //Method to call the main genetic algorithm loop
        void Display()
        {
               GA.Begin();
                
                //The Genetic Algorithm will keep running until one of the stop rules are met
                //Stop button pushed, generation total reached or desired distance achieved
                while (Genetic_Algorithm.GenCount < Genetic_Algorithm.GenTotal && !stop && Math.Round(Genetic_Algorithm.Best.Length) > desiredDistance)
                {
                    
                    if (!paused)
                    {
                        GA.NextGeneration();

                    }
                    //Displaying the current information on screen
                    pb1.Invoke((MethodInvoker)delegate() { pb1.Refresh(); });
                    lblDistance.Invoke((MethodInvoker)delegate() { lblDistance.Text = "Distance: " + Math.Round(Genetic_Algorithm.Best.Length); });
                    lblGen.Invoke((MethodInvoker)delegate() { lblGen.Text = "Generation " + Genetic_Algorithm.GenCount + " of " + Genetic_Algorithm.GenTotal; });//used to modify the generation label because cant operate across threads             
                    
                    nextGen = false;
                    foreach (int dna in Genetic_Algorithm.Best.DNA)
                    {
                        //writing most fit genome to file
                        writer.Write(dna + ",");

                    }
                    writer.WriteLine();
                    
                }
                writer.Close();

            MessageBox.Show("Crossover used: " + Genetic_Algorithm.Crossover.GetType().Name 
                + Environment.NewLine  + "Mutation Used: " + Genetic_Algorithm.Mutate.GetType().Name 
                + Environment.NewLine + "\n" + "Route Distance: " + Math.Round(Genetic_Algorithm.Best.Length), "Completed");

     
                Genetic_Algorithm.Best = null;    
                stop = false;
              
            
        }


        //Paint Method to Update cities and routes
        private void pb1_Paint(object sender, PaintEventArgs e)
        {
            if (Genetic_Algorithm.CityPoints != null)
            {
                using (Bitmap bitmap = new Bitmap(pb1.Width, pb1.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {


                        //Draw circle points for city locations
                        using (Pen pen = new Pen(Color.Yellow, 1))
                        {
                            for (int c = 0; c < Genetic_Algorithm.CityCount; c++)
                            {
                                graphics.DrawEllipse(pen, Genetic_Algorithm.CityPoints[c].X - sizeOfPoint / 2, Genetic_Algorithm.CityPoints[c].Y - sizeOfPoint / 2, sizeOfPoint, sizeOfPoint);
                            }
                        }
                        

                        //Draws connecting routes to each city point
                        
                        if (Genetic_Algorithm.Best != null)
                        {
                            using (Pen pen = new Pen(Color.White, 1))
                            {
                                for (int c = 1; c < Genetic_Algorithm.CityCount; c++)
                                {
                                    graphics.DrawLine(pen, Genetic_Algorithm.CityPoints[Genetic_Algorithm.Best.DNA[c - 1]], Genetic_Algorithm.CityPoints[Genetic_Algorithm.Best.DNA[c]]);
                                }

                                graphics.DrawLine(pen, Genetic_Algorithm.CityPoints[Genetic_Algorithm.Best.DNA[Genetic_Algorithm.CityCount - 1]], Genetic_Algorithm.CityPoints[Genetic_Algorithm.Best.DNA[0]]);
                            }
                        }
                    }
                    e.Graphics.DrawImage(bitmap, Point.Empty);
                }
            }
        }



        #region Options

        private void cbRandomCity_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRandomCity.Checked)
            {
                randomCities = true;
            }
        }

    

        private void tbGenSize_TextChanged(object sender, EventArgs e)
        {
            Genetic_Algorithm.GenTotal = int.Parse(tbGenSize.Text);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
           
            stop = true;
       
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Genetic_Algorithm.ElitePercent = (int)numericUpDown1.Value;
        }


        #region Selection Methods
        //
        //

        private void cbRoulette_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRoulette.Checked == true)
            {
                Genetic_Algorithm.Selection = new RouletteWheelSelection();
                cbTournament.Checked = false;
                cbSUS.Checked = false;
            }
        }
        private void cbSUS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSUS.Checked == true)
            {
                Genetic_Algorithm.Selection = new StochasticUniversalSamplingSelection();
                cbTournament.Checked = false;
                cbRoulette.Checked = false;
            }
        }
        private void cbTournament_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTournament.Checked == true)
            {
                Genetic_Algorithm.Selection = new TournamentSelection();
                cbRoulette.Checked = false;
                cbSUS.Checked = false;
            }
           
        }

        #endregion

        

        //Code to draw circle on screen to test TSP
        private void btnCircleTest_Click(object sender, EventArgs e)
        {
            List<Point> cityPoints = new List<Point>();

            int angle = 0;

            int length = 100;
            int randNum = 360 / Genetic_Algorithm.CityCount;
            //Try to make the circle more centered on the picture box
            int x = (pb1.ClientSize.Width - length * 4);
            int y = (pb1.ClientSize.Height - length * 3);



            while (angle < 360)
            {
                int pos1 = (int)(x + length * Math.Cos(angle));
                int pos2 = (int)(y + length * Math.Sin(angle));

                angle += randNum;

                cityPoints.Add(new Point(pos1, pos2));
            }


            Genetic_Algorithm.CityPoints = cityPoints.ToArray();
            pb1.Invalidate();

        }
     
        private void btnPause_Click(object sender, EventArgs e)
        {
            paused = !paused;
            if (paused)
            {
                btnPause.Text = "Continue";
                
            }
            else
                btnPause.Text = "Pause";
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            randomCities = false;
            cbRandomCity.Checked = false;
            DialogResult result = openFile.ShowDialog();
            file = openFile.FileName;
            tbFileName.Text = openFile.SafeFileName;
            btnGenerate_Click(sender, e);
            
        }

        private void numMutation_ValueChanged(object sender, EventArgs e)
        {
            Genetic_Algorithm.MutatePercent = (int)numMutation.Value;
        }

        private void tbPopSize_TextChanged(object sender, EventArgs e)
        {
            Genetic_Algorithm.PopSize = int.Parse(tbPopSize.Text);
        }
        private void tbDesiredDist_TextChanged(object sender, EventArgs e)
        {
            desiredDistance = int.Parse(tbDesiredDist.Text);
        }
       

       
       
        private void tbCityNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Genetic_Algorithm.CityCount = int.Parse(tbCityNum.Text);
            }
            catch (Exception)
            {

               
            }
          
        }

      

        #endregion

        private void TSPForm_Load(object sender, EventArgs e)
        {

            cmbCrossOver.SelectedIndex = 3;
            cmbMutation.SelectedIndex = 3;
        }

       

       

        private void cmbCrossOver_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Old Random Cross Over
            if (cmbCrossOver.SelectedIndex == 0)
            {
                Genetic_Algorithm.Crossover = new RandomPointCrossover();
                
            }
            //Old Single Point Cross Over

            if (cmbCrossOver.SelectedIndex == 1)
            {
                
                Genetic_Algorithm.Crossover = new SinglePointInversionCrossover();
            }

            //Old Two Point Cross Over
            if (cmbCrossOver.SelectedIndex == 2)
            {
                Genetic_Algorithm.Crossover = new TwoPointInversionCrossover();
            }


            //New Random Cross Over
            if (cmbCrossOver.SelectedIndex == 3)
            {
                Genetic_Algorithm.Crossover = new New_RandomPointCrossover();
            }

            //New Single Point Cross Over
            if (cmbCrossOver.SelectedIndex == 4)
            {
                Genetic_Algorithm.Crossover = new New_SinglePointInversionCrossover();
            }

            //New Two Point Cross Over
            if (cmbCrossOver.SelectedIndex == 5)
            {
                Genetic_Algorithm.Crossover = new New_TwoPointInversionCrossover();
            }

            //Order-based Cross Over
            if (cmbCrossOver.SelectedIndex == 6)
            {
                Genetic_Algorithm.Crossover = new OrderBasedCrossover();
            }

            //Partially Mapped Cross Over
            if (cmbCrossOver.SelectedIndex == 7)
            {
                Genetic_Algorithm.Crossover = new PartiallyMappedCross();
            }

            //if (cmbCrossOver.SelectedIndex == 8)
            //{
            //    Genetic_Algorithm.Crossover = new New_TwoPointInversionCrossover();
            //}

        }

        private void cmbMutation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMutation.SelectedIndex == 0)
            {
                Genetic_Algorithm.Mutate = new RandomPointMutation();
            }
            if (cmbMutation.SelectedIndex == 1)
            {
                Genetic_Algorithm.Mutate = new DisplacementMutation();
            }

            if (cmbMutation.SelectedIndex == 2)
            {
                Genetic_Algorithm.Mutate = new InversionDisplacementMutation();
            }

            if (cmbMutation.SelectedIndex == 3)
            {
                Genetic_Algorithm.Mutate = new InversionMutation();
            }

            if (cmbMutation.SelectedIndex == 4)
            {
                Genetic_Algorithm.Mutate = new ScrumbledMutation();
            }

            if (cmbMutation.SelectedIndex == 5)
            {
                Genetic_Algorithm.Mutate = new InsertionMutation();
            }
        }
    }
}
