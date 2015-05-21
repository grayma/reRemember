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
        bool isFileOpen { get { return !string.IsNullOrEmpty(currentOpenFilePath); } }
        bool edited = false;
        TreeNode lastSelectedNode = null;
        #endregion

        public MainView()
        {
            InitializeComponent();
        }

        #region Form Events
        private void MainView_Load(object sender, EventArgs e)
        {
            
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = askToSave();
        }

        List<Card> populateCards(Subject subject, bool includeSubCards=false)
        {
            List<Card> returnCards = new List<Card>();
            returnCards.AddRange(subject.Cards);
            if (includeSubCards)
            {
                foreach (Subject innerSubject in subject.ChildSubjects)
                    returnCards.AddRange(populateCards(innerSubject));
            }
            return returnCards;
        }

        private void treeMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lastSelectedNode = e.Node; //keeps track of last selected node
            listMain.Items.Clear();
            List<Card> cards = populateCards((Subject)lastSelectedNode.Tag);
            foreach (Card card in cards)
            {
                ListViewItem item = new ListViewItem(Helper.RtfToString(card.Front));
                item.SubItems.Add(Helper.RtfToString(card.Back));
                item.SubItems.Add(card.SubjectTitle);
                item.Tag = card;
                listMain.Items.Add(item);
            }
        }
        #endregion

        #region Main Loading/Saving Functions
        /// <summary>
        /// Throws edited flag and that the current form isn't saved.
        /// </summary>
        void doEdited()
        {
            edited = true;
            this.Text = "reRemember [Not Saved]";
        }
        
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
        void saveFile(bool saveAs = true)
        {
            if (!saveAs)
            {
                SubjectFromTree().Save(currentOpenFilePath);
                Helper.ShowInfo("Card set saved to " + currentOpenFilePath);
                edited = false;
                this.Text = "reRemember";
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
                    edited = false;
                    this.Text = "reRemember";
                }
            }
        }
        
        /// <summary>
        /// Asks to save
        /// </summary>
        /// <returns>Returns a true or false of whether or not the user canceled</returns>
        bool askToSave()
        {
            if (edited)
            {
                System.Windows.Forms.DialogResult dialogResult = MessageBox.Show("You haven't saved your changes.  Would you like to save?", "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    saveFile(string.IsNullOrEmpty(currentOpenFilePath)); //saves
                else if (dialogResult == System.Windows.Forms.DialogResult.No)
                    return false; //allow closing without saving
                else
                    return true; //cancels form closing
            }
            return false; //file saved
        }

        /// <summary>
        /// Opens a file to the TreeView.
        /// </summary>
        /// <param name="fileName">Path to file that will be opened.</param>
        void openFile(string fileName)
        {
            //clear list and tree
            treeMain.Nodes.Clear();
            listMain.Items.Clear();
            //open selected subject
            RootSubject openedSubject = RootSubject.Open(fileName);
            treeMain.Nodes.Add(LoadSubjectToNode(openedSubject));
            currentOpenFilePath = fileName;
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
            string name = Helper.InputBox("What would you like to name this new main subject?", "Subject Name");
            if (string.IsNullOrEmpty(name))
                return; //assume the user changed their mind and canceled creating a new subject
            treeMain.Nodes.Clear();
            listMain.Items.Clear();
            currentOpenFilePath = "";
            RootSubject subject = new RootSubject(name);
            TreeNode node = new TreeNode(subject.Title);
            node.Tag = subject;
            treeMain.Nodes.Add(node);
            doEdited();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (askToSave())
                return;
            ofd.Filter = fileFilter;
            ofd.Title = "Open a reRemember file.";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                openFile(ofd.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeMain.Nodes.Count > 0) //makes sure we aren't trying to save a file that doesn't exist
            {
                if (isFileOpen) //makes sure we have a file to save without save as
                    saveFile(false);
                else
                    saveFile();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //closes from menustrip (WHO DOES THIS?!)
        }
        #endregion

        #region Tree Events, Context Events, and Variables
        private void newSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if a current node is selected and get it
            //if not selected don't allow creation of root node
            TreeNode selectedNode = null;
            if (treeMain.SelectedNode != null)
                selectedNode = treeMain.SelectedNode;
            else
            {
                Helper.ShowError("You need to select a subject to create a new subject within.");
                return;
            }
            //if so get node, create new subject object, add to tree and add subject to tag, then select
            string name = Helper.InputBox("What would you like to name this new subject?", "Subject Name");
            if (string.IsNullOrEmpty(name))
                return; //assuming the user canceled
            else
            {
                Subject newSubject = new Subject(name);
                //get parent subject from parent node tag and add this to it
                Subject parentSubject = (Subject)selectedNode.Tag;
                parentSubject.ChildSubjects.Add(newSubject);
                selectedNode.Tag = parentSubject;
                //create new child node and add it
                TreeNode child = new TreeNode(name);
                child.Tag = newSubject;
                selectedNode.Nodes.Add(child);
                if (!selectedNode.IsExpanded)
                    selectedNode.Expand();
                edited = true; //edit flag
            }
        }

        private void deleteSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if a current node is selected and get it
            TreeNode selectedNode = null;
            if (treeMain.SelectedNode != null)
                selectedNode = treeMain.SelectedNode;
            else
            {
                Helper.ShowError("You need to select a subject to delete.");
                return;
            }
            //if root or not selected don't allow deletion
            if (selectedNode.Level == 0) //root node
            {
                Helper.ShowError("You can't delete the root subject, the file itselt must be deleted.");
                return;
            }
            //if valid remove node and remove it from parent node tag
            ((Subject)selectedNode.Parent.Tag).ChildSubjects.Remove((Subject)selectedNode.Tag);
            selectedNode.Remove();
            //edit flag
            doEdited();
        }

        private void editSubjectNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if a current node is selected and get it
            //if not don't allow
            TreeNode selectedNode = null;
            if (treeMain.SelectedNode != null)
                selectedNode = treeMain.SelectedNode;
            else
            {
                Helper.ShowError("You need to select a subject to delete.");
                return;
            }
            //if valid edit input box to edit node name
            string name = Helper.InputBox("What would you like to rename this new subject?", "Subject Name");
            selectedNode.Text = name;
            ((Subject)selectedNode.Tag).Title = name;
            if (selectedNode.Level > 0) //can't fix a root nodes parent because it is an orphan
                ((Subject)selectedNode.Parent.Tag).ChildSubjects[((Subject)selectedNode.Parent.Tag).ChildSubjects.IndexOf((Subject)selectedNode.Tag)] = (Subject)selectedNode.Tag; //ew there has to be a better way to do this
            //edit flag
            doEdited();
        }

        private void studySubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create menu/form to ask which method they'd like to study by
            System.Windows.Forms.DialogResult dialogResult =
                MessageBox.Show("Would you like to study this subject's child subjects along with it?",
                "Studying Options", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                return; //no studying today
            bool includeChildren = dialogResult == System.Windows.Forms.DialogResult.Yes ? true : false;
            //in the future add other study methods
            //hide main form, create study dialog, and let study session occur
            this.Hide();
            StudySession session = StudyView.CreateSession(populateCards((Subject)lastSelectedNode.Tag, includeChildren));
            //get and display results
            ResultView.ShowResults(session);
            //add study session to past study sessions
            ((RootSubject)treeMain.Nodes[0].Tag).PastStudySessions.Add(session);
            //show main form and edit flag or prompt for saving
            doEdited();
        }
        #endregion

        #region List Context Events
        private void newCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make sure subject is selected and get it
            if (lastSelectedNode == null)
            {
                Helper.ShowError("You must select a subject to work on cards with.");
                return;
            }
            //add card to list view and tag of selected node
            Card newCard = EditingView.GetCard();
            if (string.IsNullOrWhiteSpace(Helper.RtfToString(newCard.Front)) || string.IsNullOrWhiteSpace(Helper.RtfToString(newCard.Back)))
                return; //don't edit 
            newCard.SubjectTitle = ((Subject)lastSelectedNode.Tag).Title;
            ListViewItem item = new ListViewItem(Helper.RtfToString(newCard.Front));
            item.SubItems.Add(Helper.RtfToString(newCard.Back));
            item.SubItems.Add(newCard.SubjectTitle);
            item.Tag = newCard;
            listMain.Items.Add(item);
            ((Subject)lastSelectedNode.Tag).Cards.Add(newCard);
            //edited flag
            doEdited();
        }

        private void deleteCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make sure card is selected and get it
            ListViewItem selectedItem;
            if (listMain.SelectedItems.Count > 0)
                selectedItem = listMain.SelectedItems[0];
            else
                return;
            //remove from listview and tag of selected node
            selectedItem.Remove();
            ((Subject)lastSelectedNode.Tag).Cards.Remove((Card)selectedItem.Tag);
            //edited flag
            doEdited();
        }

        private void editCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make sure card is selected and get it
            ListViewItem selectedItem;
            if (listMain.SelectedItems.Count > 0)
                selectedItem = listMain.SelectedItems[0];
            else
                return;
            Card card = (Card)selectedItem.Tag;
            //editing form loaded with card in it
            //get edited card and save its data
            Card newCard = EditingView.GetCard(card, false);
            if (string.IsNullOrWhiteSpace(Helper.RtfToString(newCard.Front)) || string.IsNullOrWhiteSpace(Helper.RtfToString(newCard.Back)))
                return; //don't edit 
            ((Subject)lastSelectedNode.Tag).Cards[((Subject)lastSelectedNode.Tag).Cards.IndexOf(card)] = newCard;
            ListViewItem item = new ListViewItem(Helper.RtfToString(newCard.Front));
            item.SubItems.Add(Helper.RtfToString(newCard.Back));
            item.SubItems.Add(newCard.SubjectTitle);
            item.Tag = newCard;
            listMain.Items.Insert(selectedItem.Index, item);
            selectedItem.Remove();
            //edited flag
            doEdited();
        }
        #endregion
    }
}
