using System;
using System.Reflection;
using Inquiry.Models;

namespace Inquiry.ViewModels
{
	public class SettingsViewModel: BaseViewModel
	{
		private SettingsModel _settingsModel;
		public SettingsModel settingsModel
		{
			get { return _settingsModel; }
			set { SetProperty(ref _settingsModel, value); }
        }

		public SettingsViewModel()
		{
			settingsModel = new SettingsModel();

			LoadVersion();
			LoadAuthor();
        }

		private void LoadVersion()
		{
			settingsModel.Version = Assembly.GetEntryAssembly().GetName().Version;
        }

        private void LoadAuthor()
        {
            settingsModel.Author = "Neotoxic-off";
        }
    }
}

