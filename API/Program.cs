using System;


namespace API
{
    class Program
    {

        static void Main(string[] args)
        {
            App app = new App();

            /// Download Customers
            Customers ListOfCustomers = app.getCustomers();


            /// Create a Customer
            Customer myCustomer = new Customer();
            myCustomer.setData("Bob", "Ross");
            
            CustomerPost postCustomer = new CustomerPost(myCustomer);
            Customer newCustomer = app.createCustomer(postCustomer);

            Console.Write("done!");

        }
    }
}
