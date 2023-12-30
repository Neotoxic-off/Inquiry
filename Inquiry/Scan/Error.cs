using System;
namespace Inquiry.Scan
{
	public class Error
	{
		public enum Type
		{
			Major,
			Medium,
			Minor
		};
		public static Dictionary<string, Tuple<UInt64, Type, string>> Errors = new Dictionary<string, Tuple<ulong, Type, string>>()
		{
			{ "Namespace_Invalid_Name", new Tuple<UInt64, Type, string>(0x000001, Type.Major, "Namespace name invalid") }
		};
	}
}

