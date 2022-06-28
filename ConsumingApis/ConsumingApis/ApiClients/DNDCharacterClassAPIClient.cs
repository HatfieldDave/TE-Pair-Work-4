using System;
using System.Collections.Generic;
using System.Text;
using ConsumingApis.Models;
using RestSharp;

namespace ConsumingApis.ApiClients
{
    class DNDCharacterClassAPIClient
    {
        private RestClient client;

        public DNDCharacterClassAPIClient()
        {
            this.client = new RestClient("https://www.dnd5eapi.co/api/");
        }

        public DNDClasses GetClass(string classType)
        {
            RestRequest request = new RestRequest($"classes/{classType}");

            IRestResponse<DNDClasses> response = client.Get<DNDClasses>(request);

            if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return response.Data;
        }

        public DNDSpells Getspell(string spellName)
        {
            RestRequest request = new RestRequest($"{spellName}");

        IRestResponse<DNDSpells> response = client.Get<DNDSpells>(request);

            if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return response.Data;
        }
}
}
