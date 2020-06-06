using net.fiveotwo.controllableCharacter;
using UnityEngine;

namespace net.fiveotwo.demo.controllableCharacter
{
    public class CharacterGravity : CharacterAction
    {
        [SerializeField]
        protected float gravity;
        protected Vector2 velocity;

        public override void EarlyUpdateAction()
        {
            velocity = controllableCharacter.GetVelocity();
            velocity.y -= gravity * controllableCharacter.DeltaTime();
            controllableCharacter.SetVelocity(velocity);
        }
    }
}