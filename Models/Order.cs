using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShippingApp.Models
{
    public enum Tracking { Air, Sea, Land }
    public enum Status { Confirmed, OnWay, Arrived }
    public class Order
    {

        public int OrderId { get; set; }

        public string SpeicialCode { get; set; }

        public string clientName { get; set; }

        public string ClientAddress { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public Tracking TrackingBy { get; set; }

        public Status OrderStatus { get; set; }






    }
}