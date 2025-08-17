/* 
 * http://www.csharp-examples.net/inputbox/ 
 * 
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using mRemoteNG.UI.Controls.Base;

namespace mRemoteNG.UI.Forms.Input
{
    internal static class input
    {
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            var form = new Form();
            var label = new NGLabel();
            var textBox = new NGTextBox();
            var buttonOk = new NGButton();
            var buttonCancel = new NGButton();

            label.Text = promptText;
            label.AutoSize = true;
            label.SetBounds(9, 20, 372, 13);

            textBox.Text = value;
            textBox.BorderStyle = BorderStyle.Fixed3D;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            textBox.SetBounds(12, 36, 372, 20);

            buttonOk.Text = Language.strButtonOK;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.FlatStyle = FlatStyle.System;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.SetBounds(309, 72, 75, 25);

            buttonCancel.Text = Language.strButtonCancel;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.FlatStyle = FlatStyle.System;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.SetBounds(228, 72, 75, 25);

            form.Text = title;
            form.ClientSize = new Size(400, 110);
            form.Controls.AddRange(new Control[] {label, textBox, buttonCancel, buttonOk});
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            form.BackColor = Themes.ThemeManager.getInstance().ActiveTheme.ExtendedPalette.getColor("Dialog_Background");
            form.ForeColor = Themes.ThemeManager.getInstance().ActiveTheme.ExtendedPalette.getColor("Dialog_Foreground");
            //CBH 字体（2个构造参数）
            form.Font = new Font("Segoe UI", 8.25f);
            //form.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));

            var dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}

