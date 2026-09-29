using Combine_Day_Sixteen_N_Tier_APIs.Models;

namespace Combine_Day_Sixteen_N_Tier_APIs.Repositories
{
    public interface ISupplyRepository
    {
        List<Supply> GetAll();
        Supply? GetById(int id);
        Supply Add (Supply supply);
        void Update (Supply supply);
        void Delete (Supply supply);
    }
}