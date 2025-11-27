using mRemoteNG.Themes;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mRemoteNG.UI.Controls.Base
{
    //This class is only minimally themed as textboxes onPaint are hard to theme (system wm paint control most of the drawing process
    //There are some glitches on the initial draw of some controls
    public class NGTextBox : TextBox
    {
        private ThemeManager _themeManager; 

        public  NGTextBox()
        { 
            ThemeManager.getInstance().ThemeChanged += OnCreateControl;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl(); 
            _themeManager = ThemeManager.getInstance();
            if (!_themeManager.ThemingActive) return;
            if (_themeManager.ActiveTheme != null)
            {
                ForeColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Foreground");
                BackColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Background");
                Invalidate();
            }
        }
         


        protected override void OnEnabledChanged(EventArgs e)
        {
            _themeManager = ThemeManager.getInstance();
            if (_themeManager.ThemingActive)
            {
                _themeManager = ThemeManager.getInstance();
                if(_themeManager.ThemingActive)
                { 
                    if (Enabled)
                    {
                        ForeColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Foreground");
                        BackColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Background");
                    }
                    else
                    {
                        BackColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Disabled_Background");
                    }
                }
            }                
            base.OnEnabledChanged(e);
            Invalidate();
        }

        #region 设计期可见属性
        /// <summary>
        /// 是否启用数字限制（默认 true）
        /// </summary>
        [DefaultValue(false)]
        [Description("是否只允许输入数字")]
        public bool NumberOnly { get; set; } = false;

        /// <summary>
        /// 是否允许小数点
        /// </summary>
        [DefaultValue(false)]
        [Description("是否允许输入小数")]
        public bool AllowDecimal { get; set; }

        /// <summary>
        /// 是否允许负号
        /// </summary>
        [DefaultValue(false)]
        [Description("是否允许输入负数")]
        public bool AllowNegative { get; set; }
        #endregion

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!NumberOnly)
            {
                base.OnKeyPress(e);
                return;
            }

            char c = e.KeyChar;
            if (char.IsControl(c)) return;
            if (char.IsDigit(c)) return;

            if (AllowDecimal && c == '.' && Text.IndexOf('.') == -1) return;
            if (AllowNegative && c == '-' && SelectionStart == 0 && Text.IndexOf('-') == -1) return;

            e.Handled = true;
        }

        // 可选：粘贴时二次校验
        protected override void OnTextChanged(EventArgs e)
        {
            if (!NumberOnly || string.IsNullOrEmpty(Text)) return;

            string pattern = AllowDecimal
                ? (AllowNegative ? @"^-?\d+(\.\d+)?$" : @"^\d+(\.\d+)?$")
                : (AllowNegative ? @"^-?\d+$" : @"^\d+$");

            if (!Regex.IsMatch(Text, pattern))
            {
                int pos = SelectionStart;
                Text = Text.TrimEnd(Text[SelectionStart - 1]); // 简单回滚
                SelectionStart = Math.Max(0, pos - 1);
            }
        }

    }
}
