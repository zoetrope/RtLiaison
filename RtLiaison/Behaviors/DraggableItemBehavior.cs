using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Shapes;
using RtLiaison.ViewModels;

namespace RtLiaison.Behaviors
{
    class DraggableItemBehavior : Behavior<FrameworkElement>
    {

        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseLeftButtonDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= AssociatedObjectOnMouseLeftButtonDown;
        }

        private void AssociatedObjectOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var datacontext = AssociatedObject.DataContext as RtcItemViewModel;

            if (datacontext != null)
            {
                DragDrop.DoDragDrop((DependencyObject) sender, datacontext.FullName, DragDropEffects.Copy);
            }
        }
    }
}
