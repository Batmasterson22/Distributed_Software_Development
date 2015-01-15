//Name: Jason R Hodges - CSE445 - Online class
//Description: Main method to start the farmer and retailer threads
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChickenFarmApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiCellBuffer mCBuffer = new MultiCellBuffer();   //Buffer object
            ChickenFarm chicken = new ChickenFarm(mCBuffer);    //ChickenFarm object
            //Retailer chickenstore = new Retailer();           //Retailer objects
            //Thread[] retailers = new Thread[5];               //Retailer threads

            Thread farmer = new Thread(new ThreadStart(chicken.farmerFunc));    //Farmer thread
            farmer.Start();                                                     //Start farmer thread

            //I was unable to get the retailer, farmer, and order threads to work together
            //without running into problems, I think it is a synchronizing problem but no solution
            for (int storeID = 1; storeID < 6; ++storeID)
            {
                //Create multiple retailer objects with overloaded storeIDs
                Retailer retailer = new Retailer(mCBuffer, chicken, storeID);

                //retailers[i] = new Thread(new ThreadStart(chickenstore.retailerFunc));
                //retailers[i].Name = (i + 1).ToString();
                //retailers[i].Start();
            }

            farmer.Join();                                              //Waits for farmer threads to finish
            
            Console.ReadKey();
        }
    }
}
