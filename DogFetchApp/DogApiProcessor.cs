using DogFetchApp;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class DogApiProcessor
    {

        public static async Task<ObservableCollection<string>> LoadBreedList()
        {
            string url = $"https://dog.ceo/api/breeds/list/all";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                
                if (response.IsSuccessStatusCode)
                {
                    ObservableCollection<string> Breeds = new ObservableCollection<string>();

                    BreedModel result = await response.Content.ReadAsAsync<BreedModel>();
                    foreach(string b in result.Breed.Keys)
                    {
                        Breeds.Add(b);
                        foreach(string sb in result.Breed[b])
                        {
                            Breeds.Add(b + "/" + sb);

                        }
                    }
                    return Breeds;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            ///TODO : À compléter LoadBreedList
            /// Attention le type de retour n'est pas nécessairement bon
            /// J'ai mis quelque chose pour avoir une base
            /// TODO : Compléter le modèle manquant

        }

        public static async Task<string> GetImageUrl(string breed)
        {
            /// TODO : GetImageUrl()
            /// TODO : Compléter le modèle manquant
            return string.Empty;
        }

        
    }
}
