//Jason R Hodges - ASUID = 1205172549
//CSE 445 - Assignment 01
//Simple main program to test the tempature conversion service
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTempConv
{
    class Program
    {
        static void Main(string[] args)
        {   //Simple main program to call the Temp Conversion Service and diplay the results in cmd
            TempConvReference.Service1Client tempConvRef = new TempConvReference.Service1Client();

            //Variables to be passed to the tempConvRef operations
            int celsius = 0;
            int fahrenheit = 0;

            //calls the 2 operations from the temp conversion service that I made and sets them to 2 ints
            int resultC = tempConvRef.c2f(celsius);
            int resultF = tempConvRef.f2c(fahrenheit);

            //Display the results of the operations called above
            Console.WriteLine("Convert Celsius to Fahrenheit: {0}ºC = {1}ºF", celsius, resultC);
            Console.WriteLine("Convert Fahrenheit to Celsius: {0}ºF = {1}ºC", fahrenheit, resultF);

            //close the tempConvRef object and ReadLine so the program waits to close
            tempConvRef.Close();
            Console.ReadLine();


        }
    }
}
