using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class EnterCollision : MonoBehaviour
    {
        [SerializeField] private string[] _tag;
        [SerializeField] private EnterEvent _action;

        private void OnCollisionEnter(Collision other)
        {
            for (int i = 0; i < _tag.Length; i++)
            {
                if (other.gameObject.CompareTag(_tag[i]))
                {
                    _action?.Invoke(other.gameObject);
                }
            }
            
        }
    }

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {
    }
}

