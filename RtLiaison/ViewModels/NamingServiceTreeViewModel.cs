using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using ReactiveRTM.Corba;

namespace RtLiaison.ViewModels
{
    public class NamingServiceTreeViewModel : ViewModel
    {

        public ObservableCollection<TreeViewItemViewModel> NamingServiceTree { get; private set; }

        public NamingServiceTreeViewModel()
        {
            NamingServiceTree = new ObservableCollection<TreeViewItemViewModel>();

            NamingServiceTree.Add(
                new NamingServiceItemViewModel(
                    new CorbaNamingServiceClient("localhost", 2809)
                )
            );
        }
    }
}
