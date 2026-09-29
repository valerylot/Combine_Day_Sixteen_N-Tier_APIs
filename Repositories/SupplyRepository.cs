using System.Data.Common;
using Combine_Day_Sixteen_N_Tier_APIs.Data;
using Combine_Day_Sixteen_N_Tier_APIs.Models;

namespace Combine_Day_Sixteen_N_Tier_APIs.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly AppDbContext _db;
        //CONSTRUCTOR runs once when the class is called automatically 
        //ASP.net Core hands us the database connection because we registered it in the Program.cs
        public SupplyRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Supply> GetAll()
        {
            return _db.Supplies.ToList();
        }

        public Supply? GetById(int id)
        {
            return _db.Supplies.FirstOrDefault(s => s.Id == id);
        }

        public Supply Add(Supply supply)
        {
            _db.Supplies.Add(supply);
            _db.SaveChanges();
            return supply;
        }

        public void Update(Supply supply)
        {
            //the supply came out of the DB thru getbyid so ef core is already tracking it
            //we just need to save the changes
            _db.SaveChanges();
        }

        public void Delete(Supply supply)
        {
            _db.Supplies.Remove(supply);
            _db.SaveChanges();
        }
    }
}