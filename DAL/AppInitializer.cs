using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using OnlineShippingApp.Models;
namespace OnlineShippingApp.DAL
{
    public class AppInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            var orders = new List<Order>
            {
              new Order {OrderId=1,SpeicialCode="AM12345",clientName="AbdElrahaman Mohamed" ,ClientAddress="6th October",Source="Alex",Destination="Giza" ,OrderDate=DateTime.Parse("2022-6-25"),OrderStatus=Status.Confirmed,TrackingBy=Tracking.Land},


            new Order {OrderId=2,SpeicialCode="AL123466",clientName="Ahmed Saad " ,ClientAddress="Helmya",Source="Sharm Elsheikh",Destination="Cairo" ,OrderDate=DateTime.Parse("2022-6-25"),OrderStatus=Status.Confirmed,TrackingBy=Tracking.Air},



            };

            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
        }

    }
}