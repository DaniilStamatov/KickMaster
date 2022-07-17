using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class KickComponent : MonoBehaviour
    {
        [SerializeField] private float _kickForce;
        public void KickEnemy(GameObject go)
        {
            var rigidbody = go.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddForce(Vector3.forward * _kickForce, ForceMode.Impulse);
            }
        }

    }
}
