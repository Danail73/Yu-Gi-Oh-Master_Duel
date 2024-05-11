using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public abstract class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string CardText { get; set; }

        public DateTime ReleaseDate { get; set; }
        public Card() {}

        public Card(string name, string cardText)
            : this()
        {
            Name = name;
            CardText = cardText;
        }
    }
}
