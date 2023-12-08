using System.ComponentModel.DataAnnotations;

namespace MissedWork.Models.gofrmrequestModels
{
    public class District_Hierarchy
    {
        [Key]
        public long Id { get; set; }
        public string CLLI { get; set; }
        public string MM_resource_Manager{ get; set; }
        public string MM_General_Manager_Id { get; set; }
        public string MM_General_Manager { get; set; }
        public string MM_Service_Area { get; set; }

    }
}
