using UnityEngine;
using System.Collections.Generic;

namespace net.fiveotwo.controllableCharacter
{
    [RequireComponent(typeof(ControllableCharacter))]
    public abstract class ControllerInputModule : MonoBehaviour
    {
        private Dictionary<string, Axis2D> analogAxis2D = new Dictionary<string, Axis2D>();
        private Dictionary<string, Axis> analogAxis = new Dictionary<string, Axis>();
        private Dictionary<string, Button> buttons = new Dictionary<string, Button>();

        private void Awake()
        {
            GetComponent<ControllableCharacter>().SetInputModule(this);
            ConfigureInputs();
        }

        public abstract void ConfigureInputs();

        public void AddInput(string inputName, Axis2D axis2D) {
            analogAxis2D.Add(inputName, axis2D);
        }

        public void AddInput(string inputName, Axis axis)
        {
            analogAxis.Add(inputName, axis);
        }

        public void AddInput(string inputName, Button button)
        {
            buttons.Add(inputName, button);
        }

        public Axis2D Get2DAxis(string inputName) {
            if (analogAxis2D.TryGetValue(inputName, out Axis2D input))
            {
                return input;
            }
            throw new UnityException($"Input {inputName} not registered");
        }

        public Axis GetAxis(string inputName)
        {
            if (analogAxis.TryGetValue(inputName, out Axis input))
            {
                return input;
            }
            throw new UnityException($"Input {inputName} not registered");
        }

        public Button GetButton(string inputName)
        {
            if (buttons.TryGetValue(inputName, out Button input))
            {
                return input;
            }
            throw new UnityException($"Input {inputName} not registered");
        }
    }
}