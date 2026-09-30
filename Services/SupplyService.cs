
using Combine_Day_Sixteen_N_Tier_APIs.Dtos;
using Combine_Day_Sixteen_N_Tier_APIs.Models;
using Combine_Day_Sixteen_N_Tier_APIs.Repositories;

//Service is where the rules live and its where our DTOs and models meet
//Controllers <- DTO -> Services <- Models -> Repository

namespace Combine_Day_Sixteen_N_Tier_APIs.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _repository;

        public SupplyService(ISupplyRepository repository)
        {
            _repository = repository;
        }

        public List<SupplyReadDTO> GetAll()
        {
            //the list always comes back in alphabetical order
            //LINQ Select for every record in our DB we will do x to
            return _repository.GetAll()
            .OrderBy(s => s.Name)
            .Select(s => ToReadDTO(s)) //turn every model into a DTO
            .ToList();
        }

        public SupplyReadDTO? GetById(int id)
        {
            Supply? supply = _repository.GetById(id);

            if (supply is null)
            {
                return null;
            }

            return ToReadDTO(supply);
        }

        //Rules: We must have a name, and you can't stock fewer than 0
        //Rules 2: No 2 supplies can have the same name
        public SupplyReadDTO? Create(SupplyCreateDTO dto)
        {
            //we do not need this code anymore, this is being handled within the DTO itself
            // if(supply.Quantity <= 0 || string.IsNullOrWhiteSpace(supply.Name))
            // {
            //     return null;
            // }

            bool exists = _repository.GetAll().Any(s => s.Name.ToLower() == dto.Name.ToLower());

            //if a name already exists within our DB, we will return null
            if (exists)
            {
                return null;
            }

            //DTO -> Model

            Supply supply = new Supply();

            supply.Name = dto.Name;
            supply.Quantity = dto.Quantity;
            supply.StorageLocation = "Receiving Bay"; //everything new starts here

            //we are creating a new supply variable and storing our added supply
            Supply created = _repository.Add(supply);

            return ToReadDTO(created);
        }

        //Rules: You must take at least 1, and never more than what we have 
        public bool Withdraw(int id, int amount)
        {
            Supply? existing = _repository.GetById(id);

            if (existing == null || amount > existing.Quantity || amount <= 0)
            {
                return false;
            }
            existing.Quantity -= amount;
            _repository.Update(existing);
            return true;
        }

        public void Delete(int id)
        {
            Supply? supply = _repository.GetById(id);

            //if it is not null, we will delete it
            if (supply != null)
            {
                _repository.Delete(supply);
            }
        }

        //Our Helper Method that takes in our Supply Model and outputs our DTO
        private static SupplyReadDTO ToReadDTO(Supply supply)
        {
            SupplyReadDTO outputDTO = new SupplyReadDTO();
            outputDTO.Id = supply.Id;
            outputDTO.Name = supply.Name;
            outputDTO.Quantity = supply.Quantity;

            return outputDTO;

        }
    }
}