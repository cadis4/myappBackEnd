using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }
        public bool VerifyAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
