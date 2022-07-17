using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Creature : MonoBehaviour
    {
        [SerializeField] private float _speed;
        protected Rigidbody Rigidbody;
        protected Animator Animator;
        protected Vector3 Direction;


        private static readonly int AttackKey = Animator.StringToHash("attack");
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
        }

        protected virtual void FixedUpdate()
        {
            var xVelocity = Direction.x * _speed;
            var zVelocity = Direction.z * _speed;
            Rigidbody.velocity = new Vector3(xVelocity, 0, zVelocity);

            Animator.SetFloat(Speed, Rigidbody.velocity.magnitude/_speed);
        }

        public void Attack()
        {
            Rigidbody.velocity = Vector3.zero;
            Animator.SetTrigger(AttackKey);
        }
    }
}
