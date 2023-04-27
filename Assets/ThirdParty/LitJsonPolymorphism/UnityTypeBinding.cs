using UnityEngine;

namespace LitJson
{
    public static class Extensions {
 
        public static void WriteProperty(this JsonWriter w,string name,long value){
            w.WritePropertyName(name);
            w.Write(value);
        }
 
        public static void WriteProperty(this JsonWriter w,string name,string value){
            w.WritePropertyName(name);
            w.Write(value);
        }
 
        public static void WriteProperty(this JsonWriter w,string name,bool value){
            w.WritePropertyName(name);
            w.Write(value);
        }
 
        public static void WriteProperty(this JsonWriter w,string name,double value){
            w.WritePropertyName(name);
            w.Write(value);
        }
 
    }
    
    public class UnityTypeBindings
    {
        public static void Register()
        {
            JsonMapper.RegisterExporter<Vector2>((v, w) =>
            {
                w.WriteObjectStart();
                w.WriteProperty("x", v.x);
                w.WriteProperty("y", v.y);
                w.WriteObjectEnd();
            });
            
            JsonMapper.RegisterExporter<Vector3>((v, w) =>
            {
                w.WriteObjectStart();
                w.WriteProperty("x", v.x);
                w.WriteProperty("y", v.y);
                w.WriteProperty("z", v.z);
                w.WriteObjectEnd();
            });
            
            JsonMapper.RegisterExporter<Quaternion>((v, w) =>
            {
                w.WriteObjectStart();
                w.WriteProperty("x", v.x);
                w.WriteProperty("y", v.y);
                w.WriteProperty("z", v.z);
                w.WriteProperty("w", v.w);
                w.WriteObjectEnd();
            });
        }
    }
}