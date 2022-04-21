using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace ET
{
    [NodeGraphEditor.CustomNodeGraphEditorAttribute(typeof(DialogGraph))]
    public class DialogGraphEditor:NodeGraphEditor
    {
        public override void OnGUI()
        {
            base.OnGUI();
            GUILayout.BeginArea(new Rect(this.window.position.width - 100,0,100,60));
            if(GUILayout.Button("导出",GUILayout.MinHeight(30)))
            {
                this.OutputTree();
            }

            if (GUILayout.Button("清空", GUILayout.MinHeight(30)))
            {
                DialogGraph graph = this.target as DialogGraph;
                graph.Clear();
            }
            GUILayout.EndArea();
        }
        
        private void OutputTree()
        {
            DialogGraph graph = this.target as DialogGraph;
            DialogTree dialogTree = graph.OutputTree();

            if (dialogTree != null)
            {
                //MARKER:存储dialogTree
                dialogTree.SaveAsJson(graph.name);
            }
        }
    }
}