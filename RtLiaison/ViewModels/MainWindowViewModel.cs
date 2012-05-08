using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using ReactiveRTM.Corba;
using ReactiveRTM.Core;

namespace RtLiaison.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public DiagramViewModel DiagramViewModel { get; private set; }
        public NamingServiceTreeViewModel NamingServiceTreeViewModel { get; private set; }

        public MainWindowViewModel()
        {
            CorbaUtility.Initialize();

            DiagramViewModel = new DiagramViewModel(null);
            NamingServiceTreeViewModel = new NamingServiceTreeViewModel();
        }
    }
}
