using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MediaListingApp.Core.Interfaces;
using MediaListingApp.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MediaListingApp.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        #region Properties
        private List<CategoryModel> _categories;

        public List<CategoryModel> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged(() => Categories);
            }
        }
        #endregion

        public MainViewModel()
        {
        }

        public override Task Initialize()
        {
            var mediaService = Mvx.Resolve<IMediaService>();
            if (mediaService != null)
            {
                Task.Run(async () =>
                {
                    List<CategoryModel> rawList = new List<CategoryModel>();
                    rawList = await mediaService.LoadMedia();

                    // Sorting --> It is better to have 'Index' and 'IsLandscape' from server side
                    string[] Orders = { "Features", "Movies", "TV Shows" };
                    List<CategoryModel> orderedList = new List<CategoryModel>();
                    if (rawList != null && rawList.Count > 0)
                    {
                        for (int i = 0; i < Orders.Length; i++)
                        {
                            for (int j = rawList.Count - 1; j >= 0; j--)
                            {
                                if (string.Compare(Orders[i], rawList[j].Category, System.StringComparison.CurrentCultureIgnoreCase) == 0)
                                {
                                    orderedList.Add((rawList[j]));
                                    rawList.RemoveAt(j);
                                }
                            }
                        }

                        if (rawList != null && rawList.Count > 0)
                        {
                            orderedList.AddRange((rawList));
                        }

                        foreach (var item in orderedList)
                        {
                            if (string.Compare(Orders[0], item.Category, System.StringComparison.CurrentCultureIgnoreCase) == 0)
                            {
                                item.IsLandscaped = true;
                                if(item.Items != null && item.Items.Count > 0)
                                {
                                    foreach (var subitem in item.Items)
                                    {
                                        subitem.Image = subitem.Images.Landscape;
                                        if(string.IsNullOrEmpty(subitem.Image))
                                        {
                                            subitem.Image = subitem.Images.Portrait;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                item.IsLandscaped = false;
                                if (item.Items != null && item.Items.Count > 0)
                                {
                                    foreach (var subitem in item.Items)
                                    {
                                        subitem.Image = subitem.Images.Portrait;
                                        if (string.IsNullOrEmpty(subitem.Image))
                                        {
                                            subitem.Image = subitem.Images.Landscape;
                                        }
                                    }
                                }
                            }
                        }

                        // add the tap command
                        foreach(var item in orderedList)
                        {
                            foreach(var subitem in item.Items)
                            {
                                subitem.TapCommand = new MvxCommand(() => {
                                    Debug.WriteLine(subitem.Title);
                                    ShowViewModel<DetailViewModel>(subitem);
                                });
                                subitem.LandscapeImage = subitem.Images.Landscape;
                            }
                        }
                    }

                    Categories = orderedList;
                });
            }

            return base.Initialize();
        }

        #region Commands

        #endregion
    }
}