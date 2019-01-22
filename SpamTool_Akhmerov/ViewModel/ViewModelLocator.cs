using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using SpamTool_Akhmerov.lib.Database;
using SpamTool_Akhmerov.lib.Interfaces;
using SpamTool_Akhmerov.lib.Service;


namespace SpamTool_Akhmerov.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Unregister<SpamToolDatabaseDataContext>();
            SimpleIoc.Default.Register(() => new SpamToolDatabaseDataContext());
            SimpleIoc.Default.Register<IDataService, DataServiceDB>();

            SimpleIoc.Default.Register<MainWindowViewModel>();
            
            
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        
        public static void Cleanup()
        {
            
        }
    }
}