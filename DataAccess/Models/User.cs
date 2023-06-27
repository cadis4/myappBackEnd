using DataAccesLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace DataAccesLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }

        public int? lastScorePseudocod { get; set; }

        public int? maxScorePseudocod { get; set; }

        public bool? pseudocodPassed { get; set; }

        public int? lastScoreCpp { get; set; }

        public int? maxScoreCpp { get; set; }

        public bool? cppPassed { get; set; }

        public int? lastScoreBD { get; set; }

        public int? maxScoreBD { get; set; }
        public bool? BDPassed { get; set; }

        public int? lastScoreAE { get; set; }

        public int? maxScoreAE { get; set; }

        public bool? AEPassed { get; set; }

        public int? lastScoreTB { get; set; }

        public int? maxScoreTB { get; set; }

        public bool? TBPassed { get; set; }

        public int? lastScoreTU { get; set; }

        public int? maxScoreTU { get; set; }

        public bool? TUPassed { get; set; }

        public int? lastScoreSC { get; set; }

        public int? maxScoreSC { get; set; }

        public bool? SCPassed { get; set; }

        public int? lastScoreRec { get; set; }

        public int? maxScoreRec { get; set; }

        public bool? recPassed { get; set; }

    }
}