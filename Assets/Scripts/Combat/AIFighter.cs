using BananaForScale.Attributes;
using BananaForScale.Control;
using BananaForScale.Movement;
using UnityEngine;

namespace BananaForScale.Combat
{
    public class AIFighter : MonoBehaviour, IAction
    {
        #region Fields and Properties
        [SerializeField] private float _timeBetweenAttacks = 1f;
        private float _timeSinceLastAttack = Mathf.Infinity;
        private Animator _animator;
        private AIMover _mover;
        private Health _target;
        [SerializeField] private float AttackRange = 2f;
        [SerializeField] private float HitDamage = 2f;
        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _mover = GetComponent<AIMover>();
        }

        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;

            if (!_target || _target.IsDead) return;

            if (GetIsInAttackRange(_target.transform))
            {
                _mover.Cancel();
                AttackBehaviour();
            }
            else
            {
                _mover.MoveTo(_target.transform.position);
            }
        }

        private bool GetIsInAttackRange(Transform target) =>
            Vector3.Distance(transform.position, target.position) < AttackRange;

        private void AttackBehaviour()
        {
            transform.LookAt(_target.transform);

            if (_timeSinceLastAttack > _timeBetweenAttacks)
            {
                Hit();
                //TriggerAttack();
                _timeSinceLastAttack = 0;
            }
        }

        private void Hit()
        {
            // TODO: PLAY SOUND

            print("TakeDamage");
            _target.TakeDamage(HitDamage);
        }

        //private void TriggerAttack()
        //{
        //    const string TriggerName1 = "StopAttack";
        //    _animator.ResetTrigger(TriggerName1);

        //    const string TriggerName2 = "Attack";
        //    _animator.SetTrigger(TriggerName2);
        //}

        public bool CanAttack(GameObject combatTarget)
        {
            if (!combatTarget ||
                (!_mover.CanMoveTo(combatTarget.transform.position) &&
                !GetIsInAttackRange(combatTarget.transform)))
                return false;

            var target = combatTarget.GetComponent<Health>();
            return target && !target.IsDead;
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            //StopAttack();
            _target = null;
            _mover.Cancel();
        }

        //private void StopAttack()
        //{
        //    const string TriggerName1 = "Attack";
        //    _animator.ResetTrigger(TriggerName1);

        //    const string TriggerName2 = "StopAttack";
        //    _animator.SetTrigger(TriggerName2);
        //}
    }
}
