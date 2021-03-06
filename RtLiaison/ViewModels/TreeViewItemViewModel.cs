﻿using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Livet;
using ReactiveRTM.Corba;

namespace RtLiaison.ViewModels
{
    public class TreeViewItemViewModel : NotificationObject
    {
        public TreeViewItemViewModel()
        {
            IsExpand = false;
            Children = new ObservableCollection<TreeViewItemViewModel>();
        }

        public virtual ObservableCollection<TreeViewItemViewModel> Children { get; private set; }

        public virtual string Name { get; private set; }

        #region IsSelected変更通知プロパティ
        private bool _IsSelected;

        public bool IsSelected
        {
            get
            { return _IsSelected; }
            set
            {
                if (_IsSelected == value)
                    return;
                _IsSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
        #endregion


        #region IsExpand変更通知プロパティ
        private bool _IsExpand;

        public bool IsExpand
        {
            get
            { return _IsExpand; }
            set
            {
                if (_IsExpand == value)
                    return;
                _IsExpand = value;
                RaisePropertyChanged("IsExpand");
            }
        }
        #endregion

      
    }


    public class NamingServiceItemViewModel : TreeViewItemViewModel
    {
        CorbaNamingServiceClient _client;
        public NamingServiceItemViewModel(CorbaNamingServiceClient client)
        {
            _client = client;
        }

        private ObservableCollection<TreeViewItemViewModel> _children;
        public override ObservableCollection<TreeViewItemViewModel> Children
        {
            get
            {
                if (_children == null)
                {
                    var root = _client.RootContextInfo;
                    var list = root.Contexts.Select(x => new ContextItemViewModel(x)).Cast<TreeViewItemViewModel>()
                        .Concat(root.Objects.Select(x => new RtcItemViewModel(x)).Cast<TreeViewItemViewModel>());
                    _children = new ObservableCollection<TreeViewItemViewModel>(list);
                }

                return _children;
            }
        }

        public override string Name
        {
            get
            {
                return _client.Key;
            }
        }
    }
    
    public class ContextItemViewModel : TreeViewItemViewModel
    {
        private NamingContextInfo _context;
        public ContextItemViewModel(NamingContextInfo context)
        {
            _context = context;
        }

        private ObservableCollection<TreeViewItemViewModel> _children;
        public override ObservableCollection<TreeViewItemViewModel> Children
        {
            get
            {
                if (_children == null)
                {
                    var list = _context.Contexts.Select(x => new ContextItemViewModel(x)).Cast<TreeViewItemViewModel>()
                        .Concat(_context.Objects.Select(x => new RtcItemViewModel(x)).Cast<TreeViewItemViewModel>());
                    _children = new ObservableCollection<TreeViewItemViewModel>(list);
                }

                return _children;
            }
        }

        public override string Name
        {
            get
            {
                return _context.Name;
            }
        }
    }

    public class RtcItemViewModel : TreeViewItemViewModel
    {
        private NamingObjectInfo _objectInfo;
        public RtcItemViewModel(NamingObjectInfo obj)
        {
            _objectInfo = obj;
        }

        public override string Name
        {
            get
            {
                return _objectInfo.Name;
            }
        }

        public string FullName
        {
            get
            {
                return _objectInfo.FullName;
            }
        }
    }

    public class InPortItemViewModel : TreeViewItemViewModel
    {
        public string NamingName { get; set; }
        public string DataType { get; set; }
    }

    public class OutPortItemViewModel : TreeViewItemViewModel
    {
        public string NamingName { get; set; }
        public string DataType { get; set; }
    }
}
