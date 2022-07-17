using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public class ShootingEnemy : MonoBehaviour
    {
        [SerializeField] private ColliderCheck _rangeAttack;

        [SerializeField] private ColliderCheck _meleeCanAttack;
        [SerializeField] private CheckSphereOverlap _meleeRange;
        private GameObject _target;

        public void OnHeroInVision(GameObject go)
        {
            _target = go;
        }
    }
}
