using System;
namespace Dev
{
	public interface ILog : IDisposable
	{
		void Debug(string format, params object[] args);

		void Warning(string format, params object[] args);

		void Error(string format, params object[] args);
	}
}