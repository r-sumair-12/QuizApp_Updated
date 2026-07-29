using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Updated_App.Models
{
    internal class QuizQuestions
    {
        public string Statement { get; set;  }
        public string[] Options { get; set; } = new string[4];
        public string correctAnswer { get; set; }
    }
}
