using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class ShooterTimer : MonoBehaviour
{
    private Shooter shooter;
    [SerializeField] private GameObject firePoint;
    private Vector3 firePointPosition;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        firePointPosition = firePoint.transform.localPosition;
        Coroutine coroutine = StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            shooter.Shoot(firePointPosition.x);
            yield return new WaitForSeconds(3);
        }
    }
}




