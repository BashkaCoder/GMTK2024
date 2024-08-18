using BananaForScale.Control;
using UnityEngine;
using UnityEngine.AI;
namespace BananaForScale.Movement
{
    public class AIMover : MonoBehaviour, IAction
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _maxSpeed = 6f;
        private NavMeshAgent _navMeshAgent;
        //private Animator _animator;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            //_animator = GetComponent<Animator>();
        }

        private void Update()
        {
            //_navMeshAgent.enabled = !_health.IsDead;
            //UpdateAnimator();
        }

        //private void UpdateAnimator()
        //{
        //    //Vector3 velocity = _navMeshAgent.velocity;
        //    //Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        //    //float speed = localVelocity.z;

        //    //const string ForwardSpeed = "ForwardSpeed";
        //    //_animator.SetFloat(ForwardSpeed, speed);
        //}

        public void StartMoveAction(Vector3 destination, float speedFraction = 1f)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction);
        }

        public bool CanMoveTo(Vector3 destination)
        {
            var path = new NavMeshPath();
            bool hasPath = NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path);
            if (!hasPath) return false;

            if (path.status != NavMeshPathStatus.PathComplete) return false;

            return true;
        }

        public void MoveTo(Vector3 destination, float speedFraction = 1f)
        {
            _navMeshAgent.destination = destination;
            _navMeshAgent.speed = _maxSpeed * Mathf.Clamp01(speedFraction);
            _navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}
