using System.Collections.Generic;

namespace ElectronicHospital.com.Models
{
    public class UserAndCard
    {
        public User User { get; set; }
        public List<CardItem> Items { get; set; }
        public string Type { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}