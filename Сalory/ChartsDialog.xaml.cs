using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Сalory.Models;


namespace Сalory
{
    public partial class ChartsDialog : Window
    {
        public ChartsDialog(BindingList<Model> item)
        {
            InitializeComponent();
            
            var result = new ChartVM(item);
            Series.ItemsSource = result;
        }
    }
}