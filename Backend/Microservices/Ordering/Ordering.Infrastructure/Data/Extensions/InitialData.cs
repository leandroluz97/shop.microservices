using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static List<Customer> Customers =>
        [
            Customer.Create(CustomerId.Of(new Guid("AA3F38BA-B127-410E-8D85-C359BE8B42E8")), "Jhon Doe", "jhondoe@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("C3D88F8E-ABCC-41BE-9C66-7CDB2E801DD2")), "Felipe Martinez", "felipemartinez@gmail.com"),
        ];

        public static List<Product> Products =>
        [
            Product.Create(ProductId.Of(new Guid("34CA08E4-CDC9-4AFA-8228-A38803F96B75")), "IPhone 16 Pro Max", 1200),
            Product.Create(ProductId.Of(new Guid("2A2FECAF-2890-4FFC-AFB4-A1C208A0DDE2")), "AirPods Pro",  250),
        ];


        public static IEnumerable<Order> Orders { 
            get 
            {
                var order1 = Order.Create(
                    OrderId.Of(new Guid("9AFAC90D-EF23-48D1-BFE8-999623CBD19B")),
                    CustomerId.Of(new Guid("AA3F38BA-B127-410E-8D85-C359BE8B42E8")),
                    OrderName.Of("ORD_1"),
                    Address.Of("Jhon", "Doe", "jhondoe@gmail.com", "Marques pombal n3", "Portugal", "Lisbon", "10704"),
                    Address.Of("Jhon", "Doe", "jhondoe@gmail.com", "Marques pombal n3", "Portugal", "Lisbon", "10704"),
                    Payment.Of("Jhon Doe", "98988989898984444", "30/03", "222", 1));

                var order2 = Order.Create(
                    OrderId.Of(new Guid("DA544476-753B-4EBD-A1D5-CA8262ADAC81")),
                    CustomerId.Of(new Guid("C3D88F8E-ABCC-41BE-9C66-7CDB2E801DD2")),
                    OrderName.Of("ORD_2"),
                    Address.Of("Felipe", "Martinez", "felipemartinez@gmail.com", "Marques pombal n5", "Portugal", "Lisbon", "10705"),
                    Address.Of("Felipe", "Martinez", "felipemartinez@gmail.com", "Marques pombal n5", "Portugal", "Lisbon", "10705"),
                    Payment.Of("Felipe Martinez", "98988989898984444", "26/02", "444", 1));

                order1.Add(ProductId.Of(new Guid("34CA08E4-CDC9-4AFA-8228-A38803F96B75")), 2, 1200);
                order1.Add(ProductId.Of(new Guid("2A2FECAF-2890-4FFC-AFB4-A1C208A0DDE2")), 1, 250);
                order2.Add(ProductId.Of(new Guid("2A2FECAF-2890-4FFC-AFB4-A1C208A0DDE2")), 1, 250);

                return new List<Order> { order1, order2 };  
            } 
        }


    }
}
