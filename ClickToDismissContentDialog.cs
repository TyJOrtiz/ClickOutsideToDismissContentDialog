using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace //
{
    public sealed partial class ClickToDismissContentDialog : ContentDialog
    {
        private Grid LayoutRoot;
        private Rectangle _lockRectangle;

        public ClickToDismissContentDialog()
        {
            this.DefaultStyleKey = typeof(ClickToDismissContentDialog);
        }
        private void OnLockRectangleTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Hide();
            _lockRectangle.Tapped -= OnLockRectangleTapped;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var grid = GetTemplateChild(nameof(LayoutRoot)) as Grid;
            grid.Tapped += Grid_Tapped;
            
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var grid = e.OriginalSource;
            if (grid is Grid)
            {
                if ((grid as Grid).Name.ToString() == "TapArea")
                {
                    this.Hide();
                }
            }
        }
    }
}
