using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public partial class Enemy
{
    [SerializeField] private float deathPushForce;
    [Range(0, 5)]
    [SerializeField] private float yPush;

    [SerializeField] private ParticleSystem deathParticle;
    private UltimateCharacterLocomotion locomotion;

    private Transform character;
    private NavMeshAgent agent;

    private void EnemyLocomotion()
    {
        character = Singleton.Instance.Transform; // Replace with desired reference
        agent = GetComponent<NavMeshAgent>();

        locomotion = GetComponent<UltimateCharacterLocomotion>();
        Ragdoll ragdollAbility = locomotion.GetAbility<Ragdoll>();
        ragdollAbility.StartOnDeath = true;
        ragdollAbility.UseGravity = Ability.AbilityBoolOverride.True;
    }

    private void OnDeath(Vector3 deathPosition)
    {
        Vector3 pushDirection = Vector3.Normalize(deathPosition - character.position);
        pushDirection.y = yPush;
        locomotion.AddForce(pushDirection * deathPushForce);
        deathParticle.Play();
    }
    
    private void OnEnable() => DiedEvent += OnDeath;
    private void OnDisable() => DiedEvent -= OnDeath;
}