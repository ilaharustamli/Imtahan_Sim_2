using Imtahan_Sim_2.Models.Base;

namespace Imtahan_Sim_2.Models
{
    public class Position :BaseEntity
    {
        public string Name { get; set; }
        public List<TeamMember>TeamMembers { get; set; }
    }
}
