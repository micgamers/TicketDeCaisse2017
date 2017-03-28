﻿using TicketDeCaisse2017.Services;
using TicketDeCaisse2017.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TicketDeCaisse2017
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();

            TDCServiceLocator.Instance.Initialize("CloudOrange");
            TDCServiceLocator.Instance.Database.CreateAllTable();
            TDCServiceLocator.Instance.XSqliteService.CreateDbIfNotExist();
            TDCServiceLocator.Instance.XSqliteService.AddListPerson();
            TDCServiceLocator.Instance.XSqliteService.GetListPerson();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }
    }
}
