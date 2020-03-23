using Corona.API;
using Corona.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace Corona.ViewModels
{
    public class CoronaViewModel : BaseViewModel
    {
        HealthGovernmentAPI healthGovernmentAPI = new HealthGovernmentAPI();
        public async Task<HealthGovAPIResponse> GetCoronaData()
        {
            IsBusy = true;

            HealthGovAPIResponse res = await healthGovernmentAPI.GetCoronaData();

            IsBusy = false;
            return res;

        }

        
    }
}
