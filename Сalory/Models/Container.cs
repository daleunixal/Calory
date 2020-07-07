using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Сalory.Models
{
    public class Container
    {
        private Dictionary<DateTime, BindingList<Model>> _store = new Dictionary<DateTime, BindingList<Model>>();
        public NameEnergy State = NameEnergy.Calory;

        public Dictionary<DateTime, BindingList<Model>> Store
        {
            get => _store;
            set => _store = value;
        }

        public BindingList<Model> current;

        public Container()
        {
            if (!_store.ContainsKey(DateTime.Today)) _store.Add(DateTime.Today, new BindingList<Model>());
            
        }

        public void InitUpdate()
        {
            current = _store[DateTime.Today];
            
        }

        public void EnergySwitch()
        {
            State = State == NameEnergy.Calory? NameEnergy.Joule : NameEnergy.Calory;
            foreach (var item in current)
            {
                item.State = State;
            }
        }

        public void ToDate(DateTime time)
        {
            if(!_store.ContainsKey(time)) _store.Add(time, new BindingList<Model>());
            current = _store[time];
            foreach (var item in current)
            {
                item.State = State;
            }
        }

        private void NormalizeData()
        {
            
        }
    }
}