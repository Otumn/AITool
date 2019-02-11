using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Otumn.Ai
{
    public enum ConnectionPointType { In, Out }

    public class ConnectionPoint
    {
        private Rect rect;

        private ConnectionPointType type;

        private NeuronNode neuron;

        private GUIStyle style;

        private Action<ConnectionPoint> onClickConnectionPoint;

        public ConnectionPoint(NeuronNode node, ConnectionPointType type, GUIStyle style, Action<ConnectionPoint> OnClickConnectionPoint)
        {
            this.neuron = node;
            this.type = type;
            this.style = style;
            this.onClickConnectionPoint = OnClickConnectionPoint;
            rect = new Rect(0, 0, 10, 10);
        }

        public void Draw()
        {
            rect.y = neuron.Rect.y + (neuron.Rect.height * 0.5f) - rect.height * 0.5f;

            switch (type)
            {
                case ConnectionPointType.In:
                    rect.x = neuron.Rect.x - rect.width + 8f;
                    break;
                case ConnectionPointType.Out:
                    rect.x = neuron.Rect.x + neuron.Rect.width - 8f;
                    break;
            }

            if (GUI.Button(rect, "", style))
            {
                if (onClickConnectionPoint != null)
                {
                    onClickConnectionPoint(this);
                }
            }
        }

        public Rect Rect { get => rect; set => rect = value; }
        public ConnectionPointType Type { get => type; set => type = value; }
        public NeuronNode Neuron { get => neuron; set => neuron = value; }
        public GUIStyle Style { get => style; set => style = value; }
        public Action<ConnectionPoint> OnClickConnectionPoint1 { get => onClickConnectionPoint; set => onClickConnectionPoint = value; }
    }
}
