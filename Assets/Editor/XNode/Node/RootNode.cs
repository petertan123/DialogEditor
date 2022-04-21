using System;
using XNode;

namespace ET
{
    //一张图中只允许出现一个，作为树的根结点使用
    [CreateNodeMenu("RootNode")]
    public class RootNode:DialogBaseNode
    {
        protected override void Init()
        {
            DialogGraph dialogGraph = this.graph as DialogGraph;
            dialogGraph.SetRootNode(this);
        }

        private void OnDestroy()
        {
            DialogGraph dialogGraph = this.graph as DialogGraph;
            dialogGraph.ClearRootNode();
        }

        public override void Trigger(DialogTree dialogTree)
        {
            base.Trigger(dialogTree);
            NodePort connection = this.GetOutputPort("Output").Connection;
            if (connection != null)
            {
                DialogBaseNode toNode = connection.node as DialogBaseNode;
                toNode.Trigger(dialogTree);
                //MARKER:设置其为rootNode
                dialogTree.SetRootNodeId(toNode.NodeId);
            }
            
        }
    }
}