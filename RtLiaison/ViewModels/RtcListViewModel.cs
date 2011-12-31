using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Data;
using Livet;
using Livet.Commands;
using ReactiveRTM.Core;

namespace RtLiaison.ViewModels
{
    public class RtcListViewModel : ViewModel
    {
        private readonly RtcManager _rtcManager;

        // MVVMアプリケーションでCollectionViewSourceを使う方法
        // http://www.silverlightplayground.org/post/2009/07/18/Use-CollectionViewSource-effectively-in-MVVM-applications.aspx
        public CollectionViewSource RtComponents { get; private set; }
        
        public RtcListViewModel(RtcManager manager)
        {
            _rtcManager = manager;

        }
    }
}
