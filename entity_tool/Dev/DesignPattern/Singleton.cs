using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev
{
	public abstract class Singleton<T> : DisposableObject where T : Singleton<T>, new()
	{
		private static T s_instance;
		private static readonly object syslock = new object();
		public static T Instance
		{
			get
			{
				if( s_instance == null )
				{
					lock( syslock )
					{
						if( s_instance == null )
						{
							s_instance = new T();
							s_instance.Init();
						}
					}
				}
				return s_instance;

			}
			protected set { s_instance = value; }
		}
		protected abstract void Init();
	}
}