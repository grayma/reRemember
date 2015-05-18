using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using reRemember.Classes;
using Microsoft.VisualBasic;
using System.IO;

namespace reRemember
{
    public partial class EditingView : Form
    {
        bool isSuperscript = false;
        bool isSubscript = false;
        bool saved = false; //flag set to true if the save card menu button is clicked
        bool isNewCard = true; //set to false if the card object is just being edited

        public EditingView()
        {
            InitializeComponent();
        }

        private void EditingView_Load(object sender, EventArgs e)
        {
            if (!isNewCard)
                return;
            cardBackRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            cardBackRichTextBox.Font = new Font("Arial", 15);
            cardFrontRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            cardFrontRichTextBox.Font = new Font("Arial", 15);
        }

        public static Card GetCard(Card oldCard = null, bool newCard = true)
        {
            EditingView editor = new EditingView();
            editor.isNewCard = newCard;
            string initialFrontText = newCard ? "" : oldCard.Front;
            string initialBackText = newCard ? "" : oldCard.Back;
            editor.cardFrontRichTextBox.Rtf = initialFrontText;
            editor.cardBackRichTextBox.Rtf = initialBackText;
            editor.ShowDialog();
            Card returnNewCard = new Card(editor.cardFrontRichTextBox.Rtf, editor.cardBackRichTextBox.Rtf);
            if (!newCard)
            {
                returnNewCard.SubjectTitle = oldCard.SubjectTitle;
                returnNewCard.CorrectAttempts = oldCard.CorrectAttempts;
                returnNewCard.TotalAttempts = oldCard.TotalAttempts;
            }
            return returnNewCard;

        }

        #region Formatting Options
        private void superscript()
        {
            //make sure not subscript
            if (isSubscript)
                subscript();
            //make it superscript
            if (!isSuperscript)
            {
                cardBackRichTextBox.SelectionCharOffset += 5;
                cardBackRichTextBox.SelectionFont = new Font("Arial", 10);
            }
            else
            {
                cardBackRichTextBox.SelectionCharOffset -= 5;
                cardBackRichTextBox.SelectionFont = new Font("Arial", 15);
            }
            isSuperscript = !isSuperscript;
        }
        private void superscriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            superscript();
        }

        private void subscript()
        {
            //make sure not superscript
            if (isSuperscript)
                superscript();
            //make it subscript
            if (!isSubscript)
            {
                cardBackRichTextBox.SelectionCharOffset += -5;
                cardBackRichTextBox.SelectionFont = new Font("Arial", 10);
            }
            else
            {
                cardBackRichTextBox.SelectionCharOffset -= -5;
                cardBackRichTextBox.SelectionFont = new Font("Arial", 15);
            }
            isSubscript = !isSubscript;
        }
        private void subscriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subscript();
        }
        #endregion

        #region Saving and Exiting
        private void saveCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cardFrontRichTextBox.Text == "" || cardBackRichTextBox.Text == "")
            {
                Helper.ShowError("One or more of the fields are empty.  Please fill them in or exit with the exit button.");
                return;
            }
            saved = true;
            this.Close();
        }

        private void EditingView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                if (MessageBox.Show("Are you sure you want to exit without saving the card?",
                    "Warning!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    cardBackRichTextBox = new RichTextBox(); //to clear the rtf
                    cardFrontRichTextBox = new RichTextBox();
                    return;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        #endregion

        #region Image Code
        /// <summary>
        /// Inserts image into rich text box from file.
        /// Idea from:  http://stackoverflow.com/a/1963567
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void insertImageFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    IDataObject originalData = Clipboard.GetDataObject();
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "Image Files (.jpg, .jpeg, .png, .gif) | *.jpg *.jpeg *.png *.gif";
        //    ofd.Title = "Select an Image";
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            //get the image
        //            Image image = Image.FromFile(ofd.FileName);
        //            //make sure the image fits nicely
        //            image = validateImageSize(image);
        //            //paste it
        //            Clipboard.SetImage(image);
        //            cardBackRichTextBox.Paste();
        //            Clipboard.SetDataObject(originalData);
        //        }
        //        catch (Exception ex)
        //        {
        //            Helper.ShowError(ex.Message);
        //        }
        //    }
        //}
        /// <summary>
        /// Makes sure the image fits the rich text box.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        //Image validateImageSize(Image image)
        //{
        //    Size size = image.Size;
        //    if (image.Width > cardBackRichTextBox.Width)
        //    {
        //        int newWidth = cardBackRichTextBox.Width - 10; //5px for padding on each size
        //        float changeFactor = newWidth / image.Width;
        //        int newHeight = (int)Math.Round(changeFactor * image.Height);
        //        size = new Size(newWidth, newHeight);
        //    }
        //    return (Image)(new Bitmap(new Bitmap(image), size));
        //}
        /// <summary>
        /// Inserts image into rich text box from URL.
        /// Idea from:  http://stackoverflow.com/a/1963567
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void insertImageFromURLToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    IDataObject originalData = Clipboard.GetDataObject();
        //    string url = Interaction.InputBox("Please give me a URL:", "Image From URL", "");
        //    Uri uri;
        //    if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
        //    {
        //        Helper.ShowError("The input wasn't a valid URL!");
        //        return;
        //    }
        //    Helper.ShowInfo("Depending on internet speed, downloading the image could take some time.");
        //    try
        //    {
        //        //download the image
        //        WebClient imageDownloader = new WebClient();
        //        Image image = Image.FromStream(new MemoryStream(imageDownloader.DownloadData(uri)));
        //        //make sure the size fits nicely
        //        image = validateImageSize(image);
        //        //paste it
        //        Clipboard.SetImage(image);
        //        cardBackRichTextBox.Paste();
        //        Clipboard.SetDataObject(originalData);
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.ShowError(ex.Message);
        //    }
        //}
        #endregion
    }
}