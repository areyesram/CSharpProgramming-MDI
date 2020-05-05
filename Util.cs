using System.Windows.Forms;

namespace areyesram
{
    internal static class Util
    {
        internal static bool Confirm(string message = "Are you sure?")
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                   DialogResult.Yes;
        }
        internal static void Warning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
