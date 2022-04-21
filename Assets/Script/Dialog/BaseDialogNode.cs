
using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

namespace ET
{
    //等待后续拓展类型
    public enum DialogNodeType
    {
        Chat, //对话
        Branch, //分支
        Event, //事件
    }
    
    [PolymorphismJson]
    [Serializable]
    //MARKER：可以有多个输入但只能有一个输出
    public class BaseDialogNode
    {
        public DialogNodeType type;

        public string Type
        {
            set
            {
                this.type = (DialogNodeType)System.Enum.Parse(typeof (DialogNodeType), value);
            }
        }
        
        /// <summary>
        /// 结点索引
        /// </summary>
        /// <returns></returns>
        public long nodeID;
        
        /// <summary>
        /// 前驱结点Id
        /// </summary>
        [SerializeField] public List<long> previousNodeIds = new List<long>();

        /// <summary>
        /// 后继结点Id
        /// </summary>
        public long nextNodeId;

        public BaseDialogNode()
        {
            
        }
        
        public BaseDialogNode(long _nodeId, List<long> _previousNodeIds,long _nextNodeId)
        {
            this.nodeID = _nodeId;
            this.previousNodeIds = _previousNodeIds;
            this.nextNodeId = _nextNodeId;
        }
        
    }
}