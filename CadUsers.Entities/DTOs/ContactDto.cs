using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadUsers.Entities.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Phone { get; set; }
    }
}
