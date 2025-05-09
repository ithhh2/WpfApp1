using System.Windows.Input;
using WpfApp1.View;
using WpfApp1.ViewModel.Base;

namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _inputText;

        public string InputText
        {
            get { return _inputText; }
            set { SetProperty(ref _inputText, value); }
        }

        public ICommand SubmitCommand { get; }
        public ICommand ResetCommand { get; }

        public MainWindowViewModel()
        {
            //SubmitCommand = new RelayCommand(ExecuteSubmitCommand, CanExecuteSubmitCommand);
            SubmitCommand = new RelayCommand(ExecuteSubmitCommand);
            ResetCommand = new RelayCommand(ExecuteResetCommand);
        }

        private bool CanExecuteSubmitCommand(object parameter)
        {
            return !string.IsNullOrWhiteSpace(InputText);
        }

        private void ExecuteSubmitCommand(object parameter)
        {
            InputText = string.Empty; // 清空输入框，演示双向绑定
                                      // 弹窗提示扫码（获取扫码内容）
            string qrcodeStr = "";
            var scanInputView = new ScanInputView();
            bool? result = scanInputView.ShowDialog();
            if (result.HasValue && result.Value)
            {
                // 用户点击了确定按钮
                // 通过视图的 DataContext 获取视图模型
                var viewModel = scanInputView.DataContext as ScanInputViewModel;
                if (viewModel != null)
                {
                    qrcodeStr = viewModel.ScanInputText;
                    // 处理扫码内容
                    InputText = qrcodeStr;
                }
            }
            else
            {
                // 用户点击了取消按钮
                return;
            }
        }

        private void ExecuteResetCommand(object parameter)
        {
            InputText = string.Empty;
        }

    }
}
