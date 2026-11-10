using System.ComponentModel;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace application_lib.Services
{
    public static class Extentions
    {
        public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer
                .GroupJoin(inner, outerKeySelector, innerKeySelector, (outerObj, inners) =>
                new
                {
                    outerObj,
                    inners = inners.DefaultIfEmpty()
                })
            .SelectMany(a => a.inners.Select(innerObj => resultSelector(a.outerObj, innerObj!)));
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> array, Action<T> act)
        {
            foreach (var i in array)
                act(i);
            return array;
        }


        public static T Deserialize<T>(this string value)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            return (T)xmlSerializer.Deserialize(new StringReader(value))!;
        }

        public static string Serialize<T>(this T value)
        {
            if (value == null)
                return string.Empty;

            var xmlSerializer = new XmlSerializer(typeof(T));

            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using var stringWriter = new StringWriter();

            using var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true });

            xmlSerializer.Serialize(xmlWriter, value, ns);

            return stringWriter.ToString();
        }

        public static string RemoveDeclaration(this string value)
        {
            try
            {
                XDocument doc = XDocument.Parse(value);
                doc.Declaration = null;
                return doc.ToString();
            }
            catch
            {
                return value;
            }
        }

        public static string GetEnumDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            if (field is null)
                return string.Empty;

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return string.Empty;
        }

        public static string HashData(this string content) =>
            Convert.ToBase64String(new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding("windows-1251").GetBytes(content)));

    }
}
