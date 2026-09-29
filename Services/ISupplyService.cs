using Combine_Day_Sixteen_N_Tier_APIs.Models;

namespace Combine_Day_Sixteen_N_Tier_APIs.Services
{
    public interface ISupplyService
    {
        List<Supply> GetAll();

        Supply? GetById(int id);

        Supply Create(Supply supply);

        bool Withdraw(Supply supply, int amount); //false if there isn't enough to withdraw

        void Delete(Supply supply);
    }
}