using System;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

namespace ET
{
    public class DialogTree
    {
        public long rootNodeId;

        //public List<long> nodeIds = new List<long>();
        //public List<BaseDialogNode> nodes = new List<BaseDialogNode>();

        public Dictionary<long, BaseDialogNode> id2Nodes = new Dictionary<long, BaseDialogNode>();

        /// <summary>
        /// 设置DialogTree中的根结点Id
        /// </summary>
        /// <param name="_rootNodeId"></param>
        public void SetRootNodeId(long _rootNodeId)
        {
            this.rootNodeId = _rootNodeId;
        }

        /// <summary>
        /// 根据结点Id获取Tree中对应结点
        /// </summary>
        /// <param name="_nodeId"></param>
        /// <returns></returns>
        public BaseDialogNode GetNodeById(long _nodeId)
        {
            BaseDialogNode node = null;
            this.id2Nodes.TryGetValue(_nodeId, out node);
            return node;
        }
        

        /// <summary>
        /// 往DialogTree中添加对应的结点
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(BaseDialogNode node)
        {
            if (!this.id2Nodes.ContainsKey(node.nodeID))
            {
                this.id2Nodes.Add(node.nodeID,node);
            }

        }


        /// <summary>
        /// 删除DialogTree中对应的结点
        /// </summary>
        /// <param name="nodeId"></param>
        public void RemoveNode(long nodeId)
        {
            if (this.id2Nodes.ContainsKey(nodeId))
            {
                this.id2Nodes.Remove(nodeId);
            }
        }


        public void SaveAsJson(string name)
        {
            string jsonStr = JsonHelper.ToJson(this);
            string path = "Assets/Resources/Dialog/"+$"{name}.txt";
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Write(jsonStr);
                sw.Close();
            }
            catch(Exception ex)
            {
                Debug.LogError("Exception:" + ex);
            }
            
        }

        public static DialogTree LoadFromJson(string jsonData)
        {
            DialogTree dialogTree = JsonHelper.FromJson<DialogTree>(jsonData);
            return dialogTree;
        }
        
        
    }
}