using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConsola.Models
{
    public class LoginViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }

    }
}

