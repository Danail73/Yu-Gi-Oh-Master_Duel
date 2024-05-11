using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Monster:Card
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Attribute { get; set; }

        [Required]
        public string Typing { get; set; }

        public int Level { get; set; }
        public uint ATK { get; set; }
        public uint DEF { get; set; }

        private Monster() { }

        public Monster(string name, string cardText, string type, string attribute, string typing)
            :base(name, cardText)
        {
            Type = type;
            Attribute = attribute;
            Typing = typing;
        }
    }
}
