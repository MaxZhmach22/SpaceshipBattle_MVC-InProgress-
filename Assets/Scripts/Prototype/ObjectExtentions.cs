using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace HellicopterGame.Prototype
{
    public static class ObjectExtentions
    {
        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Not Serializable");
            }

            if (ReferenceEquals(self, null))
            {
                return default;
            }

            var formetter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formetter.Serialize(stream,self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formetter.Deserialize(stream);
            }
        }
    }
}