using UnityEngine;

public class PlayerDeathParticles : MonoBehaviour
{
    [Header("Particle Systems")]
    [SerializeField] public ParticleSystem bloodParticles;

    [Header("Settings")]
    [SerializeField] private float bloodDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            Debug.Log("Your Dead!");
            PlayBloodEffect();
        }
    }

    private void PlayBloodEffect()
    {
        if (bloodParticles != null)
        {
            //bloodParticles.transform.parent = null; // Отсоединяем от игрока
            bloodParticles.Play();
            Destroy(bloodParticles.gameObject, bloodDuration);
        }
    }
}
