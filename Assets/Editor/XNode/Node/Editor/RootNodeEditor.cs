using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace ET
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(RootNode))]
    public class RootNodeEditor:NodeEditor
    {
        public override void OnHeaderGUI()
        {
            GUI.color = Color.white;
            ChatNode node = target as ChatNode;
        
            string title = this.target.name;
            GUILayout.Label(title,NodeEditorResources.styles.nodeHeader,GUILayout.Height(30));
        }

        public override void OnBodyGUI()
        {
            this.serializedObject.Update();
            RootNode node = this.target as RootNode;
            EditorGUILayout.LabelField("NodeId: ",$"{node.NodeId}");
            
            NodeEditorGUILayout.PortField(GUIContent.none,this.target.GetOutputPort("Output"),GUILayout.MinWidth(0));

            this.serializedObject.ApplyModifiedProperties();
        }
    }
}