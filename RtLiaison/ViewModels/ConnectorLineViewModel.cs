using System.Collections.ObjectModel;
using System.Windows;
using Livet;

namespace RtLiaison.ViewModels
{
    public class ConnectorLineViewModel : ViewModel
    {
        readonly ObservableCollection<Point> _points = new ObservableCollection<Point>();
        public ObservableCollection<Point> Points
        {
            get { return _points; } 
        }

    }
}
