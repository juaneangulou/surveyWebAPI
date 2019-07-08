using System;
using System.Collections.Generic;

namespace RealTimePoll.Models
{
    public partial class PulseSurveyDetail
    {
        public Guid PulseSurveyDetail1 { get; set; }
        public Guid PulseSurveyMasterId { get; set; }
        public bool Answer { get; set; }
    }
}
