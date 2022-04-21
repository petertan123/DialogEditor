using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace ET
{
    //MARKER：对于BranchNode来说Output是无用的
    [CreateNodeMenu("BranchNode")]
    public class BranchNode:DialogBaseNode
    {
        [Output(dynamicPortList = true)]public List<Answer> Answers = new List<Answer>();

        [Serializable]
        public class Answer
        {
            public string text;
            public string musicName;
        }
        
        

        // public override void OnCreateConnection(NodePort @from, NodePort to)
        // {
        //     DialogBaseNode fromNode = from.node as DialogBaseNode;
        //     DialogBaseNode toNode = to.node as DialogBaseNode;
        //
        //     //判断是否是从自身延伸出去
        //     if (fromNode == this)
        //     {
        //         if (!toNode.Input.Contains(fromNode.NodeId))
        //         {
        //             toNode.Input.Add(fromNode.NodeId);
        //         }
        //         
        //         //获取到对应的Answer
        //         int index = from.fieldName.Split(' ')[1].ToInt32();
        //         Answer answer = this.Answers[index];
        //
        //         answer.nextNodeId = toNode.NodeId;
        //     }
        //     else
        //     {
        //         base.OnCreateConnection(from,to);
        //     }
        // }
        //
        // public override void OnRemoveConnection(NodePort port)
        // {
        //     //判断是否是自身延伸出去
        //     if (port.node == this)
        //     {
        //         int index = port.fieldName.Split(' ')[1].ToInt32();
        //         Answer answer = this.Answers[index];
        //
        //         answer.nextNodeId = 0;
        //     }
        //     else
        //     {
        //         base.OnRemoveConnection(port);
        //     }
        // }

        public override void Trigger(DialogTree dialogTree)
        {
            base.Trigger(dialogTree);
            DialogBranchNode branchNode = new DialogBranchNode(this.NodeId,this.Input,this.Output);

            //添加answers
            for (int i = 0; i < this.Answers.Count; i++)
            {
                NodePort connection = this.GetOutputPort($"Answers {i}").Connection;
                DialogBaseNode toNode = connection.node as DialogBaseNode;
                Answer answer = this.Answers[i];
                branchNode.AddAnswer(answer.text,answer.musicName,toNode.NodeId);
            }
            dialogTree.AddNode(branchNode);
            
            //处理每个Answer的Connection
            for (int i = 0; i < this.Answers.Count; i++)
            {
                NodePort connection = this.GetOutputPort($"Answers {i}").Connection;
                if(connection == null) continue;
                DialogBaseNode toNode = connection.node as DialogBaseNode;
                toNode.Trigger(dialogTree);
            }
        }
    }
}