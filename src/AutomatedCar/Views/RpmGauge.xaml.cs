﻿using AutomatedCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomatedCar.Views
{
    /// <summary>
    /// Interaction logic for RpmGauge.xaml
    /// </summary>
    public partial class RpmGauge : UserControl, INotifyPropertyChanged
    {
        private double _value;

        public RpmGauge()
        {
            InitializeComponent();


            DataContext = this;
        }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public string RpmCaption
        {
            get { return _value.ToString() + " rpm"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}