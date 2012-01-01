using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RtLiaison.Controls
{
    /// <summary>
    /// ドロップ ダウン メニューを表示する為のボタン コントロール クラスです。
    /// http://akabeko.sakura.ne.jp/blog/2009/10/wpf-%E3%81%A7-dropdown-%E3%83%A1%E3%83%8B%E3%83%A5%E3%83%BC%E3%83%9C%E3%82%BF%E3%83%B3/
    /// </summary>
    public sealed class DropDownMenuButton : Button
    {

        /// <summary>
        /// ドロップ ダウンとして表示するコンテキスト メニューを取得または設定します。
        /// </summary>
        public ContextMenu DropDownContextMenu
        {
            get
            {
                return this.GetValue(DropDownContextMenuProperty) as ContextMenu;
            }
            set
            {
                this.SetValue(DropDownContextMenuProperty, value);
            }
        }

        /// <summary>
        /// コントロールがクリックされた時のイベントです。
        /// </summary>
        protected override void OnClick()
        {
            if (this.DropDownContextMenu == null) { return; }

            this.DropDownContextMenu.PlacementTarget = this;
            this.DropDownContextMenu.Placement = PlacementMode.Bottom;
            this.DropDownContextMenu.IsOpen = !DropDownContextMenu.IsOpen;
        }

        /// <summary>
        /// ドロップ ダウンとして表示するメニューを表す依存プロパティです。
        /// </summary>
        public static readonly DependencyProperty DropDownContextMenuProperty 
            = DependencyProperty.Register("DropDownContextMenu", typeof(ContextMenu), typeof(DropDownMenuButton), new UIPropertyMetadata(null));
    }
}
