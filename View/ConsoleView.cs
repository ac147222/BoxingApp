using System;
using System.Collections.Generic;
using System.Text;
using BoxingApp;
using BoxingDatabase;

namespace BoxingDatabase
{
    public class ConsoleView
    {
        
        public string DisplayMenu()
        {
            Console.WriteLine("=== Boxing App ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
            return Console.ReadLine(); 
        }

        public void DisplayRegions(List<Region> regions)
        {
            foreach (Region region in regions)
            {
                Console.WriteLine($"{region.RegionID},{region.RegionName}");
            }
        }
       

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message); 
        }

        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty; 
        }

        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine() ?? "0");  
        }

       
       
    }
}


