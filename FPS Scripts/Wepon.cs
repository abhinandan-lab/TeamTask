using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public int damage = 25; 
    public float range = 30f;  // weapon firing range

    public Camera cameraNew;
    public GameObject bullet_Impactfornow;
    public GameObject trail;
    public GameObject fireP;


    // public variables created for 'reloading'
    [Header("about Reload")]
    public bool semiAuto=false;
    public bool autoReload = false;
    public int bulletPerMag= 30;
    public int totalMagazine = 15;  // bulletPermag * totalMagazine gives total bullets we have
    public float fireRate = 0.6f;
    public float reloadTime = 2f;

    [HideInInspector]
    public int bullet, totalBullet;


    bool fire = true;


    float tcount = 0f;


    void Start()
    {
        totalBullet = bulletPerMag * totalMagazine;
        bullet = bulletPerMag;
    }

    // Update is called once per frame
    void Update()
    {
        if (semiAuto)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (fire && Time.time >= tcount)
                {
                    shoot();
                    // remember the fire rate is not set as bullets per second... so set fireRate value as you need it will work as u needed.
                    tcount = Time.time + 1f / fireRate;
                    print("fired!..");
                    bullet--;
                    if (bullet == 0)
                    {
                        fire = false;
                        if (autoReload)
                            StartCoroutine(reload());
                        else
                            print("no bullets, pls reload");
                    }
                }
            }
        }


        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (fire && Time.time >= tcount)
                {
                    shoot();

                    tcount = Time.time + 1f / fireRate;
                    print("fired!..");
                    bullet--;
                    if (bullet == 0)
                    {
                        fire = false;
                        if (autoReload)
                            StartCoroutine(reload());
                        else
                            print("no bullets, pls reload");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }        
    }

    IEnumerator reload()
    {
        if (totalBullet > 0)
        {
            if (bullet==0 || bullet<bulletPerMag)
            {
                int preBullets = bullet;
                yield return new WaitForSeconds(reloadTime);
                // mention the animation of reload, or whatever time taken to reload... 
                bullet = bulletPerMag;
                totalBullet -= bulletPerMag;
                totalBullet += preBullets;
                fire = true;
            }
        }
    }



    void shoot()
    {


        RaycastHit hit; // the ray name
        if (Physics.Raycast(cameraNew.transform.position, cameraNew.transform.forward, out hit, range)) // shoots a ray from the camera to the front for the range float
        {
            Instantiate(trail, fireP.transform.position, fireP.transform.rotation);


            Target target = hit.transform.GetComponent<Target>(); // target is any damagable object

            if (target != null)
            {
                // damage
                target.TakeDamage(damage);
            }


            GameObject bulletI = Instantiate(bullet_Impactfornow, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(bulletI, 0.1f);
        }

    }

}