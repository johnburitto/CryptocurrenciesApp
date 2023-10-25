using Core.Dto;
using Core.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using UserInterface.Core;

namespace UserInterface.ViewModels
{
    public class SearchViewModel : ObservableObject
    {
        private List<Asset>? _assets;
        private string? _search;
        private readonly UnitOfWork _unitOfWork = UnitOfWork.Instance;

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
        public RelayCommand SearchCommand { get; set; }

        public SearchViewModel()
        {
            SearchCommand = new RelayCommand(async _ =>
            {
                Assets = (await _unitOfWork.CoinCapApiService.GetAssetsAsync(new AssetQueryDto { Search = Search }))?.Data;
            }, _ =>
            {
                return true;
            });
        }
    }
}
