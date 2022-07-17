using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private ColliderCheck _moveRange;
        [SerializeField] private ColliderCheck _attackRange;
        [SerializeField] private ColliderCheck _throwRange;
        [SerializeField] private bool _canThrow;
        [SerializeField] private GameObject _projectile;
        [SerializeField] private Transform _fireTransform;

        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _allarmDelay;
        [SerializeField] private float _throwCooldown;

        private bool _isDead;

        private GameObject _target;
        private Animator _animator;
        private Creature _creature;
        private IEnumerator _coroutine;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _creature = GetComponent<Creature>();
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        public void OnHeroInVision(GameObject go)
        {
            if (_isDead) return;
            _target = go;
            StartState(GoToHero());
        }

        private void Update()
        {
        }


        private IEnumerator GoToHero()
        {
            while (_throwRange.IsTouchingLayer)
            {
                transform.LookAt(_target.transform);
                if (!_moveRange.IsTouchingLayer && _canThrow)
                {
                    StartState(Throw());
                }
                else if (_attackRange.IsTouchingLayer && _moveRange.IsTouchingLayer)
                {
                    StartState(Attack());
                }
                else
                {
                    SetDirectionToTarget();
                }
                yield return null;
            }

            StartState(Patrol());
        }

        private IEnumerator Attack()
        {
            while (_attackRange.IsTouchingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackSpeed);
            }
            StartState(GoToHero());
        }

        private void SetDirectionToTarget()
        {
            _creature.SetDirection(GetDirectionToTarget());
        }

        private IEnumerator Patrol()
        {
            while (!_throwRange.IsTouchingLayer)
            {
                _animator.SetFloat("Speed", 0);
                yield return null;
            }
            StartState(GoToHero());
        }

        private IEnumerator Throw()
        {
            if (_canThrow)
            {
                _animator.SetTrigger("Throw");

                var projectile = Instantiate(_projectile);
                projectile.transform.position = _fireTransform.position;

                projectile.GetComponent<Projectile>().Throw(_target);
                yield return new WaitForSeconds(_throwCooldown);
            }
            
            StartState(GoToHero());
        }

        private Vector2 GetDirectionToTarget()
        {
            var direction = _target.transform.position - transform.position;
            return direction.normalized;
        }

        private void StartState(IEnumerator coroutine)
        {
            _creature.SetDirection(Vector3.zero);
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = coroutine;
            StartCoroutine(coroutine);
        }
        public void OnDie()
        {
            _isDead = true;
            _animator.SetTrigger("Die");

            _creature.SetDirection(Vector3.zero);
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

    }
}
