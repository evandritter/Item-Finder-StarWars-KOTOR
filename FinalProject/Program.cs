using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IntroList();
            while (Crystal.CrystalInfo()) ;
        }

        //Pulls information from a txt file holding the title of the information (crystals of KOTOR) and Crystals to select from//
        //If for some reason the file isn't wanting to display its contents, to engage the program select an
        //integer in range of 1-5 (6 to exit) to see crystal information
        public static void IntroList()
        {
            string line = "";
            using (StreamReader sr = new StreamReader(@"C:\Users\evand\source\repos\YetAnother\Crystal_Info.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

        }

        //Creating Crystal class with Location and Ability//
        public class Crystal
        {

            private string _Location;
            public string Location => _Location;

            private string _Ability;
            public string Ability => _Ability;

            public void PrintInfo()
            {
                Console.WriteLine("Location: {0}\nAbility: {1}", this.Location, this.Ability);
            }

            public Crystal(string Location, string Ability)
            {
                this._Location = Location;
                this._Ability = Ability;
            }

            public static bool CrystalInfo()
            {
                //Add crystals to a list//
                List<Crystal> crystals = new List<Crystal>();
                crystals.Add(new Crystal("Dantooine", "Turns lightsaber blue"));
                crystals.Add(new Crystal("Dantooine, Tatooine, Kashyyyk", "Turns lightsaber yellow"));
                crystals.Add(new Crystal("Dantooine", "Turns lightsaber green"));
                crystals.Add(new Crystal("Dantooine, Tatooine, Korriban", "Turns lightsaber violet"));
                crystals.Add(new Crystal("Dantooine, Tatooine", "Turns lightsaber red"));

                //Prompt user to select a crystal, utilizes switch for selecting information and program exit//
                Console.Write("To access the location and ability information of a crystal,\nenter the number next to the crystal of your interest: ");

                //error handling for if user inputs a non-integer//
                int crystalSwitch;
                try
                {
                    crystalSwitch = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter an appropriate integer.");
                    Console.WriteLine();
                    return true;
                }

                //Grabs and displays the crystal information associated with the user input from the crystals list using switch and PrintInfo method, also exits the program if 6 selected, error handling for non-integer input//
                Console.WriteLine();
                switch (crystalSwitch)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        crystals[crystalSwitch - 1].PrintInfo();
                        break;
                    case 6:
                        Console.WriteLine("May the force be with you, always.");
                        return false;
                    default:
                        Console.WriteLine("Please enter an appropriate integer.");
                        break;
                }
                Console.WriteLine();
                return true;
            }
        }
    }
}
