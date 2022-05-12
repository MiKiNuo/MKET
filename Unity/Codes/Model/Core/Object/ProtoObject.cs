using System;
#if NOT_UNITY
using System.ComponentModel;
#endif

namespace ET
{
#if !NOT_UNITY
    public interface ISupportInitialize
    {
        void BeginInit();
        void EndInit();
    }

    public interface IDisposable
    {
        void Dispose();
    }
#endif
    
    public abstract class ProtoObject: Object, ISupportInitialize
    {
        public object Clone()
        {
            byte[] bytes = MessagePackHelper.ToBytes(this);//ProtobufHelper.ToBytes(this);
            return MessagePackHelper.FromBytes(this.GetType(), bytes, 0, bytes.Length); //ProtobufHelper.FromBytes(this.GetType(), bytes, 0, bytes.Length);
        }
        
        public virtual void BeginInit()
        {
        }
        
        public virtual void EndInit()
        {
        }

        public virtual void AfterEndInit()
        {
        }
    }
    
    public abstract class DisposeObject: Object, IDisposable, ISupportInitialize
    {
        public virtual void Dispose()
        {
        }
        
        public virtual void BeginInit()
        {
        }
        
        public virtual void EndInit()
        {
        }
        
#if !NOT_UNITY
        public override string ToString()
        {
            return this.GetType().Name;

        }
#endif
    }
}