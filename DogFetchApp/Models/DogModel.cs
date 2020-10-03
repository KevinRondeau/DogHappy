using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogFetchApp
{
    class DogModel
    {
        [JsonProperty("message")] public Dictionary<string, List<string>> Breed { get; set; }
    }
}
