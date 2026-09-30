using Combine_Day_Sixteen_N_Tier_APIs.Dtos;
using Combine_Day_Sixteen_N_Tier_APIs.Models;

namespace Combine_Day_Sixteen_N_Tier_APIs.Services
{
    public interface ISupplyService
    {
        List<SupplyReadDTO> GetAll();

        SupplyReadDTO? GetById(int id);

        SupplyReadDTO Create(SupplyCreateDTO supply);

        bool Withdraw(int id, int amount); //false if there isn't enough to withdraw

        void Delete(int id);
    }
}