using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverfaux.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string BodyText { get; set; }
        public int Votes { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
