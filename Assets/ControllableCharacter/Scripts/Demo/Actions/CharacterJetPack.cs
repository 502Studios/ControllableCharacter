namespace net.fiveotwo.controllableCharacter
{
    using UnityEngine;

    public class CharacterJetPack : CharacterAction
    {
        [SerializeField]
        protected float fuel;
        [SerializeField]
        protected float fuelDepletionRate;
        [SerializeField]
        protected float fuelRefillRate;
        [SerializeField]
        protected int gravity;
        [SerializeField]
        protected float jetpackImpulse;
        protected Vector2 velocity;
        protected float currentFuel;
        protected ControllerInputModule input;
        protected CharacterJump characterJump;

        public override void Awake()
        {
            base.Awake();
            characterJump = GetComponent<CharacterJump>();
        }

        public override void Initialization()
        {
            input = controllableCharacter.InputModule();
            currentFuel = fuel;
        }

        public override void UpdateAction()
        {
            if (!active)
            {
                return;
            }

            if (controllableCharacter.IsGrounded())
            {
                float deltaTime = controllableCharacter.DeltaTime();
                currentFuel = Mathf.MoveTowards(currentFuel, fuel, deltaTime * fuelRefillRate);
                return;
            }

            bool jetpackActivable = characterJump != null && characterJump.Active() ? !characterJump.CanJump() : true;
            if (input.action2.IsPressed() && jetpackActivable && currentFuel > 0)
            {
                JetPack();
                float deltaTime = controllableCharacter.DeltaTime();
                currentFuel = Mathf.MoveTowards(currentFuel, 0, deltaTime * fuelDepletionRate);
            }
        }

        void JetPack()
        {
            velocity = controllableCharacter.GetVelocity();
            velocity.y = Mathf.Sqrt(2f * (jetpackImpulse) * gravity);
            controllableCharacter.SetVelocity(velocity);
        }
    }
}