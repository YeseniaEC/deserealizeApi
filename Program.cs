using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;

namespace ConsoleHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var http = new HttpClient();

            var jsonString = http.GetStringAsync("https://swapi.co/api/people").Result;
            var jsonObject = JsonConvert.DeserializeObject<PeopleList>(jsonString);

            var people = jsonObject.People;

            //Console.WriteLine(jsonString + "\n");

            var filteredPeople = people.Where(person => person.NumberOfVehicles > 0);

            foreach( var person in filteredPeople)
            {
                Console.WriteLine($"Name:  {person.Name}");
                Console.WriteLine($"Birthday:  {person.BirthYear}");
                Console.WriteLine($"Mass:  {person.Mass + 10}");
                Console.WriteLine($"Eye Color:  {person.EyeColor}");
                Console.WriteLine($"Gender:  {person.Gender} \n");

                foreach(var jsonUrl in person.VehicleJson)
                {
                    var result = http.GetStringAsync(jsonUrl).Result;
                    var vehicleObject = JsonConvert.DeserializeObject<Vehicle>(result);
                    Console.WriteLine($" vehicle name : {vehicleObject.Name}");
                    Console.WriteLine($" vehicle speed : {vehicleObject.MaxAtmospheringSpeed}");
                    Console.WriteLine($" vehicle passengers : {vehicleObject.Passengers}");
                    Console.WriteLine($" vehicle model : {vehicleObject.Model}");
                    Console.WriteLine($" vehicle class : {vehicleObject.VehicleClass} \n");
                }
            }

            var serealized = JsonConvert.SerializeObject(filteredPeople);
            Console.WriteLine($"New Api {serealized}");
                        
        }
    }
}
