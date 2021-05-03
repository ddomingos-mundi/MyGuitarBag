using MyGuitarBag.Api.Entities;
using MyGuitarBag.Api.ValueObjects;
using MyGuitarBag.Models;
using MyGuitarBag.Models.Request;
using MyGuitarBag.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGuitarBag.Api.Mock
{
    public class GuitarMockService : IGuitarMockService
    {
        private IEnumerable<Guitar> Guitars { get; set; }
        
        public GuitarMockService()
        {
            this.Seed();
        }

        public GetGuitarResponse Get(Guid id)
        {
            return HydrateGetGuitarResponse(this.Guitars.FirstOrDefault(guitar => guitar.Id == id));
        }

        public GetGuitarListResponse GetAll(GetGuitarFiltersRequest filters)
        {
            var query = this.Guitars;

            if (!string.IsNullOrEmpty(filters.Model))
            {
                query = query.Where(g => !string.IsNullOrWhiteSpace(g.Model)
                                            && g.Model.ToLower().Contains(filters.Model?.ToLower()));
            }

            if (!string.IsNullOrEmpty(filters.Color))
            {
                query = query.Where(g => !string.IsNullOrWhiteSpace(g.Color) 
                                            && g.Color.ToLower().Contains(filters.Color?.ToLower()));
            }

            int totalItems = query?.ToList()?.Count() ?? 0;

            int countToSkip = ((filters.Page - 1) * filters.Size);
            query = query.Skip(countToSkip).Take(filters.Size);

            var guitars = HydrateGetGuitarListResponse(query);

            return new GetGuitarListResponse(guitars, filters.Page, filters.Size, totalItems);
        }

        public GetGuitarResponse Create(PostGuitarRequest request)
        {
            var guitar = new Guitar
            {
                Id = Guid.NewGuid(),
                Brand = request.Brand,
                Color = request.Color,
                Description = request.Description,
                Model = request.Model,
                PhotoLinks = request.PhotoLinks,
                Pickups = request.Pickups?.Select(pickup => new Pickup
                {
                    Brand = pickup.Model,
                    Model = pickup.Model,
                    Year = pickup.Year
                }),
                StringQuantity = request.StringQuantity,
                Year = request.Year
            };

            ((List<Guitar>)this.Guitars).Add(guitar);

            return HydrateGetGuitarResponse(guitar);
        }

        public void Delete(Guid id)
        {
            ((List<Guitar>)this.Guitars).RemoveAll(guitar => guitar.Id == id);
        }

        private List<GetGuitarResponse> HydrateGetGuitarListResponse(IEnumerable<Guitar> query)
        {
            return query?.Select(guitar => HydrateGetGuitarResponse(guitar)).ToList();
        }

        private static GetGuitarResponse HydrateGetGuitarResponse(Guitar guitar)
        {
            if (guitar == null)
                return null;

            return new GetGuitarResponse
            {
                Brand = guitar.Brand,
                Color = guitar.Color,
                Description = guitar.Description,
                Id = guitar.Id,
                Model = guitar.Model,
                PhotoLinks = guitar.PhotoLinks,
                StringQuantity = guitar.StringQuantity,
                Year = guitar.Year,
                Pickups = guitar.Pickups?.Select(p => new PickupModel
                {
                    Brand = p.Brand,
                    Model = p.Model,
                    Year = p.Year

                })?.ToList()
            };
        }

        private void Seed()
        {
            #region Seed List
            var guitarFender = new Guitar
            {
                Id = Guid.NewGuid(),
                Brand = "Fender",
                Color = "Red",
                Year = 1977,
                Model = "Stratocaster",
                StringQuantity = 6,
                Pickups = new List<Pickup>
                {
                   new Pickup
                   {
                       Brand = "New caps",
                       Model = "Single",
                       Year = 2012

                   }
                },
                Description = "Guitarra lendária usada por grandes nomes do rock...",
                PhotoLinks = new string[] { }
            };

            var guitarFenderTele = new Guitar
            {
                Id = Guid.NewGuid(),
                Brand = "Fender",
                Color = "Natural",
                Year = 1975,
                Model = "Telecaster",
                StringQuantity = 6,
                Pickups = new List<Pickup>
                {
                   new Pickup
                   {
                       Brand = "New caps",
                       Model = "Single",
                       Year = 1980

                   }
                },
                Description = "Guitarra lendária usada por grandes nomes do rock...",
                PhotoLinks = new string[] { }
            };

            var guitarGibson = new Guitar
            {
                Id = Guid.NewGuid(),
                Brand = "Gibson",
                Color = "Black",
                Year = 1969,
                Model = "Les Paul",
                StringQuantity = 6,
                Pickups = new List<Pickup>
                {
                   new Pickup
                   {
                       Brand = "New caps",
                       Model = "Humbucker",
                       Year = 1970

                   }
                },
                Description = "Guitarra lendária usada por grandes nomes do rock...",
                PhotoLinks = new string[] { }
            };

            var guitarGibson2Necks = new Guitar
            {
                Id = Guid.NewGuid(),
                Brand = "Gibson",
                Color = "Red",
                Year = 1975,
                Model = "EDS-1275",
                StringQuantity = 18,
                Pickups = new List<Pickup>
                {
                   new Pickup
                   {
                       Brand = "New caps",
                       Model = "Humbucker",
                       Year = 1990

                   },
                   new Pickup
                   {
                       Brand = "New caps",
                       Model = "Single",
                       Year = 1980

                   }
                },
                Description = "Guitarra de 2 braços",
                PhotoLinks = new string[] { }
            };

            var guitarIbanez = new Guitar
            {
                Id = Guid.NewGuid(),
                Brand = "Ibanez",
                Color = "White",
                Year = 2000,
                Model = "RG550 - Super Stratocaster",
                StringQuantity = 6,
                Pickups = new List<Pickup>
                {
                   new Pickup
                   {
                       Brand = "New caps",
                       Model = "Humbucker",
                       Year = 1990

                   },
                   new Pickup
                   {
                       Brand = "New caps",
                       Model = "Single",
                       Year = 1980

                   }
                },
                Description = "Guitarra para rock metal",
                PhotoLinks = new string[] { }
            };
            #endregion

            this.Guitars = new List<Guitar>
            {
                guitarFender,
                guitarFenderTele,
                guitarGibson,
                guitarGibson2Necks,
                guitarIbanez
            };
        }
    }

    public interface IGuitarMockService
    {
        GetGuitarResponse Get(Guid id);
        GetGuitarListResponse GetAll(GetGuitarFiltersRequest filters);
        GetGuitarResponse Create(PostGuitarRequest request);
        void Delete(Guid id);
    }
}
