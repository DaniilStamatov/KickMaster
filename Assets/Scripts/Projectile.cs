using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _force;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Throw(GameObject go)
        {
            var direction = (go.transform.position+Vector3.up) - transform.position;
            _rigidbody.AddForce(direction * _force, ForceMode.Force);
        }
    }
}
