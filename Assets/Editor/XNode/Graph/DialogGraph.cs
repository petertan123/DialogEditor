using System;
using UnityEngine;
using XNode;


namespace ET
{
    [Serializable,CreateAssetMenu(fileName = "New DialogGraph",menuName = "xNode Graph/DialogGraph")]
    public class DialogGraph:NodeGraph
    {
        //用于导出DialogTree
        public DialogTree m_tree;
        
        //当前Graph的根结点
        private DialogBaseNode rootNode;

        public DialogTree OutputTree()
        {
            if (this.rootNode == null)
            {
                Debug.LogWarning("Must Has One RootNode!");
                return null;
            }

            this.m_tree = new DialogTree();
            this.rootNode.Trigger(this.m_tree);
            return this.m_tree;
        }

        public void SetRootNode(DialogBaseNode baseNode)
        {
            if (this.rootNode != null)
            {
                Debug.LogWarning("Must Only Has One RootNode!");
                return;
            }
            this.rootNode = baseNode;
        }

        public void ClearRootNode()
        {
            this.rootNode = null;
        }
    }
}