using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class CheckSphereOverlap : MonoBehaviour
    {
        [SerializeField] private string[] _tags;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private OnOverlapEvent _onOverlap;
        private Collider[] _interractionResults = new Collider[10];

        public void Check()
        {
            var size = Physics.OverlapSphereNonAlloc(transform.position, _radius, _interractionResults, _mask);

            for (int i = 0; i < size; i++)
            {
                var overlapResult = _interractionResults[i];
                var isInTag = _tags.Any(tag => overlapResult.CompareTag(tag));
                if (isInTag)
                {
                    _onOverlap?.Invoke(overlapResult.gameObject);
                }
            }
        }

#if UNITY_EDITOR


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0, 0, 1, 0.2f);
            Gizmos.DrawSphere(transform.position, _radius);
        }
#endif
    }

    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject>
    {

    }
}
