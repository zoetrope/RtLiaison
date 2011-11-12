using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RtLiaison.ViewModels;

namespace RTCube.Views
{
    /// <summary>
    /// DiagramView.xaml の相互作用ロジック
    /// </summary>
    public partial class DiagramView : UserControl
    {
        public DiagramView()
        {
            InitializeComponent();
        }
        
        // ViewModelを取得する
        public DiagramViewModel Model
        {
            get { return DataContext as DiagramViewModel; }
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            // ドロップされた場所を取得して
            var pos = e.GetPosition(e.OriginalSource as UIElement);

            var name = e.Data.GetData(typeof(string)) as string;
            
            // ViewModelに追加する
            Model.AddDiagram(name, pos);
            e.Handled = true;
        }


        // http://main.tinyjoker.net/Tech/CSharp/WPF/ListBox%A4%CE%A5%A2%A5%A4%A5%C6%A5%E0%A4%F2%C8%BE%C6%A9%CC%C0%A5%B4%A1%BC%A5%B9%A5%C8%A4%C4%A4%AD%A5%C9%A5%E9%A5%C3%A5%B0%A5%A2%A5%F3%A5%C9%A5%C9%A5%ED%A5%C3%A5%D7%A4%C7%CA%C2%A4%D9%C2%D8%A4%A8%A4%EB.html
        private void listBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // マウスダウンされたアイテムを記憶
            var dragItem = sender as ListViewItem;
            var vm = dragItem.Content as RtComponentViewModel;
            var name = vm.NamingName;
            // マウスダウン時の座標を取得
            //dragStartPos = e.GetPosition(dragItem);

            DragDrop.DoDragDrop(dragItem, name, DragDropEffects.Copy);
        }

        private void listBoxItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
//            var lbi = sender as ListBoxItem;
//            if (e.LeftButton == MouseButtonState.Pressed && dragGhost == null && dragItem == lbi)
//            {
//                var nowPos = e.GetPosition(lbi);
//                if (Math.Abs(nowPos.X - dragStartPos.X) > SystemParameters.MinimumHorizontalDragDistance ||
//                    Math.Abs(nowPos.Y - dragStartPos.Y) > SystemParameters.MinimumVerticalDragDistance)
//                {
//                    listBox.AllowDrop = true;
//
//                    var layer = AdornerLayer.GetAdornerLayer(listBox);
//                    dragGhost = new DragAdorner(listBox, lbi, 0.5, dragStartPos);
//                    layer.Add(dragGhost);
//                    DragDrop.DoDragDrop(lbi, lbi, DragDropEffects.Move);
//                    layer.Remove(dragGhost);
//                    dragGhost = null;
//                    dargItem = null;
//
//                    listBox.AllowDrop = false;
//                }
//            }
        }

        private void listBoxItem_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
//            if (dragGhost != null)
//            {
//                var p = CursorInfo.GetNowPosition(this);
//                var loc = this.PointFromScreen(listBox.PointToScreen(new Point(0, 0)));
//                dragGhost.LeftOffset = p.X - loc.X;
//                dragGhost.TopOffset = p.Y - loc.Y;
//            }
        }
    }
}
