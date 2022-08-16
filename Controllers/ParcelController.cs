using Belsis_Parselasyon_Backend.Data;
using Belsis_Parselasyon_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        [HttpGet()]
        [Route("compare/{point_wkt}")]
        public bool IsInTurkey(string point_wkt)
        {
            //Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand("SELECT ST_Intersects(ST_SetSRID(ST_MakePoint(35.32596524698479, 37.015461417617914),4326), geom) FROM province_polygon where gid = 1");
            //    cmd.ExecuteNonQuery();
            if (point_wkt == "hello")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet()]
        [Route("intersect")]
        public bool DoesIntersect(string point_wkt)
        {
            //Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand("SELECT ST_Intersects(ST_SetSRID(ST_MakePoint(35.32596524698479, 37.015461417617914),4326), geom) FROM province_polygon where gid = 1");
            //cmd.ExecuteNonQuery();
            if (point_wkt == "hello")
            {
                return true;
            }
            else
            {
                return false;
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
