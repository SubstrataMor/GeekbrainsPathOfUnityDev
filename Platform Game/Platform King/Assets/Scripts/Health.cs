using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool isAlive;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
        Debug.Log(currentHealth);
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
            isAlive = true;
        else
        {
            isAlive = false;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy is alive " + isAlive + "\nEnemy die");
    }
}
