using Core.Dto;
using Core.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using UserInterface.Core;

namespace UserInterface.ViewModels
{
    public class ConvertViewModel : ObservableObject
    {
        private readonly UnitOfWork _unitOfWork = UnitOfWork.Instance;
        private List<Asset>? _assets;
        private Asset? _sourceAsset;
        private Asset? _destibationAsset;
        private string? _converted;

        public string? Converted
        {
            get { return _converted; }
            set 
            { 
                _converted = value;
                OnPropertyChanged();
            }
        }


        public Asset? DestinationAsset
        {
            get { return _destibationAsset; }
            set 
            { 
                _destibationAsset = value;
                OnPropertyChanged();
            }
        }
        public Asset? SourceAsset
        {
            get { return _sourceAsset; }
            set 
            { 
                _sourceAsset = value;
                OnPropertyChanged();
            }
        }
        public List<Asset>? Assets
        {
            get { return _assets; }
            set 
            { 
                _assets = value; 
                OnPropertyChanged();
            }
        }
        public RelayCommand SelectAssetCommand { get; set; }
        public RelayCommand ChangeAssetsCommand { get; set; }

        public ConvertViewModel() 
        {
            Task.Factory.StartNew(async () =>
            {
                Assets = (await _unitOfWork.CoinCapApiService.GetAssetsAsync(new AssetQueryDto { }))?.Data;
            });
            SelectAssetCommand = new RelayCommand(_ =>
            {
                if (SourceAsset != null && DestinationAsset != null)
                {
                    Converted = (double.Parse(SourceAsset.PriceUsd?.Replace(".", ",") ?? "1") / 
                                double.Parse(DestinationAsset.PriceUsd?.Replace(".", ",") ?? "1")).ToString();
                }
            }, _ =>
            {
                return true;
            });
            ChangeAssetsCommand = new RelayCommand(_ =>
            {
                var temp = SourceAsset;
                SourceAsset = DestinationAsset;
                DestinationAsset = temp;
            }, _ =>
            {
                return true;
            });
        }
    }
}
