using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class RefreshTokenRecord
    {
        public string Token { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool IsRevoked { get; set; }
        public string? RevokedReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ReplacedByToken { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string? DeviceInfo { get; set; }
        public string? IpAddress { get; set; }
        public bool IsActive => !IsRevoked && ExpiryTime > DateTime.UtcNow;
    }
}
