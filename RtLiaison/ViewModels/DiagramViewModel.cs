using System.Windows;
using Codeplex.Reactive;
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

            RtcListViewModel = new RtcListViewModel(_rtcManager);

            Components = new ReactiveCollection<RtcDiagramViewModel>();

            Connectors = new ReactiveCollection<ConnectorLineViewModel>();

            var testLine = new ConnectorLineViewModel();
            testLine.Points.Add(new Point(100, 75));
            testLine.Points.Add(new Point(150, 25));
            testLine.Points.Add(new Point(200, 150));
            testLine.Points.Add(new Point(250, 25));
            testLine.Points.Add(new Point(300, 75));
            Connectors.Add(testLine);

        }

        public RtcListViewModel RtcListViewModel
        {
            get;
            private set;
        }

        public void AddDiagram(string name, Point position)
        {
            /*
            var rtc = _rtcManager.RtComponents.FirstOrDefault(x => x.NamingName == name);
            if (rtc != null)
            {
                Components.Add(new RtcDiagramViewModel(rtc, (int)position.X, (int)position.Y));
            }
            */
        }

        public ReactiveCollection<RtcDiagramViewModel> Components { get; private set; }

        public ReactiveCollection<ConnectorLineViewModel> Connectors { get; private set; }

    }
}
