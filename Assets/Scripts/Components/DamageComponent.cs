using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _amount;

        public void ModifyHealth(GameObject go)
        {
            var health  = go.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.ModifyHealth(_amount);
            }
        }
    }
}
