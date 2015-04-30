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
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            Card card1 = new Card("1", "1b");
            Card card2 = new Card("2", "2b");
            Card card3 = new Card("3", "3b");
            List<Card> cards = new List<Card>();
            cards.Add(card1);
            cards.Add(card2);
            cards.Add(card3);

            Subject calculus = new Subject("Calculus", new List<Subject>, cards);
            List<Subject> subjects = new List<Subject>();
            subjects.Add(calculus);
            RootSubject math = new RootSubject("Math", subjects, new List<Card>);
        }
    }
}
