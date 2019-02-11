using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Otumn.Ai
{
    public class NodeNetwork : MonoBehaviour
    {
        [SerializeField] private TimersCalculator timers;
        [SerializeField] private List<AiNode> nodes;
        [SerializeField] private List<AiNode> inputNodes;
        [SerializeField] private List<AiNode> conditionsNodes;
        [SerializeField] private List<AiNode> outputNodes;
        int timer;
        bool stopped = false;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                timer = timers.LaunchNewTimer(5, DebugTest);
                Debug.Log("Timer launched");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                stopped = !stopped;
                timers.StopTimer(timer, stopped);
            }
        }

        private void DebugTest()
        {
            Debug.Log("Timer done");
        }

        public List<AiNode> Nodes { get => nodes; set => nodes = value; }
        public List<AiNode> InputNodes { get => inputNodes; set => inputNodes = value; }
        public List<AiNode> ConditionsNodes { get => conditionsNodes; set => conditionsNodes = value; }
        public List<AiNode> OutputNodes { get => outputNodes; set => outputNodes = value; }
    }
}
