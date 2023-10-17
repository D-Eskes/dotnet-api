using System;
using System.Collections.Generic;

namespace API
{
    // Not the cutest solution, but this one makes sure the post
    // to Cockpit CMS works (requires a "data" object)
    public class CustomerPost
    {
        public CustomerPost(Customer customer)
        {
            this.data = customer;
        }

        public Customer data { get; set; }
    }

   

    // Main Customer Class
    public class Customer
    {
        /// Data-setter
        public void setData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string _id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Tasks[] tasks { get; set; }
    }


    public class Task
    {
        public string titel { get; set; }
        public string beschrijving { get; set; }
        public bool publishItem { get; set; }
        public bool taskCompleted { get; set; }
    }

    public class Tasks
    {
        public Task value { get; set; }
    }

    // List of Customers
    public class Customers
    {
        public List<Customer> entries { get; set; }
    }
}
