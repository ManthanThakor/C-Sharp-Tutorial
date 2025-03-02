using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TokenResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
