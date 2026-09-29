using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Combine_Day_Sixteen_N_Tier_APIs.Models
{
    public class Supply
    {
        //when creating an entity, we always need a unique identifier
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public int Quantity {get; set;}
    }
}