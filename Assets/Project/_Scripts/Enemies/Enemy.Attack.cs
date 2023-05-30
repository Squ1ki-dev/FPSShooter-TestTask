using System.Collections;
using UnityEngine;

public partial class Enemy
{
    [SerializeField] private int damage;
    [SerializeField] private float damageDistance;

    [Header("In seconds")] 
    [SerializeField] private float damageCooldown;

    private Transform characterTransform;
    private Transform enemyTransform;

    private IDamageable characterDamageable;

    private bool TargetReached => Vector3.Distance(enemyTransform.position, characterTransform.position) <= damageDistance;
    private bool canDamage = true;

    private IEnumerator DealDamage(IDamageable damageable)
    {
        canDamage = false;

        damageable.DealDamage(damage);
        
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}