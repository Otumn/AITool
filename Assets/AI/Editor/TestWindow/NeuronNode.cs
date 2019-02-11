using System;
using UnityEngine;
using UnityEditor;

namespace Otumn.Ai
{
    public class NeuronNode
    {
        private Rect rect;
        private string title;
        private bool isDragged;
        private bool isSelected;

        private ConnectionPoint inPoint;
        private ConnectionPoint outPoint;

        private GUIStyle usedStyle;
        private GUIStyle defaultNodeStyle;
        private GUIStyle selectedNodeStyle;

        private Action<NeuronNode> OnRemoveNode;

        public NeuronNode(
            Vector2 position, 
            float diameter, 
            GUIStyle nodeStyle, 
            GUIStyle selectedStyle, 
            GUIStyle inPointStyle, 
            GUIStyle outPointStyle, 
            Action<ConnectionPoint> OnClickInPoint, 
            Action<ConnectionPoint> OnClickOutPoint,
            Action<NeuronNode> OnClickRemoveNode)
        {
            rect = new Rect(position.x, position.y, diameter, diameter);
            usedStyle = nodeStyle;
            inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint);
            outPoint = new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint);
            defaultNodeStyle = nodeStyle;
            selectedNodeStyle = selectedStyle;
            OnRemoveNode = OnClickRemoveNode;
        }

        public void Drag(Vector2 delta)
        {
            rect.position += delta;
        }

        public void Draw()
        {
            inPoint.Draw();
            outPoint.Draw();
            GUI.Box(rect, title, usedStyle);
        }

        public bool ProcessEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if(e.button == 0)
                    {
                        if(rect.Contains(e.mousePosition))
                        {
                            isDragged = true;
                            GUI.changed = true;
                            isSelected = true;
                            usedStyle = selectedNodeStyle;
                        }
                        else
                        {
                            GUI.changed = true;
                            isSelected = false;
                            usedStyle = defaultNodeStyle;
                        }
                    }

                    if(e.button == 1 && isSelected && rect.Contains(e.mousePosition))
                    {
                        ProcessContextMenu();
                        e.Use();
                    }
                    break;
                case EventType.MouseUp:
                    isDragged = false;
                    break;

                case EventType.MouseDrag:
                    if(e.button == 0 && isDragged)
                    {
                        Drag(e.delta);
                        e.Use();
                        return true;
                    }
                    break;
            }

            return false;
        }

        private void ProcessContextMenu()
        {
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Remove"), false, OnClickRemoveNode);
            genericMenu.ShowAsContext();
        }

        private void OnClickRemoveNode()
        {
            if(OnRemoveNode != null)
            {
                OnRemoveNode(this);
            }
        }

        public Rect Rect { get => rect; set => rect = value; }
        public string Title { get => title; set => title = value; }
        public GUIStyle Style { get => usedStyle; set => usedStyle = value; }
        public ConnectionPoint InPoint { get => inPoint; set => inPoint = value; }
        public ConnectionPoint OutPoint { get => outPoint; set => outPoint = value; }
        public GUIStyle DefaultNodeStyle { get => defaultNodeStyle; set => defaultNodeStyle = value; }
        public GUIStyle SelectedNodeStyle { get => selectedNodeStyle; set => selectedNodeStyle = value; }
    }
}
