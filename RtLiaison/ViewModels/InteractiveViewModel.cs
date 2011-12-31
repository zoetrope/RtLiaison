using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.ComponentModel;
using AurelienRibon.Ui.Terminal;
using Codeplex.Reactive;
using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;
using RtLiaison.Models;

namespace RtLiaison.ViewModels
{
    public class InteractiveViewModel : ViewModel
    {
        public ReactiveCommand<Terminal.CommandEventArgs> ExecuteCommand { get; private set; }

        public ReactiveProperty<string> Text { get; set; }

        public InteractiveViewModel()
        {
            ExecuteCommand = new ReactiveCommand<Terminal.CommandEventArgs>();
            Text = new ReactiveProperty<string>();

            var engine = new CSharpScriptEngine();

            ExecuteCommand.Subscribe(x => {
                Text.Value += engine.Execute(x.Command.Raw);
                Messenger.Raise(new InteractionMessage("InsertNewPrompt"));
            });
        }


    }

}
