using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Adam.Util
{
    public class XmlObjectSerializer
    {
        /// <summary>
        /// 將物件序列化成XML格式字串
        /// </summary>
        /// <typeparam name="T">物件型別</typeparam>
        /// <param name="obj">物件</param>
        /// <returns>XML格式字串</returns>
        public static string Serialize<T>(T obj) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                serializer.Serialize(writer, obj);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// 將XML格式字串反序列化成物件
        /// </summary>
        /// <typeparam name="T">物件型別</typeparam>
        /// <param name="xmlString">XML格式字串</param>
        /// <returns>反序列化後的物件</returns>
        public static T Deserialize<T>(string xmlString) where T : class
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlString))
            {
                object deserializationObj = deserializer.Deserialize(reader);
                return deserializationObj as T;
            };
        }
    }
}
