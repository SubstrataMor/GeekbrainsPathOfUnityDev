using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageble"))
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);

        Destroy(gameObject);
    }
}
