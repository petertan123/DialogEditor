using LitJson;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CSharp;


[LitJson.PolymorphismJson]
public interface IPolymorphismFromJson
{
}


[Serializable]
public class ClassBaseA : IPolymorphismFromJson
{
    public int a;
}

[Serializable]
public class ClassExtendB : ClassBaseA
{
    public int b;
}

[Serializable]
public class ClassExtendC : ClassBaseA
{
    public int c;
}

[Serializable]
public class ClassExtendD : ClassExtendB
{
    public int d;
}

[Serializable]
public class SerializeClass
{
    public int normalField = 1;
    public ClassBaseA specialFiled;
}

class Program
{
    public static int Add(int a, int b)
    {
        return a * b;
    }
    
    public static int RealAdd(int a, int b)
    {
        return a + b;
    }

    public static void Main(string[] args)
    {
        var b = new ClassExtendB() {a = 1, b = 2};
        SerializeClass toJsonObject = new SerializeClass() {specialFiled = b};
        
        var d = new ClassExtendD() {a = 2, b = 5, d = 8};
        SerializeClass toJsonObject2 = new SerializeClass() {normalField = 2, specialFiled = d};
        
        var c = new ClassExtendC() {a = 3, c = 6};
        SerializeClass toJsonObject3 = new SerializeClass() {normalField = 3, specialFiled = c};
        
        List<SerializeClass> lists = new List<SerializeClass>() {toJsonObject, toJsonObject2, toJsonObject3};
        
        // 序列化
        var jsonString = LitJson.JsonMapper.ToJson(toJsonObject);
        Console.WriteLine(jsonString);
        
        // 反序列化
        SerializeClass fromJsonObject = LitJson.JsonMapper.ToObject<SerializeClass>(jsonString);
        Console.WriteLine(LitJson.JsonMapper.ToJson(fromJsonObject));
        
        Console.WriteLine("==================");
        
        // 序列化
        var jsonString2 = LitJson.JsonMapper.ToJson(toJsonObject2);
        Console.WriteLine(jsonString2);
        
        // 反序列化
        SerializeClass fromJsonObject2 = LitJson.JsonMapper.ToObject<SerializeClass>(jsonString2);
        Console.WriteLine(LitJson.JsonMapper.ToJson(fromJsonObject2));
        
        Console.WriteLine("==================");
        
        // 序列化
        var jsonString3 = LitJson.JsonMapper.ToJson(toJsonObject3);
        Console.WriteLine(jsonString3);
        
        // 反序列化
        SerializeClass fromJsonObject3 = LitJson.JsonMapper.ToObject<SerializeClass>(jsonString3);
        Console.WriteLine(LitJson.JsonMapper.ToJson(fromJsonObject3));
        
        Console.WriteLine("==================");
        
        // 序列化
        var jsonString4 = LitJson.JsonMapper.ToJson(lists);
        Console.WriteLine(jsonString4);
        
        // 反序列化
        var fromJsonObject4 = LitJson.JsonMapper.ToObject<List<SerializeClass>>(jsonString4);
        Console.WriteLine(LitJson.JsonMapper.ToJson(fromJsonObject4));

        Console.ReadKey();
    }
}
