using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLayer
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string MainType { get; set; }

        public string? Type { get; set; }
        public string? Attribute { get; set; }
        public string? Monster_Typing { get; set; }
        public int Level { get; set; }
        public uint ATK { get; set; }
        public uint DEF { get; set; }
        public string? Spell_Typing { get; set; }
        public string? Trap_Typing { get; set; }
        public string? PendulumEffect { get; set; }

        [Required]
        public string CardText { get; set; }

        public DateTime ReleaseDate { get; set; }
        public Card() {}

        public Card(string name, string cardText, string mainType)
            : this()
        {
            Name = name;
            CardText = cardText;
            MainType = mainType;
        }
    }
}
