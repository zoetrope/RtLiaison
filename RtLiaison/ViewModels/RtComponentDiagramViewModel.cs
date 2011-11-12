namespace RtLiaison.ViewModels
{
    public class RtComponentDiagramViewModel : RtComponentViewModel
    {
        public RtComponentDiagramViewModel(RtComponent rtc, int x, int y)
            : base(rtc)
        {
            X = x;
            Y = y;
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
    }
}
