using Core.Entities;
using Infrastructure.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using UserInterface.Core;

namespace UserInterface.ViewModels
{
    public class DetailInformationViewModel : ObservableObject
    {
        private readonly UnitOfWork _unitOfWork = UnitOfWork.Instance;
        private Asset? _asset;
        private static string? _assetId;

        public Asset? Asset
        {
            get { return _asset; }
            set 
            { 
                _asset = value; 
                OnPropertyChanged();
            }
        }
        public RelayCommand OpenExplorerCommand { get; set; }

        public DetailInformationViewModel() 
        {
            Task.Factory.StartNew(async () =>
            {
                Asset = (await _unitOfWork.CoinCapApiService.GetAssetByIdAsync(_assetId ?? ""))?.Data;
            });
            OpenExplorerCommand = new RelayCommand(_ =>
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Asset?.Explorer,
                    UseShellExecute = true
                });
            }, _ =>
            {
                return true;
            });
        }

        public static DetailInformationViewModel GetViewModel(string? id)
        {
            _assetId = id;

            return new DetailInformationViewModel();
        }
    }
}
