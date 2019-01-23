using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using SpamTool_Akhmerov.lib.Data;


namespace SpamTool_Akhmerov.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //SimpleIoc.Default.Unregister<DatabaseContext>();
            //SimpleIoc.Default.Register(() => new DatabaseContext());
            //SimpleIoc.Default.Register<IDataService, DataServiceDB>();

            SimpleIoc.Default.Register<MainWindowViewModel>();


        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        public static void Cleanup()
        {

        }
    }
}