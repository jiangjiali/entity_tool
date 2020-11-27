using System;

namespace Dev
{
	class ConsoleLog : DisposableObject, ILog
	{
		public void Debug(string format, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine( string.Format( format, args ) );
			Console.ResetColor();
		}

		public void Warning(string format, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine( string.Format( format, args ) );
			Console.ResetColor();
		}

		public void Error(string format, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine( string.Format( format, args ) );
			Console.ResetColor();
		}
	}
}
