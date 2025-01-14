using Imtahan_Sim_2.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Imtahan_Sim_2.Models
{
    public class TeamMember : BaseEntity
    {
        [Required, StringLength(20, ErrorMessage ="Max 20 element daxil etmek olar"), MinLength(3, ErrorMessage ="min 3 ola bilir")]

        public string Name { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
