using UnityEngine;
using System.Collections.Generic;

public class Dissovler : MonoBehaviour
{
    public Salt salt;
    [SerializeField] private ParticleSystem ps;
    List<ParticleSystem.Particle> enterParticles = new();

    void Start()
    {
        if (ps == null)
        {
            Debug.LogError("Particle System reference is missing!");
        }
    }

    void OnParticleTrigger()
    {
        int count = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterParticles);

        for (int i = 0; i < count; i++)
        {
            ParticleSystem.Particle p = enterParticles[i];

            if (salt.disolves)
            { // Randomly decide to kill or let live
                p.remainingLifetime = 0f; // kills particle
            }
            enterParticles[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterParticles);
    }

    public void SpawnParticles(Transform spawnPoint)
    {
        KillParticles();
        ps.transform.position = spawnPoint.position;
        ps.Emit(10);
    }

    public void KillParticles()
    {
        ps.Clear();
    }
}
