using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOS
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
