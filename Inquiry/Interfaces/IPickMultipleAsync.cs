using System;
namespace Inquiry.Interfaces
{
	public class IPickMultipleAsync
	{
		public async Task<IEnumerable<FileResult>> Pick(PickOptions pickOptions)
		{
			IEnumerable<FileResult> results = await FilePicker.Default.PickMultipleAsync(pickOptions);

			return (results);
        }
	}
}

