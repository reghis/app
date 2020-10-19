using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConsola.Config
{
    public class ApiKeyScheme : OpenApiSecurityScheme
    {
        public string In { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
