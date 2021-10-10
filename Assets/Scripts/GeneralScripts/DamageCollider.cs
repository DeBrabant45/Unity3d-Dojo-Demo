using AD.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour, IDamageable
{
    private Collider _itemCollider;
    private IDamage _damage;
    private ITagable _tag;

    public Collider ItemCollider { get => _itemCollider; }

    private void Start()
    {
        _itemCollider = GetComponent<Collider>();
        DisableCollider();
    }

    public void SetDamage(IDamage damage)
    {
        if(_damage != damage)
        {
            _damage = damage;
        }
    }

    public void SetTagToNotHit(ITagable tag)
    {
        if(_tag != tag)
        {
            _tag = tag;
        }
    }

    private void OnTriggerEnter(Collider hitCollider)
    {
        DoDamage(hitCollider);
    }

    public void DoDamage(Collider hitObject)
    {
        var hittable = hitObject.GetComponent<IHittable>();
        var blockable = hitObject.GetComponent<IBlockable>();
        if (hittable != null && hitObject.gameObject.tag != _tag.TagName)
        {
            if (blockable != null)
            {
                blockable.AttackerTag = _tag;
            }
            var spawnHitEffect = Instantiate(_damage.ParticalEffect, transform.position, Quaternion.identity);
            Destroy(spawnHitEffect, 2f);
            hittable.GetHit(_damage);
        }
    }

    public void EnableCollider()
    {
        _itemCollider.enabled = true;
    }

    public void DisableCollider()
    {
        _itemCollider.enabled = false;
    }
}
