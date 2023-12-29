using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Inquiry.Models;
using Inquiry.Models.IO;
using Inquiry.Interfaces;
using System.Threading;
using CommunityToolkit.Maui.Storage;

namespace Inquiry.ViewModels
{
	public class ProjectViewModel: BaseViewModel
	{
		private ProjectModel _projectModel;
		public ProjectModel projectModel
		{
			get { return _projectModel; }
			set { SetProperty(ref _projectModel, value); }
		}

		public AsyncDelegateCommand AddFolderCommand { get; set; }

        public ProjectViewModel()
		{
			LoadModels();
            LoadCommands();
        }

		private void LoadModels()
		{
            projectModel = new ProjectModel()
            {
                Files = new ObservableCollection<Models.IO.FileModel>()
            };
        }

		private void LoadCommands()
		{
			AddFolderCommand = new AsyncDelegateCommand(AddFolder);
        }

		private async Task AddFolder(object data)
		{
			CancellationToken cancellationToken = new CancellationToken();
			FolderPickerResult folder = await FolderPicker.Default.PickAsync(cancellationToken);
			string[] files = null;

			if (folder != null)
			{
				files = Directory.GetFiles(folder.Folder.Path, "*.cs", SearchOption.AllDirectories);
                foreach (string file in files)
				{
                    AddFileToModel(file);
                }
			}
        }

		private void AddFileToModel(string path)
		{
            FileModel file = null;

            if (IsSelected(path) == false)
            {
                file = new FileModel()
                {
                    Path = path,
                    Content = File.ReadAllText(path)
                };
				
                projectModel.Files.Add(file);
            }
        }

		private bool IsSelected(string path)
		{
			foreach (FileModel file in projectModel.Files)
			{
				if (file.Path == path)
				{
					return (true);
				}
			}

			return (false);
		}
    }
}

