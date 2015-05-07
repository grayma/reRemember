using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reRemember.Classes
{
    public static class Helper
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static string RtfToString(string rtf)
        {
            return new RichTextBox() { Rtf = rtf }.Text;
        }
    }
}
