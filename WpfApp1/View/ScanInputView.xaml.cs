using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// ScanInputView.xaml 的交互逻辑
    /// </summary>
    public partial class ScanInputView : Window
    {
        public ScanInputView()
        {
            InitializeComponent();
            DataContext = new ScanInputViewModel();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        // 其他事件处理方法，如 TextBox_PreviewKeyDown 和 TextBox_PreviewTextInput
        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // 在这里处理按键按下事件
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // 在这里处理文本输入事件
        }

    }
}
