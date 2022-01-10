using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Core.Extensions;

namespace FrontDeskAppConsole
{
    internal static class Program
    {
        private static readonly HttpClient client = new HttpClient();

        private static void Main()
        {
            Console.WriteLine("Welcome to Front Desk App!\n");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Input Customer Information");
            Console.WriteLine("[2] Check available space for the facility");
            Console.WriteLine("[3] Insert/Update customer storage");
            Console.WriteLine("[4] Check other facility for available space\n");

            int selectedProcess = Convert.ToInt32(Console.ReadLine());

            switch (selectedProcess)
            {
                case 1:
                    RunCreateCustomerAsync().GetAwaiter().GetResult();
                    break;
                case 2:
                    CheckAvailableSpace();
                    break;
                case 3:
                    RunCreateUpdateCustomerStorageAsync().GetAwaiter().GetResult();
                    break;
                case 4:
                    CheckOtherFacilityAvailableSpace();
                    break;
                default:
                    Console.WriteLine("Have a nice day!");
                    break;
            }

            

        }

        private static void CheckAvailableSpace()
        { 
        
        }

        private static async Task RunCreateUpdateCustomerStorageAsync()
        {
            Console.Write("\nCustomer First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("\nCustomer Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("\nCustomer Phone Number: ");
            string phoneNumber = Console.ReadLine();


            // Update your local service port no. / service APIs etc in the following line
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Customer customer = new Customer();

                HttpResponseMessage response = await client.GetAsync(string.Concat("api/Customer/", firstName, "/", lastName, "/", phoneNumber));
                if (response.IsSuccessStatusCode)
                {
                    customer = await response.Content.ReadAsAsync<Customer>();

                    HttpResponseMessage response1 = await client.GetAsync(string.Concat("api/Storage/", customer.CustomerId.ToString()));
                    string status;
                    if (response.IsSuccessStatusCode)
                    {
                        status = await response.Content.ReadAsAsync<string>();

                        switch (status)
                        {
                            case "Stored":
                                Console.WriteLine(string.Format("Do you want to retrieve the item in storage for customer ", firstName, " ", lastName, "? [Y]"));
                                //update the item to retrieved
                                break;
                            case "Retrived":
                                Console.WriteLine(string.Format("Item in storage for customer ", firstName, " ", lastName, " already been retrieved."));
                                break;
                            default:
                                Console.WriteLine(string.Concat("No item in storage for customer ", firstName, " ", lastName));
                                Console.WriteLine("Do you want to add a new one? [Y]" );
                                //insert new record for customer 
                                break;
                        }
                        
                    }

                }

                Console.WriteLine("Customer doesn't exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static void CheckOtherFacilityAvailableSpace()
        { 
        
        }

        private static async Task RunCreateCustomerAsync()
        {
            Console.Write("\nCustomer First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("\nCustomer Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("\nCustomer Phone Number: ");
            string phoneNumber = Console.ReadLine();


            // Update your local service port no. / service APIs etc in the following line
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Customer customer = new Customer
                {
                    CustomerFirstName = firstName,
                    CustomerLastName = lastName,
                    CustomerPhoneNumer = phoneNumber
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("api/Customer", customer);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Save successfully! ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
