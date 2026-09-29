
using Combine_Day_Sixteen_N_Tier_APIs.Models;
using Combine_Day_Sixteen_N_Tier_APIs.Repositories;

namespace Combine_Day_Sixteen_N_Tier_APIs.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _repository;

        public SupplyService(ISupplyRepository repository)
        {
            _repository = repository;
        }

        public List<Supply> GetAll()
        {
            //the list always comes back in alphabetical order
            return _repository.GetAll().OrderBy(s => s.Name).ToList();
        }

        public Supply? GetById(int id)
        {
            return _repository.GetById(id);
        }

        //Rules: We must have a name, and you can't stock fewer than 0
        public Supply? Create(Supply supply)
        {
            if(supply.Quantity <= 0 || string.IsNullOrWhiteSpace(supply.Name))
            {
                return null;
            }
            return _repository.Add(supply);
        }

        //Rules: You must take at least 1, and never more than what we have 
        public bool Withdraw(Supply supply, int amount)
        {
            if(amount > supply.Quantity || amount <= 0)
            {
                return false;
            }
            supply.Quantity -= amount;
            _repository.Update(supply);
            return true;
        }

        public void Delete(Supply supply)
        {
            _repository.Delete(supply);
        }
    }
}