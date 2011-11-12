using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using RtLiaison.Extensibility;

namespace EditableComponent
{
    [Export(typeof(IPlugin))]
    public class EditableComponentPlugin : IPlugin
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
