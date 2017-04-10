using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace TicketDeCaisse2017.Services
{
    class TDCServiceLocator
    {
        public TDCServiceLocator()
        {
            if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                Initialize("");
            }
        }

        private static TDCServiceLocator _Instance = null;
        public static TDCServiceLocator Instance
        {
            get
            {
                return _Instance ?? (_Instance = new TDCServiceLocator());
            }
        }

        public void Initialize(string name)
        {
            if (!ServiceLocator.IsLocationProviderSet)
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<DatabaseManager>();
            }
        }

        public DatabaseManager Database
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DatabaseManager>();
            }
        }
    }
}
