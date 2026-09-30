//what a client is allowed to SEND
//this will have no id (our DB picks it anyway) and no storagelocation (that is ours)
//even if the client wants to set those properties they cannot because we don't have them

using System.ComponentModel.DataAnnotations;

namespace Combine_Day_Sixteen_N_Tier_APIs.Dtos
{
    public class SupplyCreateDTO
    {
        //attributes are characteristics of our properties, it goes ABOVE the property we are setting
        [Required(ErrorMessage = "Every supply needs a name.")]
        public string Name {get; set;}
        [Range(1, 10000, ErrorMessage = "Quantity must be from 0 to 100000")]
        public int Quantity {get; set;}
    }
}