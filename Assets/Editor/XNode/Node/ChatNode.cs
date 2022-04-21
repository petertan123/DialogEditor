using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LitJson;
using UnityEditor;
using UnityEngine;
using XNode;

namespace ET
{
    [CreateNodeMenu("ChatNode")]
    public class ChatNode:DialogBaseNode
    {
        public int DialogId; //当前的对话Id
        public string Name; //当前对话的人物名
        public Sprite Sprite;//当前对话的人物头像

        [TextArea]
        public string Content; //当前对话内容
        

        public override void Trigger(DialogTree dialogTree)
        {
            // DialogGraph graph = this.graph as DialogGraph;
            //
            // //生成一个新的DialogChatNode并初始化
            // DialogChatNode dialogChatNode = new DialogChatNode();
            // dialogChatNode.dialogId = this.DialogId;
            // dialogChatNode.name = this.Name;
            // if (this.Texture != null)
            // {
            //     dialogChatNode.avatarSprite = Sprite.Create(this.Texture, new Rect(0, 0, this.Texture.width, this.Texture.height), Vector2.zero);
            // }
            base.Trigger(dialogTree);
            DialogChatNode chatNode = new DialogChatNode(this.NodeId, this.Input, this.Output);

            chatNode.dialogId = this.DialogId;
            chatNode.name = this.Name;
            if (this.Sprite != null)
            {
                string path = AssetDatabase.GetAssetPath(this.Sprite);
                path = path.Substring(0,path.LastIndexOf('.'));
                path = Regex.Replace(path, ".*Resources/", "");
                chatNode.avatarPath = path;
                //chatNode.avatarSprite = Sprite.Create(this.Texture, new Rect(0,0,this.Texture.width,this.Texture.height),Vector2.zero);
            }

            chatNode.content = this.Content;
            
            dialogTree.AddNode(chatNode);
            
            NodePort connection = this.GetOutputPort("Output").Connection;
            if (connection != null)
            {
                (connection.node as DialogBaseNode).Trigger(dialogTree);
            }
            
        }
        
        
    }
}