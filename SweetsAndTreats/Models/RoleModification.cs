using System.ComponentModel.DataAnnotations;

//Found using YogiHosting.com
namespace SweetsAndTreats.Models
{
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }
        
        public string[] AddIds { get; set; }
        
        public string[] DeleteIds { get; set; }
    }
}
