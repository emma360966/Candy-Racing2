using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class gunMechanics : MonoBehaviour
{
//bullet
    public GameObject bullet;
//bullet force
    public float shootForce, upwardForce;
//Gun Stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
 //recoil
 public Rigidbody playerRigidBody;
 public float recoilForce;
    
//bools
    public bool shooting, readyToShoot, reloading;
    
//reference 
    public Camera playerCam;
    public Transform attackPoint;
    
//graphics
    public TextMeshProUGUI ammunitionDisplay;
    
//testing :D
    public bool allowInvoke = true;
    public AudioSource gunSounds;

    public AudioSource reloadSound;
    //public GameObject reloadSound;

    private void Awake()
    {
        //make sure mag is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        if (ammunitionDisplay != null)
        {
            if (reloading != true)
            {
                ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + "/" + magazineSize / bulletsPerTap);
            }
            else if (reloading == true)
            {
                ammunitionDisplay.SetText("reloading...");

            }
        }
    }

    private void MyInput()
    {
        //Check if allowed to hold
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.F);
        else shooting = Input.GetKeyDown(KeyCode.F);    
        //reloading
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //reload automatically when no ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();
        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        if (gunSounds != null)
        {
            gunSounds.Play();
        }
        readyToShoot = false;
        //ray stuff
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        //check if ray hits
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
   
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }
//calculate direction from attackPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        
//Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        
//calculate spread with new direction
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
//instantiate bullet projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;
        
//add forces to bullet
currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
currentBullet.GetComponent<Rigidbody>().AddForce(playerCam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;
        
//invoke resetShot function
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
            
            //add recoil to player
            playerRigidBody.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }
//if more than one bullet per tap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloadSound.Play();
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
