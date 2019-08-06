using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammo : MonoBehaviour
{
    public Text bulletsInMag;                // assign the text object form canvas which is used to show 'bullets'
    public Text totalBulletsWithPlayer;

    Wepon weapon;

    Color color1;
    Color color2;

    private void Start()
    {
        weapon = FindObjectOfType<Wepon>();// here it will find Wepon script from where the bullets info will acquire

        color1 = bulletsInMag.color; // this are the default colors set by user 
        color2 = totalBulletsWithPlayer.color;
    }


    // Update is called once per frame
    void Update()
    {

        bulletsInMag.text = weapon.bullet.ToString();
        if (int.Parse(bulletsInMag.text) <= 3)
            bulletsInMag.color = Color.red;

        if (int.Parse(bulletsInMag.text) > 3)
            bulletsInMag.color = color1;

        totalBulletsWithPlayer.text = weapon.totalBullet.ToString();
        if (int.Parse(totalBulletsWithPlayer.text) <= 14)
            totalBulletsWithPlayer.color = Color.red;

        if (int.Parse(totalBulletsWithPlayer.text) > 14)
            totalBulletsWithPlayer.color = color2;
        

        
    }
    
}
