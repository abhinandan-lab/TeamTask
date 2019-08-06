using UnityEngine;

public class reloading : MonoBehaviour
{
    /// <summary>
    /// fully customizable and functional bullet reloading script
    /// </summary>



    public int bulletPerMag = 30; // bullets per magzine
    public int totalMagazines = 12; // 30*12=360 bullets
    public bool AutomaticReload = false;
    public bool semiAuto = true;
    public float fireRate = 0.22f;


    [Header("real Time bullet Update")]
    public int bullet;
    public int totalBullet;


    bool fire = true;

    private void Start()
    {
        bullet = bulletPerMag;
        totalBullet = bulletPerMag * totalMagazines;
    }


    void Update()
    {
        if (semiAuto)
        {
            // fire one by one
            if (Input.GetMouseButtonDown(0))
            {
                bulletFire();
            }
        }
        else
        {
            // fire by fireRate given continually
            if (Input.GetMouseButton(0))
            {
                Invoke("bulletFire", fireRate);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
            reload();

    }




    void reload()
    {
        if (totalBullet > 0)
        {
            if(bullet==0 || bullet < bulletPerMag)
            {
                int leftBullets = bullet;
                print(leftBullets + " bullet left in previous mag");
                bullet = bulletPerMag;
                totalBullet -= bullet;
                totalBullet += leftBullets;
                fire = true;
            }
        }
    }


   void bulletFire()
    {
        if (fire)
        {
            bullet--;
            if (bullet == 0)
            {
                print("reload");
                fire = false;
                //reload...
                if (AutomaticReload)
                {
                    reload();
                    print("automatic reload");
                }
            }
        }
    }

}

