using Core.Dto;
using Core.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInterface.Core;

namespace UserInterface.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
		private readonly UnitOfWork _unitOfWork = UnitOfWork.Instance;
		private List<Asset>? _assets;

		public List<Asset>? Assets
		{
			get { return _assets; }
			set 
			{ 
				_assets = value;
				OnPropertyChanged();
			}
		}
		public MainViewModel? MainViewModel { get; set; }
		public SearchViewModel SearchViewModel { get; set; }
		public DetailInformationViewModel? DetailInformationViewModel { get; set; }
		public ConvertViewModel ConvertViewModel { get; set; }
		public RelayCommand SearchViewCommand { get; set; }
		public RelayCommand DetailInforationCommand { get; set; }
		public RelayCommand ConvertViewCommand { get; set; }

        public HomeViewModel()
		{
			MainViewModel = MainViewModel.Instance;
			SearchViewModel = new SearchViewModel();
            ConvertViewModel = new ConvertViewModel();
			SearchViewCommand = new RelayCommand(_ =>
			{
				MainViewModel!.CurrentView = SearchViewModel;
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
            ConvertViewCommand = new RelayCommand(_ =>
            {
                MainViewModel!.CurrentView = ConvertViewModel;
            }, _ =>
            {
                return true;
            });
            Task.Factory.StartNew(async () =>
			{
				while(true)
				{	
					Assets = (await _unitOfWork.CoinCapApiService.GetAssetsAsync(new AssetQueryDto { Limit = 10 }))?.Data;
					await Task.Delay(10000);
                }
			});
		}
 	}
}
