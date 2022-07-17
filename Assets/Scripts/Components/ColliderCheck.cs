using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ColliderCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private float _radius;
        [SerializeField] private bool _isTouchingLayer;

        public bool IsTouchingLayer => _isTouchingLayer;

        private void Update()
        {
            _isTouchingLayer = Physics.CheckSphere(transform.position, _radius, _mask);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {

            Gizmos.color = new Color(1, 0, 0, 0.2f);
            Gizmos.DrawSphere(transform.position, _radius);
        }
#endif
    }
}
