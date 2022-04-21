using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace ET
{
    [CustomNodeEditor(typeof(BranchNode))]
    public class BranchNodeEditor:NodeEditor
    {
        public override void OnHeaderGUI()
        {
            
            GUI.color = Color.white;
            
            string title = this.target.name;
            GUIStyle style = new GUIStyle(NodeEditorResources.styles.nodeHeader);
            style.normal.textColor = Color.cyan;
            
            GUILayout.Label(title,style,GUILayout.Height(30));
        }

        public override void OnBodyGUI()
        {
            this.serializedObject.Update();
            
            BranchNode node = this.target as BranchNode;
            
            node.NodeId = EditorGUILayout.LongField("NodeId", node.NodeId);
            
            NodeEditorGUILayout.PortField(GUIContent.none,this.target.GetInputPort("Input"));
            
            //MARKER:绘制Answers
            NodeEditorGUILayout.DynamicPortList("Answers",typeof(DialogBaseNode),this.serializedObject,NodePort.IO.Output,Node.ConnectionType.Override);

            this.serializedObject.ApplyModifiedProperties();
        }

        public override int GetWidth()
        {
            return 300;
        }
    }
}