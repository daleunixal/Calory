using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Сalory.Models;
using Сalory.Services;
using Container = Сalory.Models.Container;

namespace Сalory
{
    public partial class MainWindow
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\data.json";
        private readonly string HelpPATH = $"{Environment.CurrentDirectory}\\Help.chm";
        private Container _store;
        private FIOService _service;
        private DateTime _clock;
        private string _energyName;
        private ChartsDialog _charts;
        
        public MainWindow()
        {
             
        }

        private void DgMainTable_OnLoaded(object sender, RoutedEventArgs e)
        {
            _service = new FIOService(PATH);
            
            _store = _service.LoadData();
            _energyName = _store.State == NameEnergy.Calory ? "В кДж" : "В кКалл";
            _switch.Header = _energyName;
            _store.InitUpdate();
            _clock = DateTime.Today;
            dgMainTable.ItemsSource = _store.current;
            _store.current.ListChanged += CurrentOnListChanged;
        }

        private void CurrentOnListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemDeleted)
            {
                _service.SaveData(_store);
            }
           
        }

        private void Button_NextDay_OnClick(object sender, RoutedEventArgs e)
        {
            _clock = _clock.AddDays(1);
            _store.ToDate(_clock);
            dgMainTable.ItemsSource = _store.current;
        }

        private void Button_DayBefore_OnClick(object sender, RoutedEventArgs e)
        {
            _clock = _clock.AddDays(-1);
            _store.ToDate(_clock);
            dgMainTable.ItemsSource = _store.current;
        }

        private void Button_Today_OnClick(object sender, RoutedEventArgs e)
        {
            _clock = DateTime.Today;
            _store.ToDate(_clock);
            dgMainTable.ItemsSource = _store.current;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(HelpPATH))
            {
                return;
            }
            Process.Start(HelpPATH);
        }

        private void MenuItem_OnSwitch(object sender, RoutedEventArgs e)
        {
            _store.EnergySwitch();
            _energyName = _store.State == NameEnergy.Calory ? "В кДж" : "В кКалл";
            _switch.Header = _energyName;
        }

        private void MenuItem_OnCharts(object sender, RoutedEventArgs e)
        {
            _charts = new ChartsDialog(_store.current);
            _charts.ShowInTaskbar = false;
            _charts.Show();
        }
    }
}