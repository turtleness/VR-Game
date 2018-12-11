using UnityEngine;

public class EnemyKnifeShooting : MonoBehaviour
{
    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 5.0f;

    private bool onRange = false;

    public Rigidbody projectile;

    private void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    private void Shoot()
    {
        if (onRange)
        {
            Vector3 targetDir = player.position - transform.position;
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, new Quaternion(-30, 90, -90, 0));
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange)
            transform.LookAt(player);
    }
}