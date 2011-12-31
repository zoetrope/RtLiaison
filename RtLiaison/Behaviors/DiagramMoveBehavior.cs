using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Shapes;
using RtLiaison.ViewModels;

namespace RtLiaison.Behaviors
{
    // ドラッグで移動するBehavior
    // http://d.hatena.ne.jp/okazuki/20100425/1272154217
    class DiagramMoveBehavior : Behavior<Rectangle>
    {
        // マウスが押されているかどうかのフラグ
        private bool _mouseDown;
        // 直前のマウスの座標
        private Point _prevPosition;

        protected override void OnAttached()
        {
            base.OnAttached();
            // 各種イベント登録
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            // 登録されたイベントを削除
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
        }

        // ViewModelを取得する
        private RtcDiagramViewModel GetModel()
        {
            return AssociatedObject.DataContext as RtcDiagramViewModel;
        }
        
        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // マウスの左ボタンが押されたのでマウスのキャプチャを開始
            AssociatedObject.CaptureMouse();
            // フラグをON
            _mouseDown = true;
            // 現在のマウスの位置を取得する
            _prevPosition = e.GetPosition(null);
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            // マウスが押されてなかったら何もしない
            if (!_mouseDown) return;

            // マウスの現在地を取得して
            var pos = e.GetPosition(null);
            // 前回との差分を取得してViewModleのMoveメソッドを呼ぶ
            GetModel().Move(
                (int)(pos.X - _prevPosition.X),
                (int)(pos.Y - _prevPosition.Y));
            _prevPosition = pos;
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // マウスの左ボタンが離されたのでマウスのキャプチャを終了
            AssociatedObject.ReleaseMouseCapture();
            // フラグもOFFにする
            _mouseDown = false;
        }
    }
}
