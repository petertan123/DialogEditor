using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace ET
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(EventNode))]
    public class EventNodeEditor:NodeEditor
    {
        public override void OnHeaderGUI()
        {
            GUI.color = Color.white;

            string title = this.target.name;
            GUIStyle style = new GUIStyle(NodeEditorResources.styles.nodeHeader);
            style.normal.textColor = Color.yellow;
            
            GUILayout.Label(title,style,GUILayout.Height(30));

        }

        public override void OnBodyGUI()
        {
            this.serializedObject.Update(); //更新属性
            EventNode node = this.target as EventNode;

            node.NodeId = EditorGUILayout.LongField("NodeId", node.NodeId);
            
            NodeEditorGUILayout.PortField(GUIContent.none, this.target.GetInputPort("Input"));
            NodeEditorGUILayout.PortField(GUIContent.none,this.target.GetOutputPort("Output"));

            //事件类型选择
            EditorGUILayout.LabelField("EventType");
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("EventType"), GUIContent.none);
            
            //根据类型绘制
            switch (node.EventType)
            {
                case DialogEventType.Normal:
                    node.EventName = EditorGUILayout.TextField("EventName", node.EventName);
                    break;
                case DialogEventType.Init:
                    node.Prefab = EditorGUILayout.ObjectField("Prefab",node.Prefab,typeof(GameObject),false) as GameObject;
                    node.InitPoint = EditorGUILayout.Vector3Field("InitPoint", node.InitPoint);
                    EditorGUILayout.LabelField("InitType");
                    EditorGUILayout.PropertyField(this.serializedObject.FindProperty("InitType"), GUIContent.none);
                    switch (node.InitType)
                    {
                        case InitType.Normal:
                            break;
                        case InitType.Door:
                            node.CameraChase = EditorGUILayout.Toggle("CameraChase", node.CameraChase);
                            //node.IsEndGame = EditorGUILayout.Toggle("IsEndGame", node.IsEndGame);
                            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("DoorType"), GUIContent.none);
                            node.TargetScene = EditorGUILayout.TextField("TargetScene", node.TargetScene);
                            break;
                    }
                    
                    break;
            }

            this.serializedObject.ApplyModifiedProperties(); //应用属性更新
        }
    }
    
    
}