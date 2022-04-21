using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using XNode;

namespace ET
{
    [CreateNodeMenu("EventNode")]
    public class EventNode:DialogBaseNode
    {
        public DialogEventType EventType;
        
        [Header("Normal Type")]
        public string EventName; //当前需要触发的事件名

        [Header("Init Type")]
        public GameObject Prefab;
        public Vector3 InitPoint;
        public InitType InitType;
        public DoorType DoorType;
        public bool CameraChase;
        //public bool IsEndGame;
        public string TargetScene;


        public override void Trigger(DialogTree dialogTree)
        {
            base.Trigger(dialogTree);
            DialogEventNode eventNode = new DialogEventNode(this.NodeId, this.Input, this.Output);

            
            eventNode.eventType = this.EventType;
            //eventNode.gameObject = this.Prefab;

            switch (this.EventType)
            {
                case DialogEventType.Normal:
                    eventNode.eventName = this.EventName;
                    break;
                case DialogEventType.Init:
                    if (this.Prefab != null)
                    {
                        string goPath = AssetDatabase.GetAssetPath(this.Prefab);
                        goPath = goPath.Substring(0, goPath.LastIndexOf('.'));
                        goPath = Regex.Replace(goPath, ".*Resources/", "");
                        eventNode.goPath = goPath;
                    }
                    eventNode.initPoint = new InitPos(this.InitPoint.x.ToString(),this.InitPoint.y.ToString(),this.InitPoint.z.ToString());
                    eventNode.initType = this.InitType;
                    eventNode.cameraChase = this.CameraChase;
                    //eventNode.isEndGame = this.IsEndGame;
                    eventNode.doorType = this.DoorType;
                    eventNode.targetScene = this.TargetScene;
                    break;
            }
          
            
            
            dialogTree.AddNode(eventNode);
            
            NodePort connection = this.GetOutputPort("Output").Connection;
            if (connection != null)
            {
                (connection.node as DialogBaseNode).Trigger(dialogTree);
            }
            
        }
        
    }
}