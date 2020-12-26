using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    [RequireComponent(typeof(ControllableCharacter))]
    public abstract class CharacterAction : MonoBehaviour
    {
        [SerializeField]
        public int priority = 0;
        [SerializeField]
        protected bool active;
        protected ControllableCharacter controllableCharacter;

        public virtual void Awake()
        {
            controllableCharacter = GetComponent<ControllableCharacter>();
            controllableCharacter.AddAction(this);
        }

        public virtual void Initialization()
        {
        }

        public virtual void EarlyUpdateAction(float deltaTime)
        {
        }

        public virtual void LateUpdateAction(float deltaTime)
        {
        }

        public virtual void UpdateAction(float deltaTime)
        {
        }

        public virtual void AfterUpdateAction(float deltaTime)
        {
        }

        public bool Active()
        {
            return active;
        }
    }
}