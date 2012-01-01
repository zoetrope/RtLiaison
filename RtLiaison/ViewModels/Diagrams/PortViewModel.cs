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

using RtLiaison.Models;

namespace RtLiaison.ViewModels.Diagrams
{
    public class PortViewModel : ViewModel
    {

        #region X変更通知プロパティ
        private int _x;
        public int X
        {
            get
            { return _x; }
            set
            {
                if (_x == value)
                    return;
                _x = value;
                RaisePropertyChanged("X");
            }
        }
        #endregion

        #region Y変更通知プロパティ
        private int _y;
        public int Y
        {
            get
            { return _y; }
            set
            {
                if (_y == value)
                    return;
                _y = value;
                RaisePropertyChanged("Y");
            }
        }
        #endregion
    }
}
