using System;
namespace ET
{
    public static class JsonHelper
    {
#if NOT_UNITY
        private static readonly MongoDB.Bson.IO.JsonWriterSettings logDefineSettings = new MongoDB.Bson.IO.JsonWriterSettings() { OutputMode = MongoDB.Bson.IO.JsonOutputMode.RelaxedExtendedJson };
#endif
        
        public static string ToJson(object message)
        {
#if NOT_UNITY
            return MongoDB.Bson.BsonExtensionMethods.ToJson(message, logDefineSettings);
#else
            return CatJson.JsonParser.ToJson(message);
#endif
        }
        
        public static object FromJson(Type type, string json)
        {
#if NOT_UNITY
            return MongoDB.Bson.Serialization.BsonSerializer.Deserialize(json, type);
#else
            return CatJson.JsonParser.ParseJson(json);
#endif
            
        }
        
        public static T FromJson<T>(string json)
        {
#if NOT_UNITY
            return MongoDB.Bson.Serialization.BsonSerializer.Deserialize<T>(json);
#else
            return CatJson.JsonParser.ParseJson<T>(json);
#endif
        }
    }
}