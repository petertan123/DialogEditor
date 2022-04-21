using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace ET
{
    [Serializable]
    public abstract class DialogBaseNode:Node
    {
        [Header("BaseValue")]
        public long NodeId; //结点ID
        
        //MARKER:可以有多个输入，但是只能有一个输出
        [Input(ShowBackingValue.Never)]
        [HideInInspector]
        public List<long> Input = new List<long>();

        [Output(ShowBackingValue.Never)]
        [HideInInspector]
        public long Output;
        

        public virtual void Trigger(DialogTree dialogTree)
        {
            this.LoadAllConnected();// 只在Trigger时获取
        }

        protected void LoadAllConnected()
        {
            this.Input.Clear();
            foreach (var nodeId in this.GetInputValues<long>("Input"))
            {
                this.Input.Add(nodeId);
            }

            NodePort connection = this.GetOutputPort("Output").Connection;
            if (connection != null)
            {
                DialogBaseNode toNode = connection.node as DialogBaseNode;
                this.Output = toNode.NodeId;
            }
            else
            {
                this.Output = 0;
            }
        }
        

        public override object GetValue(NodePort port)
        {
            //return this.NodeId;
            return null;
        }
        

        // public override void OnCreateConnection(NodePort from, NodePort to)
        // {
        //     DialogBaseNode fromNode = from.node as DialogBaseNode;
        //     DialogBaseNode toNode = to.node as DialogBaseNode;
        //
        //     if (fromNode == this)
        //     {
        //         if (fromNode.isConnectedOutput)
        //         {
        //             Debug.LogError("Output can only has one connection!");
        //         }
        //         else
        //         {
        //             fromNode.Output = toNode.NodeId;
        //             fromNode.isConnectedOutput = true;
        //         }
        //     }
        //     else if (toNode == this)
        //     {
        //         if (!toNode.Input.Contains(fromNode.NodeId))
        //         {
        //             toNode.Input.Add(fromNode.NodeId);
        //         }
        //     }
        //     
        //    
        //
        //     
        // }
        //
        // public override void OnRemoveConnection(NodePort port)
        // {
        //     if (port.IsInput)
        //     {
        //         //直接重新刷新this.Input
        //         this.Input.Clear();
        //         foreach (long nodeId in port.GetInputValues<long>())
        //         {
        //             this.Input.Add(nodeId);
        //         }
        //     }
        //     else if (port.IsOutput)
        //     {
        //         this.isConnectedOutput = false;
        //     }
        // }
    }
}