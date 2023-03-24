using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetsAndTreats.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "You must enter a flavor")]
    public string FlavorName { get; set; }
    public List<TreatFlavor> JoinEntities { get; set; }
  }
}