using System.Windows;
using Codeplex.Reactive;
using Livet;
using ReactiveRTM.Core;
using RtLiaison.ViewModels.Diagrams;

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

            ConnectingLine = new ConnectorLineViewModel(100, 100, 300, 300);

            //Connectors.Add(testLine);

        }

        public RtcListViewModel RtcListViewModel
        {
            get;
            private set;
        }

        public void AddDiagram(string name, Point position)
        {
            Components.Add(new RtcDiagramViewModel(null, (int)position.X, (int)position.Y));
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

        public ConnectorLineViewModel ConnectingLine { get; set; }

        public void UpdateConnectingLine(double x1, double y1, double x2, double y2)
        {
            ConnectingLine.Update(x1, y1, x2, y2);
        }
    }
}
