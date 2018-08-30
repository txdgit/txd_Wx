using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 实体转化Json数据
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <returns>Json数据</returns>
        public static string JsonSerializer<T>(T t)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(new JsonTextWriter(sw), t);
                return sw.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
                return default(T);
            JsonSerializer serializer1 = new JsonSerializer();
            using (StringReader sr = new StringReader(json))
            {
                T t = (T)serializer1.Deserialize(new JsonTextReader(sr), typeof(T));
                return t;
            }
        }
    }
}
