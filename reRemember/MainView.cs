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
            testingSavingAndLoading();
        }

        #region Main Functions
        public TreeNode LoadSubjectToNode(Subject subject)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            TreeNode node = new TreeNode(subject.Title);
            node.Tag = subject;
            foreach (Subject subSubject in subject.ChildSubjects)
            {
                node.Nodes.Add(LoadSubjectToNode(subSubject));
            }
            return node;
        }
        public RootSubject SubjectFromTree()
        {
            if (treeMain.Nodes.Count > 0)
                return (RootSubject)treeMain.Nodes[0].Tag;
            else
                return null;
        }
        #endregion

        #region Testing Code
        /// <summary>
        /// Testing saving code.
        /// </summary>
        void testingSavingAndLoading()
        {
            Card card1 = new Card("1", "1b");
            Card card2 = new Card("2", "2b");
            Card card3 = new Card("3", "3b");
            List<Card> cards = new List<Card>();
            cards.Add(card1);
            cards.Add(card2);
            cards.Add(card3);

            Subject calculus = new Subject("Calculus", new List<Subject>(), cards);
            List<Subject> subjects = new List<Subject>();
            subjects.Add(calculus);
            RootSubject math = new RootSubject("Math", subjects, new List<Card>());
            if (math.Save("C:\\Users\\grayma0717\\Desktop\\test.xml"))
                MessageBox.Show("yay");
            else
                MessageBox.Show("nay");

            var x = RootSubject.Open("C:\\Users\\grayma0717\\Desktop\\test.xml");
            treeMain.Nodes.Add(LoadSubjectToNode(x));
        }
        #endregion
    }
}
