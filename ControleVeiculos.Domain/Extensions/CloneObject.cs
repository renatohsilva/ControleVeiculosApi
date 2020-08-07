using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ControleVeiculos.Domain.Extensions
{
    public static class CloneObject
    {
		public static T DeepClone<T>(this T obj)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, obj);
				stream.Position = 0;

				return (T)formatter.Deserialize(stream);
			}
		}
	}
}
