using System;
using MediaListingApp.Core.Models;
using MvvmCross.Core.ViewModels;

namespace MediaListingApp.Core.ViewModels
{
    public class DetailViewModel : MvxViewModel
    {
        public DetailViewModel()
        {
            
        }

        public void Init(MediaModel media)
        {
            _media = media;
        }

        #region Properties
        private MediaModel _media;

        public MediaModel Media
        {
            get { return _media; }
            set
            {
                Media = value;
                RaisePropertyChanged(() => Media);
            }
        }

        #endregion

        #region Commands
        public IMvxCommand CloseCommand
        {
            get { return new MvxCommand(() => {
                //Close(this);
                ShowViewModel<MainViewModel>();
            }); }
        }
        #endregion
    }
}
