using System;
using System.Collections.Generic;

namespace RealTimePoll.Models
{
    public partial class PulseSurveyMaster
    {
        public Guid PulseSurveyMasterId { get; set; }
        public string QuestionName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateClose { get; set; }
        public bool Isdone { get; set; }
    }
}
