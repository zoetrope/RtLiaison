using System.Reactive.Linq;
using Livet;
using Livet.Commands;

namespace RtLiaison.ViewModels
{
    public class RtComponentViewModel : ViewModel
    {
        private readonly RtComponent _rtComponent;

        public RtComponentViewModel(RtComponent rtc)
        {
            _rtComponent = rtc;
            IsSelected = true;

            //TODO: Propertiesの内容が変更されて例外が発生することがある。
            Properties = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                _rtComponent.Properties,
                m => new NameValueViewModel(m),
                DispatcherHelper.UIDispatcher);

            Configuration = new ConfigurationViewModel(_rtComponent.ConfigurationClient);

            Ports = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                _rtComponent.Ports,
                port => new PortViewModel(port),
                DispatcherHelper.UIDispatcher);

            DataInPorts = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                _rtComponent.DataInPorts,
                port => new DataInPortViewModel(port),
                DispatcherHelper.UIDispatcher);

            DataOutPorts = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                _rtComponent.DataOutPorts,
                port => new DataOutPortViewModel(port),
                DispatcherHelper.UIDispatcher);

            ServiceConsumers = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                _rtComponent.ServiceConsumers,
                port => new ServiceConsumerViewModel(port),
                DispatcherHelper.UIDispatcher);

            ServiceProviders = ViewModelHelper.CreateReadOnlyDispatcherCollection(
                _rtComponent.ServiceProviders,
                port => new ServiceProviderViewModel(port),
                DispatcherHelper.UIDispatcher);

            ViewModelHelper.BindNotifyChanged(rtc, this, (sender, e) => RaisePropertyChanged(e.PropertyName));


        }

        private bool _isSelected;
        public bool IsSelected
        {
            get
            { return _isSelected; }
            set
            {
                if (_isSelected == value)
                    return;
                _isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        public bool IsAlive
        {
            get { return _rtComponent.IsAlive; }
            set { _rtComponent.IsAlive = value; }
        }

        public LifeCycleState State
        {
            get { return _rtComponent.State; }
            set { _rtComponent.State = value; }
        }

        public string InstanceName
        {
            get { return _rtComponent.InstanceName; }
            set { _rtComponent.InstanceName = value; }
        }

        public string NamingName
        {
            get { return _rtComponent.NamingName; }
            set { _rtComponent.NamingName = value; }
        }


        public string TypeName
        {
            get { return _rtComponent.TypeName; }
            set { _rtComponent.TypeName = value; }
        }

        public string Category
        {
            get { return _rtComponent.Category; }
            set { _rtComponent.Category = value; }
        }

        public string Description
        {
            get { return _rtComponent.Description; }
            set { _rtComponent.Description = value; }
        }

        public string Version
        {
            get { return _rtComponent.Version; }
            set { _rtComponent.Version = value; }
        }

        public string Vendor
        {
            get { return _rtComponent.Vendor; }
            set { _rtComponent.Vendor = value; }
        }

        public ReadOnlyDispatcherCollection<NameValueViewModel> Properties { get; private set; }
        public ConfigurationViewModel Configuration { get; private set; }
        public ReadOnlyDispatcherCollection<PortViewModel> Ports { get; private set; }
        public ReadOnlyDispatcherCollection<DataInPortViewModel> DataInPorts { get; private set; }
        public ReadOnlyDispatcherCollection<DataOutPortViewModel> DataOutPorts { get; private set; }
        public ReadOnlyDispatcherCollection<ServiceConsumerViewModel> ServiceConsumers { get; private set; }
        public ReadOnlyDispatcherCollection<ServiceProviderViewModel> ServiceProviders { get; private set; }


        #region ActivateCommand
        private ViewModelCommand _activateCommand;

        public ViewModelCommand ActivateCommand
        {
            get
            {
                if (_activateCommand == null)
                    _activateCommand = new ViewModelCommand(Activate);
                return _activateCommand;
            }
        }

        private void Activate()
        {
            Observable.Start(() => _rtComponent.Activate()).Subscribe();
        }
        public void ActivateComponent()
        {
            _rtComponent.Activate();
        }
        #endregion


        #region DeactivateCommand
        private ViewModelCommand _deactivateCommand;

        public ViewModelCommand DeactivateCommand
        {
            get
            {
                if (_deactivateCommand == null)
                    _deactivateCommand = new ViewModelCommand(Deactivate);
                return _deactivateCommand;
            }
        }

        private void Deactivate()
        {
            Observable.Start(() => _rtComponent.Deactivate()).Subscribe();
        }
        public void DeactivateComponent()
        {
            _rtComponent.Deactivate();
        }
        #endregion



        #region ResetCommand
        private ViewModelCommand _resetCommand;

        public ViewModelCommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new ViewModelCommand(Reset);
                return _resetCommand;
            }
        }

        private void Reset()
        {
            Observable.Start(() => _rtComponent.Reset()).Subscribe();
        }
        public void ResetComponent()
        {
            _rtComponent.Reset();
        }
        #endregion

    }
}
