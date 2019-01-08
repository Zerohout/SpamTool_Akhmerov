using GalaSoft.MvvmLight;

namespace SpamTool_Akhmerov
{
    class TestMainViewModel : ViewModelBase
    {
        public string testTextValue;

        public string TestTextValue
        {
            get => testTextValue;
            set => Set(ref testTextValue, value);
        }
    }
}
