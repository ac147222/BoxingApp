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
            Console.WriteLine("welcome to the Boxing Database");
            Console.WriteLine("menu: ");
            Console.WriteLine("1. view all the records in Region table");
            Console.WriteLine("2. Update a region's name by region_ID");
            Console.WriteLine("3. Insert a new region");
            Console.WriteLine("4. Delete a region by region_name");
            Console.WriteLine("Select an option: ");
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


