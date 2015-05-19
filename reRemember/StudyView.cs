using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using reRemember.Classes;

namespace reRemember
{
    public partial class StudyView : Form
    {
        public StudyView()
        {
            InitializeComponent();
        }

        List<Card> studyCards = new List<Card>();
        Card currentCard
        {
            get
            {
                return studyCards[currentCardIndex];
            }
        }
        int currentCardIndex = 0;
        bool showingFront = true;

        private void StudyView_Load(object sender, EventArgs e)
        {

        }

        public static StudyView CreateStudySession()
        {

        }

        private void buttonFlip_Click(object sender, EventArgs e)
        {
            if (showingFront)
                richCardView.Rtf = currentCard.Back;
            else
                richCardView.Rtf = currentCard.Front;
            showingFront = !showingFront;
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }

        private void buttonCorrect_Click(object sender, EventArgs e)
        {

        }

        private void buttonIncorrect_Click(object sender, EventArgs e)
        {

        }
    }
}
