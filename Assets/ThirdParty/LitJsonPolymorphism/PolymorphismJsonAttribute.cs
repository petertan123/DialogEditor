namespace LitJson
{
    using System;

    /// <summary>
    /// 该类序列化与反序列化是否多态
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class PolymorphismJsonAttribute : Attribute
    {

    }
}