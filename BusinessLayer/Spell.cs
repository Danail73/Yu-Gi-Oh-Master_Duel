using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Spell:Card
    {
        [Required]
        public string Typing { get; set; }

        private Spell() { }

        public Spell(string name, string cardText, string typing)
            :base(name, cardText)
        {
            Typing = typing;
        }
    }
}
