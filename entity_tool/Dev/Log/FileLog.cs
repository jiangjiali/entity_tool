using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
namespace Dev
{
	public class FileLog : DisposableObject, ILog
	{
		string m_dir;
		ILogger m_logger;

		#region Logger

		interface ILogger : IDisposable
		{
			void Log(string file, string str);
		}

		class Logger : Singleton<Logger>, ILogger
		{
			protected override void Init()
			{ }

			public void Log(string file, string str)
			{
				Write( file, str );
			}
		}

		class ThreadLogger : Singleton<ThreadLogger>, ILogger
		{
			class Item
			{
				public string File;
				public string Content;
			}
			Queue<Item> m_queue = new Queue<Item>();
			EventWaitHandle m_event = new EventWaitHandle( false, EventResetMode.AutoReset );
			bool m_isFinish = true;

			protected override void Init()
			{ }

			public void Log(string file, string str)
			{
				lock( m_queue )
				{
					m_queue.Enqueue( new Item() { File = file, Content = str } );
				}

				if( m_isFinish )
				{
					lock( this )
					{
						if( m_isFinish )
						{
							new Thread( new ThreadStart( LogThreadFun ) ).Start();
							m_isFinish = false;
						}
					}
				}

				m_event.Set();
			}

			void LogThreadFun()
			{
				while( !m_isFinish )
				{
					m_event.WaitOne();
					while( true )
					{
						Item item = null;
						lock( m_queue )
						{
							if( m_queue.Count > 0 )
								item = m_queue.Dequeue();
						}
						if( item == null )
							break;
						Write( item.File, item.Content );
					}
				}
			}

			protected override void DisposeUnmanaged()
			{
				base.DisposeUnmanaged();
				m_isFinish = true;
				m_event.Set();
			}
		}

		#endregion

		public FileLog(string dir, bool multipleThread = false)
		{
			m_dir = dir;
			if( !Directory.Exists( m_dir ) )
				Directory.CreateDirectory( m_dir );

			if( multipleThread )
				m_logger = ThreadLogger.Instance;
			else
				m_logger = Logger.Instance;
		}

		static void Write(string logFile, string str)
		{
			using( StreamWriter sw = new StreamWriter( logFile, true, Encoding.UTF8 ) )
			{
				sw.WriteLine( DateTime.Now.ToString( "[yyyy-MM-dd HH:mm:ss] :" ) + str );
			}
		}

		void _Log(string prefix, string format, params object[] args)
		{
			m_logger.Log( Path.Combine( m_dir, "tool_log.log" ), string.Format( prefix + format, args ) );
		}

		#region ILog

		public void Debug(string format, params object[] args)
		{
			_Log( "Debug ", format, args );
		}

		public void Warning(string format, params object[] args)
		{
			_Log( "Warning ", format, args );
		}

		public void Error(string format, params object[] args)
		{
			_Log( "Error ", format, args );
		}

		#endregion

		protected override void DisposeUnmanaged()
		{
			base.DisposeUnmanaged();
			m_logger.Dispose();
		}
	}
}