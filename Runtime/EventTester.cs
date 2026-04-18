using System;
using UnityEngine;

namespace BilliotGames
{
    public class EventTester : MonoBehaviour
    {
#if UNITY_EDITOR
        public enum ParameterType {
            Int,
            String,
        }

        [SerializeField] string testEventKey;
        [SerializeField] ParameterType parameterType;
        [SerializeField] int testInt;
        [SerializeField] string testString;
        private EventBus bus = new EventBus();

        public void InvokeEvent() {
            switch (parameterType) {
                case ParameterType.Int:
                    bus.Invoke(testEventKey, testInt);
                    break;
                case ParameterType.String:
                    bus.Invoke(testEventKey, testString);
                    break;
                default:
                    break;
            }
        }

        public void RegisterNewEvent() {
            switch (parameterType) {
                case ParameterType.Int:
                    bus.RegisterEvent<int>(testEventKey, (number) => {
                        Debug.Log($"event key?<color=cyan>{testEventKey}</color> invoked. number? <color=yellow>{number}</color>");
                    });
                    break;
                case ParameterType.String:
                    bus.RegisterEvent<string>(testEventKey, (log) => {
                        Debug.Log($"event key?<color=cyan>{testEventKey}</color> invoked. message? <color=yellow>{log}</color>");
                    });
                    break;
                default:
                    break;
            }
        }
#endif
    }
}
