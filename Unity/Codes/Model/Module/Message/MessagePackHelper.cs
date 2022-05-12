using System;
using System.IO;
using MessagePack;

namespace ET
{
    
    public static class MessagePackHelper
    {
        static MessagePackHelper()
        {

        }

        public static void Init()
        {
        }
        
        public static object FromBytes(Type type, byte[] bytes, int index, int count)
        {
            ReadOnlyMemory<byte> memory = new ReadOnlyMemory<byte>(bytes, index, count);
            
            var options = MessagePackSerializerOptions .Standard;
            options.WithSecurity(MessagePackSecurity.UntrustedData);
            //options.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray);
            //MessagePack.MessagePackSerializer.DefaultOptions = options;
            return MessagePackSerializer.Deserialize(type, memory,options);
        }
        public static byte[] ToBytes(object message)
        {
            //var lz4Options = MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray);
            return MessagePackSerializer.Serialize(message);
        }
        
        public static void ToStream(object message, MemoryStream stream)
        {
            //var lz4Options = MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray);
            MessagePackSerializer.Serialize(stream, message);
        }

        public static object FromStream(Type type, MemoryStream stream)
        {
            var options = MessagePackSerializerOptions .Standard;
            options.WithSecurity(MessagePackSecurity.UntrustedData);
            //options.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray);
        
            return MessagePackSerializer.Deserialize(type, stream,options);
        }
    }
    
}