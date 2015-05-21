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
        List<Card> studyCards = new List<Card>();
        Card currentCard
        {
            get
            {
                return studyCards[currentCardIndex];
            }
            set
            {
                studyCards[currentCardIndex] = value;
            }
        }
        int currentCardIndex = 0;
        int correct = 0;
        int incorrect = 0;
        bool showingFront = true;

        public StudyView()
        {
            InitializeComponent();
        }

        public StudyView(List<Card> cards)
        {
            this.studyCards = cards;
            InitializeComponent();
        }

        public static StudySession CreateSession(List<Card> cards)
        {
            StudyView study = new StudyView(cards);
            study.ShowDialog();
            StudySession session = new StudySession();
            session.SessionCards = study.studyCards;
            return session;
        }

        void updateStatus()
        {
            labelStatus.Text = "Card " + (currentCardIndex + 1).ToString() + "/" + studyCards.Count.ToString();
        }

        private void StudyView_Load(object sender, EventArgs e)
        {
            buttonPrevious.Enabled = false;
            if (studyCards.Count == 1)
                buttonNext.Enabled = false;
            currentCardIndex = 0;
            richCardView.Rtf = currentCard.Front;
            updateStatus();
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
            if (currentCardIndex != 0)
            {
                currentCardIndex--;
                this.richCardView.Rtf = currentCard.Front;
                updateStatus();
                buttonPrevious.Enabled = true;
            }
            buttonPrevious.Enabled = false;
        }

        void finish()
        {
            if (MessageBox.Show("Are you sure you want to quit?  All unfinished cards will be marked incorrect.",
                "Finish?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                return;
            foreach (Card card in studyCards)
                if (card.CardStatus == (int)CardStatus.NotGuessed)
                    card.CardStatus = (int)CardStatus.Incorrect;
            this.Close();
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            finish();
        }

        void next()
        {
            if (currentCardIndex != studyCards.Count - 1)
            {
                currentCardIndex++;
                this.richCardView.Rtf = currentCard.Front;
                updateStatus();
                buttonNext.Enabled = true;
                return;
            }
            finish();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            next();   
        }

        private void buttonCorrect_Click(object sender, EventArgs e)
        {
            currentCard.TotalAttempts++;
            currentCard.CorrectAttempts++;
            currentCardIndex++;
            next();
        }

        private void buttonIncorrect_Click(object sender, EventArgs e)
        {
            currentCard.TotalAttempts++;
            currentCardIndex++;
            next();
        }
    }
}
