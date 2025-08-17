using System.Configuration;
using System.Drawing;

namespace mRemoteNG
{


    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    [global::System.Configuration.SettingsProviderAttribute(typeof(mRemoteNG.Config.Settings.Providers.ChooseProvider))]
    internal sealed partial class Settings {
        
        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }

        //CBH 从字符串解析，获取自定义字体
        public static Font GetCustomFont(string fontInfo)
        {
            string[] array = fontInfo.Split(',');
            string familyName = array[0].Trim();
            float emSize = 8.25f;
            float.TryParse(array[1].Trim(), out emSize);
            int num = 0;
            int.TryParse(array[2].Trim(), out num);
            FontStyle fontStyle = FontStyle.Regular;
            if ((num & 1) != 0)
            {
                fontStyle |= FontStyle.Bold;
            }
            if ((num & 2) != 0)
            {
                fontStyle |= FontStyle.Italic;
            }
            if ((num & 4) != 0)
            {
                fontStyle |= FontStyle.Underline;
            }
            if ((num & 8) != 0)
            {
                fontStyle |= FontStyle.Strikeout;
            }
            return new Font(familyName, emSize, fontStyle, GraphicsUnit.Point, 0);
        }

    }
}
