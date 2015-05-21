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
    public partial class ResultView : Form
    {
        public ResultView()
        {
            InitializeComponent();
        }

        private void ResultView_Load(object sender, EventArgs e)
        {

        }

        public static void ShowResults(StudySession session)
        {
            ResultView results = new ResultView();
            int correct = session.SessionCards.Sum(x => x.CardStatus == (int)CardStatus.Correct ? 1 : 0);
            int incorrect = session.SessionCards.Sum(x => x.CardStatus == (int)CardStatus.Incorrect ? 1 : 0);
            results.textCorrect.Text = correct.ToString();
            results.textIncorrect.Text = incorrect.ToString();
            results.textPercentage.Text = ((int)((double)correct / (correct + incorrect) * 100)).ToString();
            results.ShowDialog();
        }
    }
}
