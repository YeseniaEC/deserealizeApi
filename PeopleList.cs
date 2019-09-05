using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleHttpClient
{
    public class Result
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public double Mass { get; set; }
        [JsonProperty("hair_color")]
        public string HairColor { get; set; }
        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }
        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }
        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public List<string> Films { get; set; }
        public List<string> Species { get; set; }
        [JsonProperty("vehicles")]
        public List<string> VehicleJson { get; set; }
        public List<string> Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        [JsonIgnore]
        public int NumberOfVehicles
        {
            get
            {
                return VehicleJson.Count;
            }
        }
    }

    public class PeopleList
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        [JsonProperty("results")]
        public List<Result> People { get; set; }
    }
}
