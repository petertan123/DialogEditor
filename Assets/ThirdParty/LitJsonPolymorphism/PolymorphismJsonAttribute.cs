namespace LitJson
{
    using System;

    /// <summary>
    /// �������л��뷴���л��Ƿ��̬
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class PolymorphismJsonAttribute : Attribute
    {

    }
}