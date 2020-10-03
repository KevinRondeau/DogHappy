using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogFetchApp
{
    public class BreedModel
    {
        [JsonProperty("message")] public Dictionary<string,List<string>> Breed { get; set; }
    }
}
