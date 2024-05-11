using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Trap:Card
    {
        [Required]
        public string Typing { get; set; }

        private Trap() { }

        public Trap(string name, string cardText, string typing)
            :base(name, cardText)
        {
            Typing = typing;
        }
    }
}
