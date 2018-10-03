﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : Item
{
	public ObjectsPool bulletsPool;
	public GameObject bulletPrefab;
    public Type_Of_Weapon weaponType;
    public Transform shootingPoint;
    public bool autoFire = true;

	// For shotgun only
	public Transform pointLeft;
	public Transform pointRight;

	public override void UseItem()
    {
        base.UseItem();

        if (Input.GetKey(KeyCode.Space))
            Shoot(weaponType);
    }

    void Shoot(Type_Of_Weapon type)
    {
        switch (type)
        {
            case Type_Of_Weapon.GUN:
				Gun();
                break;
            case Type_Of_Weapon.SHOTGUN:
				Shotgun();
                break;
            case Type_Of_Weapon.ASSAULT_RIFLE:
                Debug.Log("Im an ASSAULT RIFLE");
                break;
            case Type_Of_Weapon.ROCKET_LAUNCHER:
				RocketLauncher();
                break;
        }
    }

    public enum Type_Of_Weapon
    {
        GUN,
        SHOTGUN,
        ASSAULT_RIFLE,
        ROCKET_LAUNCHER
    }

    void Gun()
    {
		if(autoFire)
			Debug.Log("Im an AUTOMATIC-GUN");
		else 
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
                if (currentAmmo > 0)
                {
                    GameObject bullet = bulletsPool.GetObjectPooled();
                    bullet.transform.position = shootingPoint.position;
                    bullet.transform.rotation = shootingPoint.rotation;
                    bullet.SetActive(true);

                }
            }
		}
	}

	void Shotgun() 
	{
		if(Input.GetKeyDown(KeyCode.Space)) 
		{
            if (currentAmmo > 0)
            {
                GameObject bulletLeft = bulletsPool.GetObjectPooled();
                bulletLeft.transform.position = pointLeft.position;
                bulletLeft.transform.rotation = pointLeft.rotation;
                bulletLeft.SetActive(true);
                currentAmmo--;
            }


            if (currentAmmo > 0)
            {
                GameObject bulletMiddle = bulletsPool.GetObjectPooled();
                bulletMiddle.transform.position = shootingPoint.position;
                bulletMiddle.transform.rotation = shootingPoint.rotation;
                bulletMiddle.SetActive(true);
                currentAmmo--;
            }

            if (currentAmmo > 0)
            {
                GameObject bulletRight = bulletsPool.GetObjectPooled();
                bulletRight.transform.position = pointRight.position;
                bulletRight.transform.rotation = pointRight.rotation;
                bulletRight.SetActive(true);
                currentAmmo--;
            }
        }
    }

	void RocketLauncher() 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
            if (currentAmmo > 0)
            {
                GameObject rocket = bulletsPool.GetObjectPooled();
                rocket.transform.position = shootingPoint.position;
                rocket.transform.rotation = shootingPoint.rotation;
                rocket.SetActive(true);
                currentAmmo--;
            }
        }
    }
}
