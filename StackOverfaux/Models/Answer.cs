using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverfaux.Models
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string TextBody { get; set; }
        public bool AcceptedAnswer { get; set; }
        public int Votes { get; set; }
        public DateTime Date { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Question Question { get; set; }

    }
}
