using System;
using System.Reflection;
using System.Xml.Linq;

namespace UnityPractice.XMLLoader
{
    /// <summary>
    /// XML文件转换成类的实例
    /// </summary>
    public static class XMLToIns<T> where T : class
    {
        private static string Path;
        private static T Target;

        /// <summary>
        /// 返回一个实例
        /// </summary>
        /// <returns></returns>
        public static T ToIns()
        {
            if (Target != null)
                Target = null;

            CreateInitiate();
            XElement xml = LoadXML();
            Type t = Target.GetType();
            FieldInfo[] fields = t.GetFields();
            string fieldName = string.Empty;

            foreach (FieldInfo f in fields)
            {
                fieldName = f.Name;
                if (xml.Element(fieldName) != null)
                {
                    f.SetValue(Target, Convert.ChangeType(xml.Element(fieldName).Value, f.GetType()));
                }
            }

            return Target;
        }

        /// <summary>
        /// 设置XML文件路径
        /// </summary>
        /// <param name="path"></param>
        public static void SetPath(string path)
        {
            Path = path;
        }

        /// <summary>
        /// 加载XML文件
        /// </summary> <summary>
        private static XElement LoadXML()
        {
            if (Path == null)
                return null;
            else
            {
                XElement xml = XElement.Load(Path);
                return xml;
            }
        }

        /// <summary>
        /// 初始化一个默认的类实例
        /// </summary>
        private static void CreateInitiate()
        {
            Type t = typeof(T);
            ConstructorInfo ct = t.GetConstructor(Type.EmptyTypes);
            Target = (T)ct.Invoke(null);
        }

    }
}