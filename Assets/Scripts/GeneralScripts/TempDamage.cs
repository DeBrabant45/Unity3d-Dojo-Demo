using System.Collections;
using UnityEngine;
using AD.Interfaces;
using AD.Weapons;

namespace Assets.Scripts.GeneralScripts
{
    public class TempDamage : MonoBehaviour
    {
        private IDamage _damage;
        [SerializeField] private WeaponSO weaponSO;

        private void Awake()
        {
            _damage = weaponSO;
        }

        private void OnTriggerEnter(Collider hitCollider)
        {
            DoDamage(hitCollider);
        }

        public void DoDamage(Collider hitObject)
        {
            var hittable = hitObject.GetComponent<IHittable>();
            var blockable = hitObject.GetComponent<IBlockable>();
            if (hittable != null)
            {
                if (blockable != null)
                {
                    blockable.Attacker = this.gameObject;
                }
                hittable.GetHit(_damage);
            }
        }
    }
}