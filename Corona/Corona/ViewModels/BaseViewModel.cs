using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Corona.ViewModels
{
    public abstract class BaseViewModel
    {
        private bool _isBusy = false;
        private bool _isNoContent = false;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public bool IsNoContent
        {
            get
            {
                return _isNoContent;
            }
            set
            {
                _isNoContent = value;
                OnPropertyChanged("IsNoContent");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
