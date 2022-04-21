using System;
using System.Collections.Generic;

namespace ET
{
    [Serializable]
    public class Answer
    {
        public string text;
        public string musicName;

        public long nextNodeId;
    }
    
    [Serializable]
    public class DialogBranchNode:BaseDialogNode
    {

        public List<Answer> answers = new List<Answer>();
        
        public void AddAnswer(string _text, string _musicName, long _nextNodeId)
        {
            Answer answer = new Answer();
            answer.text = _text;
            answer.musicName = _musicName;
            answer.nextNodeId = _nextNodeId;

            this.answers.Add(answer);
        }

        public DialogBranchNode()
        {
            
        }

        public DialogBranchNode(long _nodeId, List<long> _previousNodeIds, long _nextNodeId):base(_nodeId, _previousNodeIds, _nextNodeId)
        {
            this.type = DialogNodeType.Branch;
        }
        
    }
}