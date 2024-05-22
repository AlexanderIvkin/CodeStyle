using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootingDelay;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefab, transform.position, Quaternion.identity);

            Rigidbody bulletRigidbody = newBullet.gameObject.GetComponent<Rigidbody>();

            bulletRigidbody.useGravity = false;
            bulletRigidbody.velocity = direction * _speed;

            yield return new WaitForSeconds(_shootingDelay);
        }
    }
}