//Name: Jason R Hodges - CSE445 - Online class
//Description: This class checks the validity of the credit card number and calculates the total price.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChickenFarmApp
{
    public delegate void FinishedOrderEvent(OrderClass order, double orderTotal, bool validCards); //delegste for finished order event

    public class OrderProcessing
    {
        public event FinishedOrderEvent orderEventHandler;                  //Finished order event hander

        private OrderClass order { get; set; }                              //OrderClass object

        //Initialize OrderProcessing with the OrderClass object after it is decoded
        public OrderProcessing(string order) {
            this.order = OrderClass.Decoder(order);
        }
        //This method calculates the total order price including taxes and S&H per chicken
        public void OrderProcessor(ChickenFarm farm) {
            bool validCard = false;
            Thread.Sleep(1000);
            double orderTotal = ((farm.getUnitPrice() * order.getNoOfChickens()) * (farm.getTax())) +
                                (farm.getShipHand() * order.getNoOfChickens());     //Formula for orderTotal

            if (order.getCardNo() > 1000 && order.getCardNo() < 3000)                //Sets validCard to true if it bewteen 1000-3000
                validCard = true;

            if (orderEventHandler != null) {
                orderEventHandler(order, orderTotal, validCard);                     //Calls order event
            }
        }
    }
}
