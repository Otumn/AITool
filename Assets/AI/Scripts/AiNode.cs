using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Otumn.Ai
{
    public enum NodeType
    {
        Input,
        Condition,
        Output
    };

    public enum InputType
    {
        Float,
        Int,
        String
    }

    [Serializable]
    public struct AiNode
    {
        [SerializeField] private string name;
        [SerializeField] private NodeType type;
        [SerializeField] private float weight;
        [SerializeField] private float threshhold;
        //input parameters
        private Action<float> floatInput;
        private Action<int> intInput;
        private Action<String> stringInput;
        //conditon parameters
        private Action<bool> condition;
        //output parameters
        private Action output;

        /*
         * input needs a world state to send a condition
         * condition needs a bool condition
         * output needs an Action
         */

        public NodeType Type { get => type; set => type = value; }
    }
}
