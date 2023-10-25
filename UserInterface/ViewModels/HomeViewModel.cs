using Core.Dto;
using Core.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInterface.Core;

namespace UserInterface.ViewModels
{
    public class HomeViewModel: ObservableObject
    {
		private List<Asset>? _assets;
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

		public HomeViewModel()
		{
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
