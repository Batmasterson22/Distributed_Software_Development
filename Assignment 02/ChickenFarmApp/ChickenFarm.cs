//Name: Jason R Hodges - CSE445 - Online class
//Description: This class is the server side of this application that determines the price of the chickens,
//gets orders from the buffer, and has an event for when the price is changed.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChickenFarmApp
{   
    public delegate void PriceChangeEvent(double priceChange);      //Delegate for Price Change Event

    public class ChickenFarm
    {
        public event PriceChangeEvent PriceChangeHandler;           //Price Change event handler
        public double getUnitPrice() { return unitPrice; }          //Get per chicken price
        public double getOldUnitPrice() { return oldUnitPrice; }    //Get old price
        public double getTax() { return tax; }                      //Get tax
        public double getShipHand() { return shippingHandling; }    //Get S&H
        public void setUnitPrice(double unitPrice) { this.unitPrice = unitPrice; }  //Set per chicken price
        public void setOldUnitPrice(double oldUnitPrice) { this.oldUnitPrice = oldUnitPrice; }  //Set old price
        public void setTax(double tax) { this.tax = tax; }                                      //Set tax
        public void setShipHand(double shippingHandling) { this.shippingHandling = shippingHandling; }  //Set S&H

        private double unitPrice { get; set; }                      //Current Price per chicken
        private double oldUnitPrice { get; set; }                   //Old Price per chicken
        private double tax { get; set; }                            //Taxes 8.5% to be added
        private double shippingHandling { get; set; }               //Shipping rate per chicken
        private bool priceCompare { get; set; }                     //Compare Price for price change
        private Random rng = new Random();                          //Random number generator
        private int pcCounter { get; set; }                         //Price Cut Counter

        public ChickenFarm(MultiCellBuffer buffer) {                //ChickenFarm initializer
            unitPrice = 10;
            tax = 1.085D;
            shippingHandling = 0.70D;
            pcCounter = 0;
            buffer.setOneCellEventHandler += GetBufferOrder;
        }
        //Farmer Thread function
        public void farmerFunc() {                                  
            for (pcCounter = 0; pcCounter <= 10; ) {                //Limits the number of price changes
                oldUnitPrice = unitPrice;
                PriceChange();                                      //Calls price change method
                Thread.Sleep(500);                                  //Thread sleeps for .5 sec
            }
        }
        //Used to get the an order from the buffer
        private void GetBufferOrder(MultiCellBuffer buffer, Retailer retailer, int storeID) {
            OrderProcessing order = new OrderProcessing(buffer[storeID]);       //OrderProcessing object
            //Thread orderThread = new Thread(new ThreadStart(orderProc.OrderProcessor));
            new Thread(() => order.OrderProcessor(this)).Start();               //Use lambda operator to start OP thread
            order.orderEventHandler += retailer.RetailerResponse;               //Comfirm credit card is valid and order complete event
            order.orderEventHandler += buffer.getOneCell;                       //Get the order from the buffer event
        }
        //Random number generator for the per chicken price
        public void PricingModel() {                
            unitPrice = rng.Next(5, 10);
        }
        //Used to display price changes and call the price change event
        private void PriceChange() {            
            priceCompare = false;
            PricingModel();                     //Calls the above method to randomaly change the price
            if (unitPrice == oldUnitPrice)      //Price change comparing
                priceCompare = true;

            if (priceCompare) {                 //Display no price change
                Console.WriteLine("*************Chicken has not changed price*************");   
            } else {                            //Display changed price and old price of chickens
                Console.WriteLine("********Chicken has changed price to ${0} from ${1}********", unitPrice, oldUnitPrice);
            }

            if (unitPrice < oldUnitPrice) {     //Calls price change event if new price is less than old price
                PriceChangeEvent();
            }
        }
        //Price change event for when the new price is less than old price
        private void PriceChangeEvent() {
            if (PriceChangeHandler != null) {
                Console.WriteLine("\n++++++++CHICKEN SALE! Now at the low price of ${0}+++++++", unitPrice);
                PriceChangeHandler(unitPrice);      //Calls the price change event passing it the chicken price
                ++pcCounter;                        //Increment the Price cut counter
            }            
        }
    }
}
