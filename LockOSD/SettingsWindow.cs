using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MrSmarty.CodeProject;

namespace LockOSD
{
    public partial class SettingsWindow : Form
    {
        FloatingOSDWindow _osdWindow = new FloatingOSDWindow();

        public SettingsWindow()
        {
            InitializeComponent();

            KeyboardHook hook = new KeyboardHook(KeyboardHook.Parameters.PassAllKeysToNextApp);
            hook.KeyIntercepted += new KeyboardHook.KeyboardHookEventHandler(hook_KeyIntercepted);
        }

        void hook_KeyIntercepted(KeyboardHook.KeyboardHookEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (int)Keys.CapsLock:
                    if (Console.CapsLock)
                        ShowOsdWindow("CAPSLOCK ON");
                    else
                        ShowOsdWindow("CAPSLOCK OFF");
                        break;
                case (int)Keys.Insert:
                    ShowOsdWindow("INSERT");
                    break;
            }
        }

        void ShowOsdWindow(string text)
        {
            Point point = new Point(0, 0);

            Font font = new Font(FontFamily.GenericSansSerif, 72, FontStyle.Bold);

            _osdWindow.Show(point, 255, Color.Red, font, 3000, FloatingWindow.AnimateMode.Blend, 0, text);
        }
    }
}