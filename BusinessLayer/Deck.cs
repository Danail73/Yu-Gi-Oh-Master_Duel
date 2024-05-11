using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Deck
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<Card> Cards { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastEdited { get; set; }

        private Deck()
        {
            Cards = new List<Card>();
        }

        public Deck(string name)
            :this()
        {
            Name = name;
        }
    }
}
