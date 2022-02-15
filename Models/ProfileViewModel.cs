using System;

namespace Skilled_Force.Models
{
    public class ProfileViewModel {     
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }

        public bool ShowUserId => !string.IsNullOrEmpty(userId);
    }
}
