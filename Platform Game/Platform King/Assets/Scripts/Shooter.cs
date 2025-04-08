using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Transform firePoint;

    public void Shoot(float direction)
    {
        direction = firePoint.localPosition.x;  // Choose fire direction

        GameObject currentProjectile = Instantiate(projectile, firePoint.position, Quaternion.identity);
        Rigidbody2D currentProjectileVelocity = currentProjectile.GetComponent<Rigidbody2D>();

        if (direction >= 0)
            currentProjectileVelocity.linearVelocity = new Vector2(projectileSpeed * 1, currentProjectileVelocity.linearVelocity.y);
        else
            currentProjectileVelocity.linearVelocity = new Vector2(projectileSpeed * -1, currentProjectileVelocity.linearVelocity.y);
    }
}
