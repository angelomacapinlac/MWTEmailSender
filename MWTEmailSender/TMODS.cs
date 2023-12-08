using System.ComponentModel.DataAnnotations;

namespace MissedWork.Models.TMODSModels
{
    public class TMODS
    {
        [Key]
        public string EmpId { get; set; }
        public string LoginId { get; set; }
        public string PreferredName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string MgrId { get; set; }
    }
}
