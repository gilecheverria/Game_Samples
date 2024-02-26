/*
Control the attacks that the soldier can perform

Gilberto Echeverria
2023-03-08
*/

using UnityEngine;

public class SoldierAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletForce;

    GameObject bullet;
    Rigidbody2D bulletRB;
    Animator topAnimator;

    // Start is called before the first frame update
    void Start()
    {
        topAnimator = GameObject.Find("Top").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
        else if (Input.GetButtonDown("Fire2"))
            Melee();
        
    }

    void Shoot()
    {
        // Activate the animation
        topAnimator.SetTrigger("Shoot");

        // Create a new bullet
        bullet = Instantiate(bulletPrefab,
                             bulletSpawnPoint.position,
                             bulletSpawnPoint.rotation);
        // Add force to the bullet
        bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(bulletSpawnPoint.right * bulletForce,
                          ForceMode2D.Impulse);
    }

    void Melee()
    {
        // Activate the animation
        topAnimator.SetTrigger("Melee");
    }
}