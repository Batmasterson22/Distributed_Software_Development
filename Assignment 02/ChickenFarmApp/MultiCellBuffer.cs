//Name: Jason R Hodges - CSE445 - Online class
//Description: This class is used as an in between the chicken farm and the retailer. It makes use of semaphores
//and locks so that multiple threads can't modifie the buffer cells if they are being used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChickenFarmApp
{
    public delegate void SetOneCellEvent(MultiCellBuffer buffer, Retailer retailer, int storeID); //Event for when a new order is added

    public class MultiCellBuffer
    {
        public event SetOneCellEvent setOneCellEventHandler;                //Event handler for when a new order is added                                 
      
        private Object bufferLock = new Object();                           //object for the locks                 
        private Semaphore pool = new Semaphore(2, 2);                       //Initialize semaphore with 2
        private string[] bufferCells = new string[2];                       //array to hold the order strings 2 cells

        //Getter/Setter for the array in the index passed
        public string this[int index] {                                     
            get { return bufferCells[index]; }         //return the buffer cell at the index passed
            set { bufferCells[index] = value; }        //Set the buffer cell at the index
        }        

        //This method is used to add an order to the buffer using a semaphore and lock to ensure proper resource sharing
        public void setOneCell(Retailer retailer, string orderString) {
            pool.WaitOne();                             //If no semaphore is available wait here, else procced
            int index = 0;

            lock (bufferLock) {
                index = Array.FindIndex(bufferCells, string2 => string.IsNullOrEmpty(string2)); //Use IsNullOrEmpty to find an empty cell
                bufferCells[index] = orderString;       //Add order to the empty array cell
            }

            if (setOneCellEventHandler != null) {       //Event for when an order is added to the array
                setOneCellEventHandler(this, retailer, index);
            }
        }
        //This method removes the the order from the buffer
        public void getOneCell(OrderClass order, double orderTotal, bool validCard) {
            lock (bufferLock) {            
                int index = Array.IndexOf(bufferCells, order.ToStringOther());  //Uses the order to string to find the order in the array
                bufferCells[index] = null;              //delete the old order string from the buffer
            } 
            pool.Release();                             //Release the semaphore
        }
        //Checks if the buffer array is empty
        public bool arrayIsEmpty {
            get { return bufferCells.Length == 0; }
        }
    }
}
