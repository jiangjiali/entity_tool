using Dev;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UsertypeDefTools
{
	[Serializable]
	public class SlnConfig : Singleton<SlnConfig>
	{
		[XmlAttribute]
		public string TypesPath;

		[XmlAttribute]
		public string EntityDefDir;

		[XmlAttribute]
		public string EntitiesPath;

        [XmlAttribute]
        public string TypePicklerDir;

        [XmlAttribute]
        public string CSharpCodeDir;

        public static bool Initialize(string dir)
		{
			Instance = new SlnConfig();

			Instance.TypesPath = Path.Combine( dir, @"scripts\entity_defs\types.xml");
			Instance.EntityDefDir = Path.Combine( dir, @"scripts\entity_defs" );
			Instance.EntitiesPath = Path.Combine( dir, @"scripts\entities.xml" );
            Instance.TypePicklerDir = Path.Combine(dir, @"scripts\user_type");
            Instance.CSharpCodeDir = Path.Combine(dir, @"scripts\user_type");

            if ( !Instance.Validate() )
			{
				MessageBox.Show( "必须在KBE资产目录", "提示");
				return false;
			}
			return true;
		}

        private bool Validate()
		{
			return File.Exists(TypesPath) &&
				   Directory.Exists( EntityDefDir ) &&
				   File.Exists( EntitiesPath );
		}

		protected override void Init()
		{
		}

		public string DefaultPath
		{
			get
			{
              return Environment.CurrentDirectory;
			}
		}
	}
}
