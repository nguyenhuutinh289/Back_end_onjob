using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    public class ConnectionContext : ControllerBase
    {
        protected readonly DemoContext _context;
        public ConnectionContext(DemoContext context)
        {
            _context = context;
        }
    }
}
