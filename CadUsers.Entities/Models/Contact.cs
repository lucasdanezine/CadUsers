using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadUsers.Entities.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Phone { get; set; }
        public User User { get; set; }
    }
}
