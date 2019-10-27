using System;
using dashmodule.eventorgranizer.Model;

namespace dashmodule.eventorgranizer.Convert {
    public class BreweryConverter {
        public Venue Convert(Brewery brewery) {
            return new Venue
            {
                Name = brewery.Name,
                Address = new Address
                {
                    City = brewery.City,
                    State = brewery.State,
                    Country = brewery.Country,
                    PostalCode = brewery.PostalCode,
                    Street = brewery.Street,
                },
                Website = brewery.WebsiteUrl,
            }; 
        }

        public Brewery Convert(Venue venue) {
            throw new NotImplementedException("Not implemented");
        }
    }
}