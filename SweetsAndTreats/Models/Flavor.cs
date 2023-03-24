using System.Collections.Generic;

namespace SweetsAndTreats.Models.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public string FlavorName { get; set; }
    public List<FlavorTreat> JoinEntities { get; set; }
  }
}