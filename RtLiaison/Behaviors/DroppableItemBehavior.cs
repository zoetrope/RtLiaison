using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;
using RtLiaison.ViewModels;
using RtLiaison.ViewModels.Diagrams;

namespace RtLiaison.Behaviors
{
    class DroppableItemBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Drop += AssociatedObjectOnDrop;
            AssociatedObject.DragOver += AssociatedObjectOnDragOver;
        }


        protected override void OnDetaching()
        {
            AssociatedObject.Drop -= AssociatedObjectOnDrop;
            AssociatedObject.DragOver -= AssociatedObjectOnDragOver;
        }

        private void AssociatedObjectOnDrop(object sender, DragEventArgs dragEventArgs)
        {
            var source = dragEventArgs.OriginalSource as UIElement;

            if (source == null)
            {
                dragEventArgs.Handled = false;
                return; 
            }

            // ドロップされた場所を取得して
            var pos = dragEventArgs.GetPosition(source);


            if (dragEventArgs.Data.GetDataPresent(typeof(string)))
            {
                var name = (string)dragEventArgs.Data.GetData(typeof(string));
                
                var datacontext = AssociatedObject.DataContext as DiagramViewModel;
                if (datacontext == null)
                {
                    dragEventArgs.Handled = false;
                    return;
                }
                // ViewModelに追加する
                datacontext.AddDiagram(name, pos);
            }
            else if (dragEventArgs.Data.GetDataPresent(typeof(PortViewModel)))
            {
                var vm = (PortViewModel)dragEventArgs.Data.GetData(typeof(PortViewModel));


            }
            else
            {
                dragEventArgs.Handled = false;
                return;
            }

            dragEventArgs.Handled = true;
        }


        private void AssociatedObjectOnDragOver(object sender, DragEventArgs dragEventArgs)
        {
            if (dragEventArgs.Data.GetDataPresent(typeof(PortViewModel)))
            {
                var vm = (PortViewModel)dragEventArgs.Data.GetData(typeof(PortViewModel));

                var source = dragEventArgs.OriginalSource as UIElement;

                if (source == null)
                {
                    dragEventArgs.Handled = false;
                    return;
                }

                // ドロップされた場所を取得
                var pos = dragEventArgs.GetPosition(source);
                var datacontext = AssociatedObject.DataContext as DiagramViewModel;
                if (datacontext == null)
                {
                    dragEventArgs.Handled = false;
                    return;
                }

                datacontext.UpdateConnectingLine(vm.X,vm.Y,pos.X,pos.Y);
            }

        }

    }
}
