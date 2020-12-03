using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETD_Lab5.Models
{
    public class CompletedPrompts
    {
        [Key]
        public int completed_id { get; set; }
        //Foreign Key from Prompts Model
        public int p_id { get; set; }
        //The prompt to hold
        public Prompts prompts { get; set; }

        public string book_name { get; set; }

        public string author_name { get; set; }

        public int rating { get; set; }
    }
}
