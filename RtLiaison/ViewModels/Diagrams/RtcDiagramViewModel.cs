﻿using ReactiveRTM.Core;

namespace RtLiaison.ViewModels.Diagrams
{
    public class RtcDiagramViewModel : RtcViewModel
    {
        public RtcDiagramViewModel(ObservableComponent rtc, int x, int y)
            : base(rtc)
        {
            X = x;
            Y = y;



            OutPortViewModel = new PortViewModel() { X = x, Y = y };
            InPortViewModel = new PortViewModel() { X = x, Y = y };
        }


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

        public void Remove()
        {
            
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }


        public PortViewModel OutPortViewModel { get; set; }


        public PortViewModel InPortViewModel { get; set; }
    }
}
