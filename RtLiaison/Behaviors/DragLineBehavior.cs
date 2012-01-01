using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using RtLiaison.ViewModels;
using RtLiaison.ViewModels.Diagrams;

namespace RtLiaison.Behaviors
{
    class DragLineBehavior : Behavior<FrameworkElement>
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
            var datacontext = AssociatedObject.DataContext as PortViewModel;

            if (datacontext != null)
            {
                DragDrop.DoDragDrop((DependencyObject)sender, datacontext, DragDropEffects.Move);
            }
        }
    }
}
