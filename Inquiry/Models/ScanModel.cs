using System;
using System.Collections.ObjectModel;

namespace Inquiry.Models
{
	public class ScanModel: BaseModel
	{
		private ObservableCollection<ScanStepModel> _steps;
		public ObservableCollection<ScanStepModel> Steps
		{
			get { return _steps; }
			set { SetProperty(ref _steps, value); }
        }
    }
}

