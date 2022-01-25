using System;
using System.IO;



namespace MontanpP1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gasNames = new string[100];
            double[] molecularWeights = new double[100];
            int count = 0;  


            ProgramHeader();
            DisplayHeader();
            GetMolecularWeight(ref gasNames, ref molecularWeights, out count);

            for (int i = 0; i < gasNames.Length - 2; i += 3)
            {
                Console.WriteLine(String.Format("{0,-20:D}",gasNames[i]) + "\t" + String.Format("{0,-20:D}", gasNames[i + 1]) + "\t" + String.Format("{0,-20:D}", gasNames[i + 2])); 
            }
            System.Console.ReadLine();
        }


        public static void DisplayHeader()
        {
            Console.WriteLine("\n------------------------------------------------" +
                "\n\n Hello and welcome to the " +
                "Ideal Gas Calculator!" +
                "\n\n------------------------------------------------");
        }

        public static void ProgramHeader()
        {
            Console.WriteLine("\n Name: Andrew Montano" +
                "\n Program: MontanoP1 \n Objective: Get the pressure of " +
                "a given gas");
        }

        public static void GetMolecularWeight(ref string[] gasNames, ref double[] molecularWeights, out int count)
        {
            count = 0;

            
            foreach (string line in System.IO.File.ReadLines(@"D:\School\NetCsharp\Programs\MontanpP1\MontanpP1\MolecularWeightsGasesAndVapors.csv"))
            {
                //System.Console.WriteLine(line);
                string[] elements = line.Split(',');
                gasNames[count] = elements[0];
                molecularWeights[count] = double.Parse(elements[1]);
                count++;
            }
            

            System.Console.WriteLine("There were {0} lines.", count);
            
           
            
        }

     



    }
}


