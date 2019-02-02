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

    public class AiNode : MonoBehaviour
    {
        private NodeType type;
        private Dictionary<NodeType, System.Action> activationFunctions;
    }
}
