using Microsoft.AspNetCore.Mvc.Rendering;
using NostralogiaDAL.NostraGeoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class GeoFactory
    {
        private NostraGeoContext _context;
        public GeoFactory()
        {
            _context = new NostraGeoContext();
        }
        public List<SelectListItem> GetCountriesListCollection()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            List<Country> lstCountry = _context.Countries.OrderBy(x => x.CountryName).ToList();
            foreach(Country c in lstCountry)
            {
                lst.Add(new SelectListItem()
                {
                    Text = c.CountryName,
                    Value = c.Id.ToString()
                });
            }
            return lst;
        }
        public List<SelectListItem> GetStatesListCollection(int IdCountry)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            var lstData = _context.StateRegions.Where(x => x.CountryRef == IdCountry);
            if(lstData!=null)
            {

                lstData = lstData.OrderBy(x => x.StateRegion1);
            }
           
            foreach (StateRegion c in lstData)
            {
                lst.Add(new SelectListItem()
                {
                    Text = c.StateRegion1,
                    Value = c.Id.ToString()
                });
            }
            return lst;
        }
        public List<SelectListItem> GetCitiesListCollection(int IdCountry, int IdState=0)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            if (IdCountry > 0 || IdState > 0)
            {
                IQueryable<City> lstData = null;
                if (IdState > 0)
                {
                    lstData = _context.Cities.Where(x => x.RegionState == IdState);
                }
                else if (IdCountry > 0)
                {
                    lstData = _context.Cities.Where(x => x.Country == IdCountry);
                }
                if (lstData != null)
                {

                    lstData = lstData.OrderBy(x => x.CityName);
                }

                foreach (City c in lstData)
                {
                    lst.Add(new SelectListItem()
                    {
                        Text = c.CityName,
                        Value = c.Id.ToString()
                    });
                }
            }
            return lst;
        }

        public List<List<SelectListItem>> GetStatesCitiesByCountry(short? id)
        {
            short Id = id ?? 0;
            List<List<SelectListItem>> lstout = new List<List<SelectListItem>>();
            if (id > 0)
            {
                lstout.Add(GetStatesListCollection(Id));
                lstout.Add(GetCitiesListCollection(Id, 0));
            }
            return lstout;
        }
    }
}
