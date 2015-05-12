using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reRemember.Classes
{
    [Serializable]
    public class Card
    {
        //constructors
        public Card() { } //needed for serialization
        public Card(string front, string back)
        {
            this.Front = front;
            this.Back = back;
        }
        public Card(string front, string back, string subject)
        {
            this.Front = front;
            this.Back = back;
            this.SubjectTitle = subject;
        }

        //properties
        public string Front { get; set; } //front of the card
        public string Back { get; set; } //back of the card
        public int TotalAttempts { get; set; }
        public int CorrectAttempts { get; set; }
        public float Percentage
        {
            get
            {
                if (this.TotalAttempts == 0)
                    return 0;
                else
                    return CorrectAttempts / TotalAttempts;
            }

        } //property that calculates percentage correct
        public int CardStatus { get; set; } //cardstatus used when initialized in study session
        public string SubjectTitle { get; set; }
    }
}
