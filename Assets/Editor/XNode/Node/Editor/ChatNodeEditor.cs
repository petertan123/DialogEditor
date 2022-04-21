using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace ET
{
    [CustomNodeEditor(typeof(ChatNode))]
    public class ChatNodeEditor:NodeEditor
    {
        public override void OnHeaderGUI()
        {
            //base.OnHeaderGUI();

            GUI.color = Color.white;
            ChatNode node = target as ChatNode;
            

            GUIStyle style = new GUIStyle(NodeEditorResources.styles.nodeHeader);
            style.normal.textColor = Color.green;
            string title = this.target.name;
            GUILayout.Label(title,style,GUILayout.Height(30));
        }

        public override void OnBodyGUI()
        {
            this.serializedObject.Update();
            ChatNode node = target as ChatNode;

            // GUILayout.BeginVertical();
            // //MARKER：点击传输的enter和exit按钮
            // NodeEditorGUILayout.PortField(new GUIContent("enter"),this.target.GetInputPort("enter"),GUILayout.MinWidth(0));
            // NodeEditorGUILayout.PortField(new GUIContent("exit"),this.target.GetOutputPort("exit"),GUILayout.MinWidth(0));
            // GUILayout.EndVertical();
            

            //MARKER:绘制node界面
            node.NodeId = EditorGUILayout.LongField("NodeId", node.NodeId);
            node.DialogId = EditorGUILayout.IntField("DialogId", node.DialogId);
            node.Name = EditorGUILayout.TextField("Name", node.Name);
            //MARKER:绘制对应的Object来展示和接收贴图
            node.Sprite = EditorGUILayout.ObjectField("贴图",node.Sprite,typeof(Sprite),true) as Sprite; 
            //MARKER:显示Label和对应content的textArea
            EditorGUILayout.LabelField("Content");
            GUILayout.Space(-30);
            //MARKER:绘制Input,Output
            GUILayout.BeginHorizontal();
            NodeEditorGUILayout.PortField(GUIContent.none,this.target.GetInputPort("Input"),GUILayout.MinWidth(0));
            NodeEditorGUILayout.PortField(GUIContent.none,this.target.GetOutputPort("Output"),GUILayout.MinWidth(0));
            GUILayout.EndHorizontal();
            NodeEditorGUILayout.PropertyField(this.serializedObject.FindProperty("Content"), GUIContent.none);

            this.serializedObject.ApplyModifiedProperties();

        }
        
    }
}