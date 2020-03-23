using Corona.Models;
using Corona.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Corona
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        CoronaViewModel coronaViewModel = new CoronaViewModel();
        int Amount;
        //HealthGovAPIResponse response = new HealthGovAPIResponse();
        public MainPage()
        {
            InitializeComponent();
            Amount = 0;
            BindingContext = this;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = GetData();
        }

        private async Task GetData()
        {
            var response = await coronaViewModel.GetCoronaData();
            refreshView.IsRefreshing = false;
            AnimateAmountChange(response.data.local_total_cases, response.data.local_new_cases, response.data.local_total_number_of_individuals_in_hospitals, response.data.local_deaths, response.data.local_recovered);
        }

        public ICommand RefreshCommand => new Command(async () =>
        {
            await GetData();
        });

        private void AnimateAmountChange(int totalCases, int newCases, int inHospitals, int deaths, int recovered)
        {
            var startValue = 0;

            var _animation1 = new Animation(v =>
            {
                lbl1.Text = Convert.ToDouble((int)v).ToString();

            }, startValue, totalCases, easing: Easing.SinInOut);

            _animation1.Commit(lbl1, "Percentage", length: 1500,
               finished: (l, c) => { _animation1 = null; });



            var _animation2 = new Animation(v =>
            {
                lbl2.Text = Convert.ToDouble((int)v).ToString();

            }, startValue, newCases, easing: Easing.SinInOut);

            _animation2.Commit(lbl2, "Percentage", length: 1500,
               finished: (l, c) => { _animation2 = null; });



            var _animation3 = new Animation(v =>
            {
                lbl3.Text = Convert.ToDouble((int)v).ToString();

            }, startValue, inHospitals, easing: Easing.SinInOut);

            _animation3.Commit(lbl3, "Percentage", length: 1500,
               finished: (l, c) => { _animation3 = null; });



            var _animation4 = new Animation(v =>
            {
                lbl4.Text = Convert.ToDouble((int)v).ToString();

            }, startValue, deaths, easing: Easing.SinInOut);

            _animation4.Commit(lbl4, "Percentage", length: 1500,
               finished: (l, c) => { _animation4 = null; });



            var _animation5 = new Animation(v =>
            {
                lbl5.Text = Convert.ToDouble((int)v).ToString();

            }, startValue, recovered, easing: Easing.SinInOut);

            _animation5.Commit(lbl5, "Percentage", length: 1500,
               finished: (l, c) => { _animation5 = null; });
        }
    }
}
