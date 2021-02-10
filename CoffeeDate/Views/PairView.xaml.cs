using System;
using System.Collections.Generic;
using CoffeeDate.ViewModels;
using Xamarin.Forms;

namespace CoffeeDate.Views
{
    public partial class PairView : ContentPage
    {
        public PairView(PairViewModel pairViewModel)
        {
            InitializeComponent();
            BindingContext = pairViewModel;
        }
    }
}
