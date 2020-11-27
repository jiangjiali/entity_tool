using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using UsertypeDefTools;

public class EntityDef
{
    public enum Flags { BASE, BASE_AND_CLIENT, CELL_PRIVATE, CELL_PUBLIC, CELL_PUBLIC_AND_OWN, ALL_CLIENTS, OWN_CLIENT, OTHER_CLIENTS }
    public enum IndexType { UNIQUE, INDEX }

    public class DefVolatile
    {
        public float? Position;
        public float? Yaw;
        public float? Pitch;
        public float? Roll;
        public string optimized;

        public DefVolatile(XmlNode node)
        {
            Position = GetValue(node, "position");
            Yaw = GetValue(node, "yaw");
            Pitch = GetValue(node, "pitch");
            Roll = GetValue(node, "roll");
            optimized = GetValueb(node, "optimized");
        }

        public DefVolatile()
        {
            // TODO: Complete member initialization
        }

        string GetValueb(XmlNode node, string name)
        {
            var n = node.SelectSingleNode(name);
            if (n == null)
                return "false";
            else
            {
                if (string.IsNullOrEmpty(n.InnerText.Trim()))
                    return "false";
                else
                    return "true";
            }
        }

        float? GetValue(XmlNode node, string name)
        {
            var n = node.SelectSingleNode(name);
            if (n == null)
                return null;
            else
            {
                if (string.IsNullOrEmpty(n.InnerText.Trim()))
                    return null;
                else
                    return float.Parse(n.InnerText.Trim());
            }
        }

        public XmlNode GenerateXmlNode(XmlDocument doc)
        {
            var v = doc.CreateElement("Volatile");

            if (Position.HasValue)
            {
                var p = doc.CreateElement("position");
                p.InnerText = Position.Value.ToString();
                v.AppendChild(p);
            }

            if (Yaw.HasValue)
            {
                var y = doc.CreateElement("yaw");
                y.InnerText = Yaw.Value.ToString();
                v.AppendChild(y);
            }

            if (Pitch.HasValue)
            {
                var p = doc.CreateElement("pitch");
                p.InnerText = Pitch.Value.ToString();
                v.AppendChild(p);
            }

            if (Roll.HasValue)
            {
                var r = doc.CreateElement("roll");
                r.InnerText = Roll.Value.ToString();
                v.AppendChild(r);
            }

            if (optimized == "true")
            {
                var o = doc.CreateElement("optimized");
                o.InnerText = optimized.ToString();
                v.AppendChild(o);
            }



            return v;
        }
    }

    public class Property
    {
        public string Name;
        public IType Type;
        public string Default;
        public UInt16? Utype;
        public Flags Flags;
        public bool? Persistent;
        public uint? DatabaseLength;
        public IndexType? IndexType;

        public Property()
        {
            Type = BaseType.AllTypes[0];
            Flags = EntityDef.Flags.CELL_PRIVATE;
        }

        public Property(XmlNode node)
        {
            Name = node.Name;

            var typeStr = GetValue(node, "Type");
            Type = BaseType.AllTypes.Find(e => e.TypeName == typeStr);
            if (Type == null)
            {
                Type = node.SelectSingleNode("Type").GetIType();
                if (Type == null)
                    throw new ArgumentException(string.Format("Unknown tyoe '{0}'", typeStr));
            }

            Default = GetValue(node, "Default");

            var utypeStr = GetValue(node, "Utype");
            if (!string.IsNullOrEmpty(utypeStr))
                Utype = UInt16.Parse(utypeStr);

            var flagsStr = GetValue(node, "Flags");
            if (!string.IsNullOrEmpty(flagsStr))
                Flags = (Flags)Enum.Parse(typeof(Flags), flagsStr);

            var persistentStr = GetValue(node, "Persistent");
            if (!string.IsNullOrEmpty(persistentStr))
                Persistent = bool.Parse(persistentStr);

            var databaseLengthStr = GetValue(node, "DatabaseLength");
            if (!string.IsNullOrEmpty(databaseLengthStr))
                DatabaseLength = uint.Parse(databaseLengthStr);

            var indexTypeStr = GetValue(node, "Index");
            if (!string.IsNullOrEmpty(indexTypeStr))
                IndexType = (IndexType)Enum.Parse(typeof(IndexType), indexTypeStr);
        }

        string GetValue(XmlNode node, string key)
        {
            var n = node.SelectSingleNode(key);
            return n != null ? n.InnerText.Trim() : null;
        }

        public override string ToString()
        {
            return string.Format("Name:{0},Type:{1},Utype:{2},Flags:{3},Persistent:{4},DatabaseLength:{5},IndexType:{6}", Name, Type, Utype, Flags, Persistent, DatabaseLength, IndexType);
        }

        internal XmlNode GenerateXmlNode(XmlDocument doc)
        {
            var ret = doc.CreateElement(Name);

            if (Type != null)
            {
                var t = doc.CreateElement("Type");
                if (Type is BaseType)
                    t.InnerText = Type.TypeName;
                else
                    t.InnerXml = (Type as ArrayType).GetXmlText();
                ret.AppendChild(t);
            }

            if (Default != null)
            {
                var d = doc.CreateElement("Default");
                d.InnerText = Default;
                ret.AppendChild(d);
            }

            if (Utype != null)
            {
                var u = doc.CreateElement("Utype");
                u.InnerText = Utype.Value.ToString();
                ret.AppendChild(u);
            }

            var f = doc.CreateElement("Flags");
            f.InnerText = Flags.ToString();
            ret.AppendChild(f);

            if (Persistent != null)
            {
                var p = doc.CreateElement("Persistent");
                p.InnerText = Persistent.Value.ToString().ToLower();
                ret.AppendChild(p);
            }

            if (DatabaseLength != null)
            {
                var d = doc.CreateElement("DatabaseLength");
                d.InnerText = DatabaseLength.Value.ToString();
                ret.AppendChild(d);
            }

            if (IndexType != null)
            {
                var i = doc.CreateElement("Index");
                i.InnerText = IndexType.Value.ToString();
                ret.AppendChild(i);
            }

            return ret;
        }
    }

    public class Method
    {
        public string Name;
        public bool Exposed;
        public UInt16? Utype;
        public List<IType> Args = new List<IType>();

        public Method(XmlNode node)
        {
            Name = node.Name;

            var exposedNode = node.SelectSingleNode("Exposed");
            if (exposedNode != null)
                Exposed = true;

            var utypeStr = GetValue(node, "Utype");
            if (!string.IsNullOrEmpty(utypeStr))
                Utype = UInt16.Parse(utypeStr);

            var argNodes = node.SelectNodes("Arg");
            foreach (XmlNode item in argNodes)
            {
                var typeStr = item.InnerText.Trim();
                IType type = BaseType.AllTypes.Find(e => e.TypeName == typeStr);
                if (type == null)
                {
                    type = item.GetIType();
                    if (type == null)
                        throw new ArgumentException(string.Format("Unknown tyoe '{0}'", typeStr));
                }
                Args.Add(type);
            }

        }

        public Method()
        {
            // TODO: Complete member initialization
        }

        string GetValue(XmlNode node, string key)
        {
            var n = node.SelectSingleNode(key);
            return n != null ? n.InnerText.Trim() : null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Name:{0} Exposed:{1} Utype:{2} ", Name, Exposed, Utype);
            if (Args.Count > 0)
            {
                sb.Append('[');
                foreach (var item in Args)
                    sb.AppendFormat("type:{0} ", item.TypeName);
                sb.Append(']');
            }
            return sb.ToString();
        }

        internal XmlNode GenerateXmlNode(XmlDocument doc)
        {
            var ret = doc.CreateElement(Name);
            if (Exposed)
                ret.AppendChild(doc.CreateElement("Exposed"));

            if (Utype != null)
            {
                var u = doc.CreateElement("Utype");
                u.InnerXml = Utype.Value.ToString();
                ret.AppendChild(u);
            }

            foreach (var item in Args)
            {
                var a = doc.CreateElement("Arg");
                if (item is BaseType)
                    a.InnerText = item.TypeName;
                else
                    a.InnerXml = (item as ArrayType).GetXmlText();
                ret.AppendChild(a);
            }

            return ret;
        }
    }

    public string Name;
    public bool IsInterface;

    public bool HasClient;
    public bool IsRegistered;
    public EntityDef Parent;
    public DefVolatile Volatile;
    public List<EntityDef> Implements = new List<EntityDef>();
    public List<Property> Properties = new List<Property>();

    public List<Method> ClientMethods = new List<Method>();
    public List<Method> BaseMethods = new List<Method>();
    public List<Method> CellMethods = new List<Method>();

    public static Dictionary<string, EntityDef> AllEntityDefs = new Dictionary<string, EntityDef>();

    public EntityDef(string name, bool isInterface)
    {
        Name = name;
        IsInterface = isInterface;
    }

    void Reset(string content)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(content);
        var root = xmlDoc.SelectSingleNode("root");

        //Parent
        var parent = root.SelectSingleNode("Parent");
        if (parent != null)
            Parent = AllEntityDefs[parent.InnerText.Trim()];

        //Volatile
        var v = root.SelectSingleNode("Volatile");
        if (v != null)
            Volatile = new DefVolatile(v);

        //Implements
        var implements = root.SelectSingleNode("Implements");
        if (implements != null)
        {
            foreach (XmlNode item in implements.ChildNodes)
                Implements.Add(AllEntityDefs[item.InnerText.Trim()]);
        }

        //Properties
        var properties = root.SelectSingleNode("Properties");
        if (properties != null)
        {
            foreach (XmlNode item in properties)
            {

                if (item.InnerText.Trim().Length > 1 && item.InnerText.Trim().Substring(0, 1) == "<")
                {
                    MessageBox.Show("定义文件内可能带有‘<--’");
                }
                else
                {
                    var p = new Property(item);
                    Properties.Add(p);
                }

            }
        }

        //ClientMethods
        var clientMethods = root.SelectSingleNode("ClientMethods");
        if (clientMethods != null)
        {
            foreach (XmlNode item in clientMethods)
            {
                if (item.InnerText.Trim().Length > 1 && item.InnerText.Trim().Substring(0, 1) == "<")
                {
                    MessageBox.Show("定义文件内可能带有‘<--’");
                }
                else
                {

                    var c = new Method(item);
                    ClientMethods.Add(c);
                }
            }
        }

        //BaseMethods
        var baseMethods = root.SelectSingleNode("BaseMethods");
        if (baseMethods != null)
        {
            foreach (XmlNode item in baseMethods)
            {
                if (item.InnerText.Trim().Length > 1 && item.InnerText.Trim().Substring(0, 1) == "<")
                {
                    MessageBox.Show("定义文件内可能带有‘<--’");
                }
                else
                {
                    var b = new Method(item);
                    BaseMethods.Add(b);
                }
            }
        }

        //CellMethods
        var cellMethods = root.SelectSingleNode("CellMethods");
        if (cellMethods != null)
        {
            foreach (XmlNode item in cellMethods)
            {
                if (item.InnerText.Trim().Length>1&& item.InnerText.Trim().Substring(0, 1) == "<")
                {
                    MessageBox.Show("定义文件内可能带有‘<--’");
                }
                else
                {
                    var cell = new Method(item);
                    CellMethods.Add(cell);
                }
            }
        }
    }

    public static void LoadFromFile(string dir)
    {
        if (!Directory.Exists(dir))
        {
            MessageBox.Show(string.Format("'{0}' is not exists.", dir));
            return;
        }

        AllEntityDefs.Clear();

        //Create
        foreach (var item in AllFiles(dir))
        {
            var name = Path.GetFileNameWithoutExtension(item.Key.FullName);
            AllEntityDefs.Add(name, new EntityDef(name, item.Value));
        }

        //Reset
        foreach (var item in AllFiles(dir))
        {
            var name = Path.GetFileNameWithoutExtension(item.Key.FullName);
            AllEntityDefs[name].Reset(File.ReadAllText(item.Key.FullName));
        }

        var entitiesDefXml = File.ReadAllText(SlnConfig.Instance.EntitiesPath);
        XmlDocument entitiesDoc = new XmlDocument();
        entitiesDoc.LoadXml(entitiesDefXml);
        var entitiesRoot = entitiesDoc.SelectSingleNode("root");
        foreach (XmlNode item in entitiesRoot.ChildNodes)
        {
            if (item.Name != "#comment")
            {
                if (!AllEntityDefs.ContainsKey(item.Name))
                {
                    MessageBox.Show(string.Format("Entity '{0}' is not exists.", item.Name));
                    continue;
                }
                AllEntityDefs[item.Name].IsRegistered = true;
                var hasClientStr = item.Attributes["hasClient"];
                if (hasClientStr != null && !string.IsNullOrEmpty(hasClientStr.Value))
                    AllEntityDefs[item.Name].HasClient = bool.Parse(hasClientStr.Value);
            }
        }

        //WriteToFile(dir);
    }

    static IEnumerable<KeyValuePair<FileInfo, bool>> AllFiles(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        foreach (FileInfo file in dir.GetFiles("*.def"))
            yield return new KeyValuePair<FileInfo, bool>(file, false);

        foreach (FileInfo file in new DirectoryInfo(Path.Combine(path, "interfaces/")).GetFiles("*.def"))
            yield return new KeyValuePair<FileInfo, bool>(file, true);
    }

    void Save(string dir)
    {
        XmlDocument doc = new XmlDocument();

        XmlElement root = doc.CreateElement("root");
        doc.AppendChild(root);

        if (!IsInterface && IsRegistered && Parent != null)
        {
            XmlElement parent = doc.CreateElement("Parent");
            parent.InnerText = Parent.Name;
            root.AppendChild(parent);
        }

        if (Volatile != null && (Volatile.Position.HasValue || Volatile.Pitch.HasValue || Volatile.Roll.HasValue || Volatile.Yaw.HasValue || Volatile.optimized =="true"))
        {
            root.AppendChild(Volatile.GenerateXmlNode(doc));
        }

        if (Implements.Count > 0)
        {
            var i = doc.CreateElement("Interfaces");
            foreach (var item in Implements)
            {
                var interfaceE = doc.CreateElement("Interface");
                interfaceE.InnerText = item.Name;
                i.AppendChild(interfaceE);
            }
            root.AppendChild(i);
        }

        if (Properties.Count > 0)
        {
            var p = doc.CreateElement("Properties");
            foreach (var item in Properties)
            {
                p.AppendChild(item.GenerateXmlNode(doc));
            }
            root.AppendChild(p);
        }

        if (ClientMethods.Count > 0)
        {
            var c = doc.CreateElement("ClientMethods");
            foreach (var item in ClientMethods)
            {
                c.AppendChild(item.GenerateXmlNode(doc));
            }
            root.AppendChild(c);
        }

        if (BaseMethods.Count > 0)
        {
            var b = doc.CreateElement("BaseMethods");
            foreach (var item in BaseMethods)
            {
                b.AppendChild(item.GenerateXmlNode(doc));
            }
            root.AppendChild(b);
        }

        if (CellMethods.Count > 0)
        {
            var c = doc.CreateElement("CellMethods");
            foreach (var item in CellMethods)
            {
                c.AppendChild(item.GenerateXmlNode(doc));
            }
            root.AppendChild(c);
        }

        string formatStr = IsInterface ? "interfaces/{0}.def" : "{0}.def";

        var path = Path.Combine(dir, string.Format(formatStr, Name));

        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            using (XmlTextWriter writer = new XmlTextWriter(fileStream, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;
                writer.IndentChar = '\t';
                doc.WriteTo(writer);

                writer.Close();
            }
            fileStream.Close();
        }
    }

    public static void WriteToFile(string dir)
    {
        foreach (var entity in AllEntityDefs)
        {
            entity.Value.Save(dir);
        }

        XmlDocument doc = new XmlDocument();

        XmlElement root = doc.CreateElement("root");
        doc.AppendChild(root);
        foreach (var item in AllEntityDefs.Values)
        {
            if (item.IsRegistered)
            {
                var e = doc.CreateElement(item.Name);
                if (item.HasClient)
                    e.SetAttribute("hasClient", "true");
                root.AppendChild(e);
            }
        }

        using (FileStream fileStream = new FileStream(SlnConfig.Instance.EntitiesPath, FileMode.Create))
        {
            using (XmlTextWriter writer = new XmlTextWriter(fileStream, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;
                writer.IndentChar = '\t';
                doc.WriteTo(writer);

                writer.Close();
            }
            fileStream.Close();
        }


        foreach (var f in Directory.GetFiles(SlnConfig.Instance.EntityDefDir, "*.def"))
        {
            var fn = Path.GetFileNameWithoutExtension(f);
            if (!AllEntityDefs.Values.Any(e => e.Name == fn) || AllEntityDefs.Values.First(a => a.Name == fn).IsInterface)
                File.Delete(f);
        }
        foreach (var f in Directory.GetFiles(Path.Combine(SlnConfig.Instance.EntityDefDir, @"interfaces\"), "*.def"))
        {
            var fn = Path.GetFileNameWithoutExtension(f);
            if (!AllEntityDefs.Values.Any(e => e.Name == fn) || !AllEntityDefs.Values.First(a => a.Name == fn).IsInterface)
                File.Delete(f);
        }
    }
}
