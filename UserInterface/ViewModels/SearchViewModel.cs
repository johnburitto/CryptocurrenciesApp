using Core.Dto;
using Core.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using UserInterface.Core;

namespace UserInterface.ViewModels
{
    public class SearchViewModel : ObservableObject
    {
        private readonly UnitOfWork _unitOfWork = UnitOfWork.Instance;
        private List<Asset>? _assets;
        private string? _search;

        public List<Asset>? Assets
        {
            get { return _assets; }
            set 
            { 
                _assets = value; 
                OnPropertyChanged();
            }
        }
        public string? Search
        {
            get { return _search; }
            set 
            { 
                _search = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel? MainViewModel { get; set; }
        public DetailInformationViewModel? DetailInformationViewModel { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand DetailInforationCommand { get; set; }

        public SearchViewModel()
        {
            MainViewModel = MainViewModel.Instance;
            SearchCommand = new RelayCommand(async _ =>
            {
                Assets = (await _unitOfWork.CoinCapApiService.GetAssetsAsync(new AssetQueryDto { Search = Search }))?.Data;
            }, _ =>
            {
                return true;
            });
            DetailInforationCommand = new RelayCommand(_ =>
            {
                var asset = _ as Asset;

                if (asset == null)
                {
                    return;
                }

                DetailInformationViewModel = DetailInformationViewModel.GetViewModel(asset?.Id);
                MainViewModel!.CurrentView = DetailInformationViewModel;
            }, _ =>
            {
                return true;
            });
        }
    }
}
