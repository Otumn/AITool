﻿using System;
using UnityEngine;
using UnityEditor;

namespace Otumn.Ai
{
    public class Connection
    {
        private ConnectionPoint inPoint;
        private ConnectionPoint outPoint;
        private Action<Connection> OnClickRemoveConnection;

        public Connection (ConnectionPoint inPoint, ConnectionPoint outPoint, Action<Connection> OnClickRemoveConnection)
        {
            this.inPoint = inPoint;
            this.outPoint = outPoint;
            this.OnClickRemoveConnection = OnClickRemoveConnection;
        }

        public void Draw()
        {
            Handles.DrawBezier(
                inPoint.Rect.center,
                outPoint.Rect.center,
                inPoint.Rect.center + Vector2.left * 50f,
                outPoint.Rect.center - Vector2.left * 50f,
                Color.white,
                null,
                2f
            );

            if(Handles.Button((inPoint.Rect.center + outPoint.Rect.center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleHandleCap))
            {
                if(OnClickRemoveConnection != null)
                {
                    OnClickRemoveConnection(this);
                }
            }
        }

        public ConnectionPoint InPoint { get => inPoint; set => inPoint = value; }
        public ConnectionPoint OutPoint { get => outPoint; set => outPoint = value; }
    }
}
