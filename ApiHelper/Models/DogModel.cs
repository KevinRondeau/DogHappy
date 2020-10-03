using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiHelper.Models
{
    class DogModel
    {
        [JsonProperty("message")] public Dictionary<string, List<string>> Breed { get; set; }
    }
}
