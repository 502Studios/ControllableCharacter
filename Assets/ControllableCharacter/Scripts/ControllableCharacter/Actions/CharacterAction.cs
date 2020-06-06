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

        public virtual void EarlyUpdateAction()
        {
        }

        public virtual void LateUpdateAction()
        {
        }

        public virtual void UpdateAction()
        {
        }

        public virtual void AfterUpdateAction()
        {
        }

        public bool Active()
        {
            return active;
        }

        public void SetStatus(bool status)
        {
            active = status;
        }
    }
}