using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = 1f;
    public int lifeTime = 3;

    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;

    private float nextTimeToFire = 0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;

    public AudioSource audioData;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    

    void Shoot()
    {
        //muzzleFlash.Play();

        GameObject bullet = Instantiate(bulletPrefab);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
            bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
        audioData.Play();
        StartCoroutine(DeleteBullet(bullet, lifeTime));
    }

    IEnumerator DeleteBullet(GameObject bullet, int lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(bullet);
    }
}