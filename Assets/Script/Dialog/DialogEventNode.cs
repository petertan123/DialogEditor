using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public enum DoorType
    {
        SwitchScene,
        EndGame,
        EnterGame,
    }
    
    [Serializable]
    public class InitPos
    {
        public string posX;
        public string posY;
        public string posZ;

        public InitPos()
        {
            
        }

        public InitPos(string _posX, string _posY, string _posZ)
        {
            this.posX = _posX;
            this.posY = _posY;
            this.posZ = _posZ;
        }
    }
    
    public enum DialogEventType
    {
        Normal, //通用事件
        Init, //在某个坐标点生成物体
    }

    public enum InitType
    {
        Normal, //通用类型
        Door, //用于传输场景的门
    }
    public class DialogEventNode:BaseDialogNode
    {
        public DialogEventType eventType;

        public string EventType
        {
            set
            {
                this.eventType = (DialogEventType)System.Enum.Parse(typeof (DialogEventType), value);
            }
        }
        
        //Normal类型
        public string eventName;
        
        //Init类型
        //public string gameObject;
        public string goPath;
        public InitPos initPoint;
        public InitType initType;
        public DoorType doorType;
        public bool cameraChase;
        //public bool isEndGame;
        public string targetScene;

        public string InitType
        {
            set
            {
                this.initType = (InitType)System.Enum.Parse(typeof (InitType), value);
            }
        }
        

        public DialogEventNode()
        {
            
        }

        public DialogEventNode(long _nodeId, List<long> _previousNodeIds, long _nextNodeId): base(_nodeId, _previousNodeIds,
            _nextNodeId)
        {
            this.type = DialogNodeType.Event;
        }
        
    }
}