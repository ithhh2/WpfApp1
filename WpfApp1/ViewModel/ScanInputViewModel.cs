using System.Threading;
using System.Windows.Input;
using WpfApp1.View;
using WpfApp1.ViewModel.Base;

namespace WpfApp1.ViewModel
{
    public class ScanInputViewModel : ViewModelBase
    {
        public ScanInputViewModel()
        {
            //SubmitCommand = new RelayCommand(ExecuteSubmitCommand, CanExecuteSubmitCommand);
        }

        private string _scanInputText;

        public string ScanInputText
        {
            get { return _scanInputText; }
            set
            {
                if (SetProperty(ref _scanInputText, value))
                {
                    // 当输入文本变化时，通知CanSubmit属性也发生了变化
                    OnPropertyChanged(nameof(CanSubmit));
                }
            }
        }

        // 判断是否可以提交（输入不为空）
        public bool CanSubmit => !string.IsNullOrEmpty(ScanInputText);

        //public ICommand SubmitCommand { get; }

        //private bool CanExecuteSubmitCommand(object parameter)
        //{
        //    return !string.IsNullOrWhiteSpace(ScanInputText);
        //}

        //private void ExecuteSubmitCommand(object parameter)
        //{
        //    Thread.Sleep(10);
        //}



    }
}
