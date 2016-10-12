using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedWipeReborn
{
    internal static class FormExtensions
    {
        public static void MatchCenterFrom(this Form targetForm, Form parentForm)
        {
            targetForm.Left = (parentForm.Left + (parentForm.Width / 2)) - (targetForm.Width / 2);
            targetForm.Top = (parentForm.Top + (parentForm.Height / 2)) - (targetForm.Height / 2);
            targetForm.StartPosition = FormStartPosition.Manual;
        }
    }
}
