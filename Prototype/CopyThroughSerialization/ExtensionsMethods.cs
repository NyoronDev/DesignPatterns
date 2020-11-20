using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype.CopyThroughSerialization
{
    public static class ExtensionsMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            // We use the memory stream and the formatter to serialize / deserialize to clone the object
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);

            object copy = formatter.Deserialize(stream);

            stream.Close();

            return (T)copy;
        }

        // With Xml Serializer we dont need to tag all clases with [Serializable]
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }
}