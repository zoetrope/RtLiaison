using System.Windows;
using Livet;
using ReactiveRTM.Core;

namespace RtLiaison.ViewModels
{
    public class DiagramViewModel : ViewModel
    {
        private RtcManager _rtcManager;

        public DiagramViewModel(RtcManager rtcManager)
        {
            _rtcManager = rtcManager;

            RtComponentListViewModel = new RtComponentListViewModel(_rtcManager);

            Components = new DispatcherCollection<RtComponentDiagramViewModel>(DispatcherHelper.UIDispatcher);

            Connectors = new DispatcherCollection<ConnectorLineViewModel>(DispatcherHelper.UIDispatcher);

            var testLine = new ConnectorLineViewModel();
            testLine.Points.Add(new Point(100, 75));
            testLine.Points.Add(new Point(150, 25));
            testLine.Points.Add(new Point(200, 150));
            testLine.Points.Add(new Point(250, 25));
            testLine.Points.Add(new Point(300, 75));
            Connectors.Add(testLine);

        }

        public RtComponentListViewModel RtComponentListViewModel
        {
            get;
            private set;
        }

        public void AddDiagram(string name, Point position)
        {
            var rtc = _rtcManager.RtComponents.FirstOrDefault(x => x.NamingName == name);
            if (rtc != null)
            {
                Components.Add(new RtComponentDiagramViewModel(rtc, (int)position.X, (int)position.Y));
            }
        }

        public DispatcherCollection<RtComponentDiagramViewModel> Components { get; private set; }

        public DispatcherCollection<ConnectorLineViewModel> Connectors { get; private set; }

    }
}
