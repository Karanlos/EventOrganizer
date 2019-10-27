using dashmodule.eventorgranizer.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EventOrganizer.Connector
{
    public class OpenBreweryDbConnector : IOpenBreweryDbConnector
    {
        public HttpMessageHandler HttpMessageHandler { private get; set; }
        private ILogger Log { get; set; }

        public OpenBreweryDbConnector(ILogger log)
        {
            Log = log;
        }

        private HttpClient GetClient
        {
            get
            {
                if (HttpMessageHandler != null)
                {
                    return new HttpClient(HttpMessageHandler);
                }
                else
                {
                    return new HttpClient();
                }
            }
        }

        public async Task<List<Brewery>> GetBreweriesAsync(int? page, int? pageSize, string filterCity, string filterState, string filterName, string filterType, string filterTag, string sort)
        {

            using (var httpClient = GetClient)
            {
                // TODO: Mode this out into a configuration
                var builder = new UriBuilder
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = -1,
                    Host = "api.openbrewerydb.org",
                    Path = "breweries",
                };
                var query = HttpUtility.ParseQueryString(builder.Query);

                query["page"] = page?.ToString();
                query["per_page"] = pageSize?.ToString();
                query["by_city"] = filterCity;
                query["by_state"] = filterState;
                query["by_name"] = filterName;
                query["by_tag"] = filterTag;
                query["by_type"] = filterType;

                Log.LogInformation($"Getting brewery venues with the following parameters - Page: {page}, PageSize: {pageSize}, FilterCity: {filterCity}, FilterState: {filterState}, FilterName: {filterName}, FilterType: {filterType}, FilterTag: {filterTag}, Sort: {sort}");
                using (var response = await httpClient.GetAsync(builder.ToString()))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<List<Brewery>>(await response.Content.ReadAsStringAsync());
                    }
                    //TODO: Error handling, what if the status code is 4xx or 5xx?
                    Log.LogError($"Statuscode was not successfull: {response.StatusCode}");
                    throw new Exception("Not Suppose to happen!");
                }
            }
        }
    }
}
