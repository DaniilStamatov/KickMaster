using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private OnEnterTrigger _onEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _onEnter?.Invoke(other.gameObject);
            }
        }
    }
    [Serializable]
    public class OnEnterTrigger : UnityEvent<GameObject>
    {

    }
}
