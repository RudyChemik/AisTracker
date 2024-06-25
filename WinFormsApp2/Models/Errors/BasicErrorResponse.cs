using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Models.Errors
{
    public class BasicErrorResponse
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
