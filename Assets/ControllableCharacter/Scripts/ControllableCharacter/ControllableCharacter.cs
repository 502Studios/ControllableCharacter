using net.fiveotwo.characterController;
using System.Collections.Generic;
using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    [RequireComponent(typeof(Controller2D))]
    public class ControllableCharacter : MonoBehaviour
    {
        [SerializeField]
        private bool _useUnescaledDeltaTime;
        protected float deltaTimeModifier = 1f;
        private List<CharacterAction> _characterActions = new List<CharacterAction>();
        private Controller2D _characterController2D;
        private Vector2 _velocity;
        private ControllerInputModule _controllerInputModule;
        private CharacterStateMachine _characterStateMachine;
        private bool _haltController;
        private float _currentDelta;

        public void Awake()
        {
            _characterController2D = GetComponent<Controller2D>();
            _characterStateMachine = new CharacterStateMachine();
        }

        private void Start()
        {
            InitializeStates();
        }

        void Update()
        {
            if (_haltController)
            {
                return;
            }

            for (int index = 0; index < _characterActions.Count; index++)
            {
                CharacterAction action = _characterActions[index];
                if (action.Active())
                {
                    action.EarlyUpdateAction(DeltaTime());
                }
            }

            for (int index = 0; index < _characterActions.Count; index++)
            {
                CharacterAction action = _characterActions[index];
                if (action.Active())
                {
                    action.UpdateAction(DeltaTime());
                }
            }

            for (int index = 0; index < _characterActions.Count; index++)
            {
                CharacterAction action = _characterActions[index];
                if (action.Active())
                {
                    action.LateUpdateAction(DeltaTime());
                }
            }

            Move(_velocity);

            for (int index = 0; index < _characterActions.Count; index++)
            {
                CharacterAction action = _characterActions[index];
                if (action.Active())
                {
                    action.AfterUpdateAction(DeltaTime());
                }
            }
        }

        public void InitializeStates()
        {
            for(int index = 0; index < _characterActions.Count; index++)
            {
                _characterActions[index].Initialization();
            }
        }

        public bool IsGrounded()
        {
            return _characterController2D.CollisionState().Below;
        }

        public CollisionState GetCollisionState()
        {
            return _characterController2D.CollisionState();
        }

        public Vector2 GetVelocity()
        {
            return _velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        public void Move(Vector3 deltaMovement)
        {
            _characterController2D.Move(deltaMovement * DeltaTime());
        }

        public Controller2D CharacterController2D()
        {
            return _characterController2D;
        }

        public void AddAction(CharacterAction action)
        {
            _characterActions.Add(action);
            _characterActions.Sort((x, y) => x.priority.CompareTo(y.priority));
        }

        public void RemoveAction(CharacterAction action)
        {
            _characterActions.Remove(action);
        }

        public void ResetActions()
        {
            for (int index = 0; index < _characterActions.Count; index++)
            {
                _characterActions[index].ResetAction();
            }
        }

        public void SetInputModule(ControllerInputModule controllerInputModule)
        {
            _controllerInputModule = controllerInputModule;
        }

        public ControllerInputModule GetInputModule()
        {
            return _controllerInputModule;
        }

        public void ModifyDeltaTime(float deltaTimeModifier)
        {
            this.deltaTimeModifier = deltaTimeModifier;
        }

        public float DeltaTime()
        {
            _currentDelta = _useUnescaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
            return _currentDelta * deltaTimeModifier;
        }

        public void SetUnscaledDeltaTime(bool value)
        { 
            _useUnescaledDeltaTime = value;
        }

        public CharacterStateMachine GetStateMachine()
        {
            return _characterStateMachine;
        }

        public void HaltController(bool value)
        {
            _haltController = value;
        }

        #region collision events
        public void AddOnControllerCollidedEvent(Controller2D.CollisionEvent action)
        {
            _characterController2D.onCollisionEvent += action;
        }

        public void RemoveOnControllerCollidedEvent(Controller2D.CollisionEvent action)
        {
            _characterController2D.onCollisionEvent -= action;
        }

        public void AddOnControllerTriggerEnterEvent(Controller2D.TriggerEvent action)
        {
            _characterController2D.onTriggerEnter += action;
        }

        public void RemoveOnControllerTriggerEnterEvent(Controller2D.TriggerEvent action)
        {
            _characterController2D.onTriggerEnter -= action;
        }

        public void AddOnControllerTriggerExitEvent(Controller2D.TriggerEvent action)
        {
            _characterController2D.onTriggerExit += action;
        }

        public void RemoveOnControllerTriggerExitEvent(Controller2D.TriggerEvent action)
        {
            _characterController2D.onTriggerExit -= action;
        }
        #endregion
    }
}