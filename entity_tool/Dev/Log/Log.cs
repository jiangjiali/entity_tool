using System.Collections.Generic;

namespace Dev
{
	public class Log : Singleton<Log>
	{
		enum LogType
		{
			D, W, E
		}

		HashSet<ILog> m_logDevices = new HashSet<ILog>();

		public static void Debug(string format, params object[] args)
		{
			Log_Msg( LogType.D, format, args );
		}

		public static void Warning(string format, params object[] args)
		{
			Log_Msg( LogType.W, format, args );
		}

		public static void Error(string format, params object[] args)
		{
			Log_Msg( LogType.E, format, args );
		}

		static void Log_Msg(LogType type, string format, params object[] args)
		{
			switch( type )
			{
				case LogType.D:
					foreach( var device in Instance.LogDevices )
						device.Debug( format, args );
					break;
				case LogType.W:
					foreach( var device in Instance.LogDevices )
						device.Warning( format, args );
					break;
				case LogType.E:
					foreach( var device in Instance.LogDevices )
						device.Error( format, args );
					break;
				default:
					break;
			}
		}

		protected HashSet<ILog> LogDevices
		{
			get
			{
				return m_logDevices;
			}
		}

		public bool AddLogDevices(ILog logDevices)
		{
			return m_logDevices.Add( logDevices );
		}

		public bool RemoveDevices(ILog logDevices)
		{
			return m_logDevices.Remove( logDevices );
		}

		protected override void Init()
		{
		}

		protected override void DisposeUnmanaged()
		{
			base.DisposeUnmanaged();
			foreach( var item in m_logDevices )
				item.Dispose();
		}
	}
}
