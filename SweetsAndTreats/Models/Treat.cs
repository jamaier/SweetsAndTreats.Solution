using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetsAndTreats.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "You must enter a treat")]
    public string TreatName { get; set; }
    public List<FlavorTreat> JoinEntities { get; set; }
  }
}