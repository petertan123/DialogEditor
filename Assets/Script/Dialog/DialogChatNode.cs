using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [Serializable]
    public class DialogChatNode:BaseDialogNode
    {
        //MARKER:需要与nodeGraph中的内容一一对应

        /// <summary>
        /// 当前的对话Id
        /// </summary>
        public int dialogId;
        
        /// <summary>
        /// 当前对话的人物名
        /// </summary>
        public string name;

        /// <summary>
        /// 当前对话的人物头像
        /// </summary>
        //public Sprite avatarSprite;

        /// <summary>
        /// 当前对话人物头像路径
        /// </summary>
        public string avatarPath;

        /// <summary>
        /// 当前的对话内容
        /// </summary>
        public string content;

        public DialogChatNode()
        {
            
        }

        public DialogChatNode(long _nodeId, List<long> _previousNodeIds, long _nextNodeId):base(_nodeId, _previousNodeIds, _nextNodeId)
        {
            this.type = DialogNodeType.Chat;
        }
        

       
    }
}