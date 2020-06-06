using net.fiveotwo.characterController;
using System.Collections.Generic;
using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    [RequireComponent(typeof(Controller2D))]
    public class ControllableCharacter : MonoBehaviour
    {
        private List<CharacterAction> characterActions = new List<CharacterAction>();
        private Controller2D characterController2D;
        private Vector2 velocity;
        private ControllerInputModule controllerInputModule;
        private CharacterStateMachine characterStateMachine;

        protected float deltaTimeModifier = 1f;

        public void Awake()
        {
            characterController2D = GetComponent<Controller2D>();
            characterStateMachine = new CharacterStateMachine();
        }

        private void Start()
        {
            InitializeStates();
        }

        void Update()
        {
            foreach (CharacterAction action in characterActions)
            {
                if (action.Active())
                {
                    action.EarlyUpdateAction();
                }
            }
            foreach (CharacterAction action in characterActions)
            {
                if (action.Active())
                {
                    action.UpdateAction();
                }
            }
            foreach (CharacterAction action in characterActions)
            {
                if (action.Active())
                {
                    action.LateUpdateAction();
                }
            }

            Move(velocity);

            foreach (CharacterAction action in characterActions)
            {
                if (action.Active())
                {
                    action.AfterUpdateAction();
                }
            }
        }

        public void InitializeStates()
        {
            foreach (CharacterAction action in characterActions)
            {
                action.Initialization();
            }
        }

        public bool IsGrounded()
        {
            return characterController2D.CollisionState().Below;
        }

        public CollisionState GetCollisionState()
        {
            return characterController2D.CollisionState();
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public void Move(Vector3 deltaMovement)
        {
            characterController2D.Move(deltaMovement * DeltaTime());
        }

        public Controller2D CharacterController2D()
        {
            return characterController2D;
        }

        public void AddAction(CharacterAction action)
        {
            characterActions.Add(action);
            characterActions.Sort((x, y) => x.priority.CompareTo(y.priority));
        }

        public void RemoveAction(CharacterAction action)
        {
            characterActions.Remove(action);
        }

        public void SetInputModule(ControllerInputModule controllerInputModule)
        {
            this.controllerInputModule = controllerInputModule;
        }

        public ControllerInputModule GetInputModule()
        {
            return controllerInputModule;
        }

        public void ModifyDeltaTime(float deltaTimeModifier)
        {
            this.deltaTimeModifier = deltaTimeModifier;
        }

        public float DeltaTime()
        {
            return Time.deltaTime * deltaTimeModifier;
        }

        public CharacterStateMachine GetStateMachine() {
            return characterStateMachine;
        }

        #region collision events
        public void AddOnControllerCollidedEvent(Controller2D.CollisionEvent action)
        {
            characterController2D.onCollisionEvent += action;
        }

        public void RemoveOnControllerCollidedEvent(Controller2D.CollisionEvent action)
        {
            characterController2D.onCollisionEvent -= action;
        }

        public void AddOnControllerTriggerEnterEvent(Controller2D.TriggerEvent action)
        {
            characterController2D.onTriggerEnter += action;
        }

        public void RemoveOnControllerTriggerEnterEvent(Controller2D.TriggerEvent action)
        {
            characterController2D.onTriggerEnter -= action;
        }

        public void AddOnControllerTriggerExitEvent(Controller2D.TriggerEvent action)
        {
            characterController2D.onTriggerExit += action;
        }

        public void RemoveOnControllerTriggerExitEvent(Controller2D.TriggerEvent action)
        {
            characterController2D.onTriggerExit -= action;
        }
        #endregion
    }
}