using System.Reactive.Linq;
using Livet;
using Livet.Commands;
using ReactiveRTM.Core;
using ReactiveRTM.Extensions;
using RtLiaison.ViewModels.Diagrams;

namespace RtLiaison.ViewModels
{
    public class RtcViewModel : ViewModel
    {
        private readonly ObservableComponent _rtComponent;

        public RtcViewModel(ObservableComponent rtc)
        {
            _rtComponent = rtc;


        }

    }
}
