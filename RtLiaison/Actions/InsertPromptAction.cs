using System.Windows;
using System.Windows.Interactivity;
using AurelienRibon.Ui.Terminal;

namespace RtLiaison.Actions
{
    /// <summary>
    /// TerminalのInsertNewPromptを実行するアクション
    /// </summary>
    public class InsertPromptAction : TriggerAction<Terminal>
    {
        public static readonly DependencyProperty TerminalProperty =
            DependencyProperty.Register("Terminal", typeof(Terminal), typeof(InsertPromptAction),new UIPropertyMetadata(null));

        public Terminal Terminal
        {
            get
            {
                return (Terminal)GetValue(TerminalProperty);
            }
            set
            {
                SetValue(TerminalProperty, value);
            }
        }

        protected override void Invoke(object parameter)
        {
            if (Terminal != null)
            {
                Terminal.InsertNewPrompt();
            }
        }
    }
}
