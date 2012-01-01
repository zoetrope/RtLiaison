using System.Collections.Generic;
using System.Windows;
using Livet;

namespace RtLiaison.ViewModels.Diagrams
{
    public class ConnectorLineViewModel : ViewModel
    {
        public ConnectorLineViewModel(double x1, double y1, double x2, double y2)
        {
            Update(x1, y1, x2, y2);
        }

        #region StartPoint変更通知プロパティ
        private Point _StartPoint;

        public Point StartPoint
        {
            get
            { return _StartPoint; }
            set
            {
                if (EqualityComparer<Point>.Default.Equals(_StartPoint, value))
                    return;
                _StartPoint = value;
                RaisePropertyChanged("StartPoint");
            }
        }
        #endregion


        #region StartBezierPoint変更通知プロパティ
        private Point _StartBezierPoint;

        public Point StartBezierPoint
        {
            get
            { return _StartBezierPoint; }
            set
            { 
                if (EqualityComparer<Point>.Default.Equals(_StartBezierPoint, value))
                    return;
                _StartBezierPoint = value;
                RaisePropertyChanged("StartBezierPoint");
            }
        }
        #endregion


        #region EndBezierPoint変更通知プロパティ
        private Point _EndBezierPoint;

        public Point EndBezierPoint
        {
            get
            { return _EndBezierPoint; }
            set
            { 
                if (EqualityComparer<Point>.Default.Equals(_EndBezierPoint, value))
                    return;
                _EndBezierPoint = value;
                RaisePropertyChanged("EndBezierPoint");
            }
        }
        #endregion


        #region EndPoint変更通知プロパティ
        private Point _EndPoint;

        public Point EndPoint
        {
            get
            { return _EndPoint; }
            set
            { 
                if (EqualityComparer<Point>.Default.Equals(_EndPoint, value))
                    return;
                _EndPoint = value;
                RaisePropertyChanged("EndPoint");
            }
        }
        #endregion

        

        public void Update(double x1, double y1, double x2, double y2)
        {
            StartPoint = new Point(x1, y1);
            StartBezierPoint = new Point(x2, y1);
            EndBezierPoint = new Point(x1, y2);
            EndPoint = new Point(x2, y2);
        }
    }
}
