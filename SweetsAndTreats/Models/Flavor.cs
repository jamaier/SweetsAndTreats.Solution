using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetsAndTreats.Models.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "You must enter a flavor")]
    public string FlavorName { get; set; }
    public List<FlavorTreat> JoinEntities { get; set; }
  }
}