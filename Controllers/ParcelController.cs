using Belsis_Parselasyon_Backend.Data;
using Belsis_Parselasyon_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using System.Globalization;

namespace BelsisParselasyon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private ParcelDbContext _parcel;
        public ParcelController(ParcelDbContext parcel)
        {
            _parcel = parcel;
        }
        [HttpGet]
        public List<Parcel> GetAllParcels()
        {
            using (var ParcelDbContext = _parcel)
            {
                return ParcelDbContext.Parcels.ToList();
            }
        }

        [HttpGet("{id}")]
        public Parcel GetParcelById(int id)
        {
            using (var ParcelDbContext = _parcel)
            {
                return ParcelDbContext.Parcels.Find(id);
            }
        }

        [HttpGet]
        [Route("Intersect")]
        public Parcel DoesIntersect(float lon, float lat)
        {
            using (var ParcelDbContext = _parcel)
            {
                var SQL = $"SELECT gid as id,adm1_tr as il,adm1_tr as ilce,'0' as wkt FROM public.province_polygon WHERE ST_Intersects(geom, ST_SetSRID(ST_MakePoint({lon.ToString().Replace(",", ".")}, {lat.ToString().Replace(",", ".")}), 4326)) ORDER BY gid ASC  ";
                var result = ParcelDbContext.Parcels.FromSqlRaw(SQL);
                return result.FirstOrDefault(); 
            }
        }



        [HttpPost]
        public IActionResult AddParcel(Parcel parcel)
        {
            using (var ParcelDbContext = _parcel)
            {
                ParcelDbContext.Parcels.Add(parcel);
                ParcelDbContext.SaveChanges();
                return Ok(parcel);
            }
        }

        [HttpDelete]
        public void DeleteParcel(Parcel parcel)
        {
            using (var ParcelDbContext = _parcel)
            {
                ParcelDbContext.Parcels.Remove(parcel);
                ParcelDbContext.SaveChanges();
            }
        }

        [HttpPost]
        [Route("update")]
        public void UpdateParcel(Parcel parcel)
        {
            using (var ParcelDbContext = _parcel)
            {
                ParcelDbContext.Parcels.Update(parcel);
                ParcelDbContext.SaveChanges();
            }
        }
    }
}
