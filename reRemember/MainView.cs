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
        #region Variables
        const string fileFilter = "reRemember XML (*.rrxml)|*.rrxml";
        string currentOpenFilePath = "";
        bool isFileOpen { get { return string.IsNullOrEmpty(currentOpenFilePath); } }
        #endregion

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            //testingSavingAndLoading();
            new EditingView().ShowDialog();
        }

        #region Main Loading/Saving Functions
        /// <summary>
        /// Loads a TreeNode recursively from a subject class.
        /// </summary>
        /// <param name="subject">Subject to open from.</param>
        /// <returns>TreeNode recursively populated.</returns>
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

        /// <summary>
        /// Gets RootSubject from treeMain.
        /// </summary>
        /// <returns>Returns RootSubject from treeMain.</returns>
        public RootSubject SubjectFromTree()
        {
            if (treeMain.Nodes.Count > 0)
                return (RootSubject)treeMain.Nodes[0].Tag;
            else
                return null;
        }

        /// <summary>
        /// Saves file to filePath parameter if used, if not it's saved using a SaveFileDialog.
        /// </summary>
        /// <param name="filePath">File path to save to.</param>
        void saveFile(bool saveAs)
        {
            if (!saveAs)
            {
                SubjectFromTree().Save(currentOpenFilePath);
                Helper.ShowInfo("Card set saved to " + currentOpenFilePath);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = fileFilter;
                sfd.Title = "Save a reRemember file.";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SubjectFromTree().Save(sfd.FileName);
                    currentOpenFilePath = sfd.FileName;
                    Helper.ShowInfo("Card set saved to " + currentOpenFilePath);
                }
            }
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

        #region Main Menu Code Events
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeMain.Nodes.Clear();
            listMain.Items.Clear();
            currentOpenFilePath = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = fileFilter;
            ofd.Title = "Open a reRemember file.";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //clear list and tree
                treeMain.Nodes.Clear();
                listMain.Items.Clear();
                //open selected subject
                RootSubject openedSubject = RootSubject.Open(ofd.FileName);
                treeMain.Nodes.Add(LoadSubjectToNode(openedSubject));
                currentOpenFilePath = ofd.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeMain.Nodes.Count > 0) //makes sure we aren't trying to save a file that doesn't exist
            {
                if (isFileOpen) //makes sure we have a file to save without save as
                    saveFile(false);
                else
                    saveFile(true);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeMain.Nodes.Count > 0) //makes sure we aren't trying to save a file that doesn't exist
                saveFile(true);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Tree Context Events
        private void newSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editSubjectNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region List Context Events
        private void newCardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteCardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
