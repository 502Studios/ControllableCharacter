namespace net.fiveotwo.controllableCharacter
{
    using UnityEngine;

    public class CharacterAim : CharacterAction
    {
        [SerializeField]
        protected AimType aimType;
        [SerializeField]
        protected AimAxis aimAxis;
        [SerializeField]
        protected Direction defaultDirection;
        [SerializeField]
        protected bool canAimBelownWhileGrounded = true;
        private Vector2 currentAimingDirection;
        private Vector2 newDirection;
        private Vector2 previousDirection;
        protected ControllerInputModule input;

        /*
            E = 0, 
            NE = 1,
            N = 2, 
            NW = 3,
            W = 4, 
            SW = 5,
            S = 6, 
            SE = 7
        */

        readonly Vector2 upRight = new Vector2(1,1);
        readonly Vector2 upLeft = new Vector2(-1, 1);
        readonly Vector2 downRight = new Vector2(1, -1);
        readonly Vector2 downLeft = new Vector2(-1, -1);

        readonly Vector2[] filter8WayDirections = new Vector2[] {
            Vector2.right,
            new Vector2(1,1),
            Vector2.up,
            new Vector2(-1,1),
            Vector2.left,
            new Vector2(-1, -1),
            Vector2.down,
            new Vector2(1, -1)
        };

        readonly Vector2[] filter4WayDirections = new Vector2[] {
            Vector2.right,
            Vector2.up,
            Vector2.left,
            Vector2.down,
        };

        protected enum AimType
        {
            TwoWay,
            FourWay,
            EightWay
        }

        protected enum AimAxis
        {
            MoveAxis,
            AimAxis
        }

        protected enum Direction
        {
            Left,
            Right
        }

        public override void Initialization()
        {
            input = controllableCharacter.InputModule();
            currentAimingDirection = previousDirection = defaultDirection == Direction.Left ? Vector2.left : Vector2.right;
        }

        public override void UpdateAction()
        {
            if (!active)
            {
                return;
            }

            newDirection = aimAxis == AimAxis.AimAxis ? input.rightStick.Value() : input.leftStick.Value();

            if (newDirection != currentAimingDirection && newDirection != Vector2.zero)
            {
                CalculateNewAimingAngle(newDirection);
            }

            if (!canAimBelownWhileGrounded && controllableCharacter.CharacterStateMachine().Equals((int)CharacterState.grounded))
            {
                currentAimingDirection = previousDirection;
            }

            Debug.DrawRay(transform.position, currentAimingDirection * 2f, Color.yellow);
        }

        void CalculateNewAimingAngle(Vector2 direction)
        {
            switch (aimType)
            {
                case AimType.TwoWay:
                    currentAimingDirection = direction.x > 0 ? Vector2.right : Vector2.left;
                    break;
                case AimType.FourWay:
                    currentAimingDirection = Snap(direction, filter4WayDirections);
                    break;
                case AimType.EightWay:
                    currentAimingDirection = Snap(direction, filter8WayDirections);
                    break;
                default:
                    break;
            }
        }

        Vector2 Snap(Vector3 vector, Vector2[] directions)
        {
            int count = directions.Length;
            float angle = Mathf.Atan2(vector.y, vector.x);
            int octant = (int) Mathf.Round(count * angle / (2 * Mathf.PI) + count) % count;
            Vector2 newDirection = directions[octant];

            if (newDirection.y > -1)
            {
                previousDirection = newDirection;
            }

            return newDirection;
        }

        public Vector2 AimingDirection()
        {
            return currentAimingDirection;
        }
    }
}