using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Otumn.Ai
{
    [CustomEditor(typeof(NodeNetwork))]
    [CanEditMultipleObjects]
    public class NodeNetworkEditor : Editor
    {
        private NodeNetwork NN { get => target as NodeNetwork; }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Sort"))
            {
                for (int i = 0; i < NN.Nodes.Count; i++)
                {
                    /*if(NN.Nodes[i].Type == NodeType.Input)
                    {
                        NN.InputNodes.Add()
                    }*/
                    switch(NN.Nodes[i].Type)
                    {
                        case NodeType.Input:
                            NN.InputNodes.Add(NN.Nodes[i]);
                            break;
                        case NodeType.Condition:
                            NN.ConditionsNodes.Add(NN.Nodes[i]);
                            break;
                        case NodeType.Output:
                            NN.OutputNodes.Add(NN.Nodes[i]);
                            break;
                    }
                }
            }
            if (GUILayout.Button("Clear"))
            {
                NN.InputNodes.Clear();
                NN.ConditionsNodes.Clear();
                NN.OutputNodes.Clear();
            }

            if (GUILayout.Button("Clear all"))
            {
                NN.Nodes.Clear();
                NN.InputNodes.Clear();
                NN.ConditionsNodes.Clear();
                NN.OutputNodes.Clear();
            }
        }
    }
}
