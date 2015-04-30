using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reRemember.Classes
{
    public enum CardStatus
    {
        NotGuessed = 0,
        Correct = 1,
        Incorrect = 2
    }
    
    public class StudySession
    {
        //properties
        public Dictionary<Card, CardStatus> SessionCards { get; set; }
    }
}
