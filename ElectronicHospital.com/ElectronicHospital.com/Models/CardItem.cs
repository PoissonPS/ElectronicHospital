using System;

namespace ElectronicHospital.com.Models
{
    public class CardItem
    {
        public long Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string UserName { get; set; }
        public string DoctorName { get; set; }
    }
}