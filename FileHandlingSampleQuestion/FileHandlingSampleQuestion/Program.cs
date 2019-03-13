using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TemperatureFileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineIn;
            string[] fields = new string[3];
            double[] totalCostArray = new double[4];
            string tableFormat = "{0,-20}{1, -10}{2,-10}", itemName;
            int  quantity = 0, itemCost = 0;
            double totalCost = 0;

            FileStream fs3 = new FileStream("customers.txt", FileMode.Open, FileAccess.Read); // Open connection

            StreamReader inputStream = new StreamReader(fs3); // print heading

            WriteLine(tableFormat, "Customer", "Item", "Quantity");

            lineIn = inputStream.ReadLine();

            while (lineIn != null)
            {
                fields = lineIn.Split(',');
                WriteLine("\n"+ tableFormat, fields[0], fields[1], fields[2] + "\n");
                lineIn = inputStream.ReadLine();
                quantity = int.Parse(fields[2]);
                itemName = fields[1];

                if(itemName == "Shirt")
                {
                    itemCost = 25;
                }
                else if(itemName == "Jumper")
                {
                    itemCost = 30;
                }
                else if (itemName == "Trousers")
                {
                    itemCost = 35;
                }

                for (int i = 0; i < totalCostArray.Length; i++)
                {
                    totalCost = itemCost * quantity;
                    totalCostArray[i] = totalCost;
                }


                if (totalCost < 50)
                {
                        WriteLine("================ Customer Receipt ===============");
                        WriteLine("{0,-20}{1, -10}", "Customer", "Total Cost");
                        WriteLine("{0,-20}{1, -10}", fields[1], totalCost);
                    
                }
                else if(totalCost >= 50)
                {
                        WriteLine("================ Customer Receipt ===============");
                        WriteLine("{0,-20}{1, -10}", "Customer", "Total Cost");
                        WriteLine("{0,-20}{1, -10}", fields[1], totalCost);
                    
                }
            }

            /*WriteLine("================ Customer Receipt ===============");
            WriteLine("{0,-20}{1, -10}", "Customer", "Total Cost");
            WriteLine("{0,-20}{1, -10}", "Molly", totalCost);
            WriteLine("{0,-20}{1, -10}", "Mark", totalCost);
            WriteLine("{0,-20}{1, -10}", "Mark", totalCost);
            WriteLine("{0,-20}{1, -10}", "Jean", totalCost);*/





            inputStream.Close();
        }
    }
}