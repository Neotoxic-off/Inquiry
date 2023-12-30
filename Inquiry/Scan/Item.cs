using System;
namespace Inquiry.Scan
{
	public class Item
	{
		public Type ItemType { get; set; }
		public List<Tuple<UInt64, Error.Type, string>> Errors { get; set; }

		public Item(Type type, List<string> errors_code)
		{
			ItemType = type;
			Errors = new List<Tuple<ulong, Error.Type, string>>();

            SetErrors(errors_code);
        }

		private void SetErrors(List<string> errors_code)
		{
            foreach (string error in errors_code)
            {
                Errors.Add(Error.Errors[error]);
            }
        }
	}
}

