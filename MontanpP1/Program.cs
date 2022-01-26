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
            double temp = 0;
            int count = 0;
            string gasName = "";
            double volume = 0;
            double mass = 0;
            char another;

            ProgramHeader();
            DisplayHeader();
            GetMolecularWeight(ref gasNames, ref molecularWeights, out count);
            do
            {   DisplayGasNames(gasNames,count);
                double molecularWeight = GetMolecularWeightFromName(gasName, gasNames, molecularWeights, count);
                Pressure(mass, volume, temp, molecularWeight);

                Console.WriteLine("\nDo you want to try another gas?: y/n ");
                another = char.Parse(Console.ReadLine());
            } while (another == 'y');
            
            Console.WriteLine("\n\nThanks for testing out Montano Ideal Gas Calculator!\n           Have a fantasitc day!!   ");

        }


        private static void DisplayHeader()
        {
            Console.WriteLine("\n------------------------------------------------" +
                "\n\n Hello and welcome to the " +
                "Ideal Gas Calculator!" +
                "\n\n------------------------------------------------");
        }

        private static void ProgramHeader()
        {
            Console.WriteLine("\n Name: Andrew Montano" +
                "\n Program: MontanoP1 \n Objective: Get the pressure of " +
                "a given gas");
        }

        static void GetMolecularWeight(ref string[] gasNames, ref double[] molecularWeights, out int count)
        {
            count = 0;


            foreach (string line in System.IO.File.ReadLines(@"MolecularWeightsGasesAndVapors.csv"))
            {
                //System.Console.WriteLine(line);
                string[] elements = line.Split(',');
                gasNames[count] = elements[0];
                molecularWeights[count] = double.Parse(elements[1]);
                count++;
            }


            System.Console.WriteLine("There were {0} lines.", count);

        }
        
        private static void DisplayGasNames(string [] gasNames, int countGases)
        {
            for (int i = 0; i < countGases; i += 3)
            {
                Console.WriteLine(String.Format("{0,-20:D}", gasNames[i]) + "\t" + String.Format("{0,-20:D}", gasNames[i + 1]) + "\t" + String.Format("{0,-20:D}", gasNames[i + 2]));
            }
            //System.Console.ReadLine();
        }
        private static double GetMolecularWeightFromName(string gasName, string[] gasNames, double[] molecularWeights, int countGases)
        {
            Console.WriteLine("\n Please choose a gas from the list above (type out full name of gas as you see it): ");
            gasName = Console.ReadLine();
            var stringToFind = gasName;
            var result = Array.IndexOf(gasNames, stringToFind);
            if (result == -1)
            {
                Console.WriteLine("\n Check spelling of the gas you chose.");
            }
            else
            {
                Console.WriteLine("\n The gas you chose is " + gasName + " and has a molecular weight of " + molecularWeights[result] + " grams per mole!");
            }
                return molecularWeights[result];
            
        }

        static double CelciusToKelvin(double celcius)
        {
            Console.WriteLine("\n At what temperature celsius is the gas in?: ");
            celcius = double.Parse(Console.ReadLine());
            double kelvin = celcius + 273.15;


            //Console.WriteLine(kelvin);
            return kelvin;
            
        }
        
        static double NumberOfMoles(double mass, double molecularWeight)
        {
            double moles = mass / molecularWeight;
            //Console.WriteLine(moles);
            return moles;
        }

        static double Pressure(double mass, double vol, double temp, double molecularWeight)
        {
            double celcius = 0;
            const double idealConst = 8.3145;

            Console.WriteLine("\n Enter the mass of the gas (this is measured in grams): ");
            mass = double.Parse(Console.ReadLine());

            Console.WriteLine("\n Now enter the volume (this is measured in meters cubed): ");
            vol = double.Parse(Console.ReadLine());

            temp = CelciusToKelvin(celcius);
            double numMoles = NumberOfMoles(mass, molecularWeight);
            double pressureInPascals = (numMoles * idealConst * temp) / vol;
            double psi = PaToPSI(pressureInPascals);

            Console.WriteLine("\n**********************************************************");
            Console.WriteLine("\n Pressure in pascals is: " + pressureInPascals);
            Console.WriteLine("\n The PSI is: " + psi );
            Console.WriteLine("\n**********************************************************");
            return pressureInPascals;
        }
         
        static double PaToPSI(double pascals)
        {
            double psi = pascals / 6895;
            Console.WriteLine(" The PSI is " + psi);
            return psi;
        }

     



    }
}


