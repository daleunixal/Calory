using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Сalory.Models
{
    public class ChartVM
    {
        public ObservableCollection<ChartModel> Data { get; set; }
        private double _carbs;
        private double _fats;
        private double _prot;

        public ChartVM(BindingList<Model> items)
        {
            Data = new ObservableCollection<ChartModel>();
            FillData(items);
        }

        private void FillData(BindingList<Model> items)
        {
            foreach (var model in items)
            {
                _carbs += model.Carbs;
                _fats += model.Fats;
                _prot += model.Proteins;
            }
            Data.Add(new ChartModel("Углеводы", _carbs));
            Data.Add(new ChartModel("Жиры", _fats));
            Data.Add(new ChartModel("Белок", _prot));
        }
    }
}