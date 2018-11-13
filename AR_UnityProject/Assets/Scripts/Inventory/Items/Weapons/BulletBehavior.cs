﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	public float bulletSpeed = 10f;
	public float knockbackStrength = 10f;
	public int bulletDamage = 50;

	private Rigidbody rb;
    private Vector3 originPos;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		BulletMovement();
	}

	private void BulletMovement()
	{
		if (rb != null)
			transform.position += transform.forward * bulletSpeed * Time.deltaTime;
	}

	private void DisableBullet()
	{
		gameObject.SetActive(false);
	}

	private void OnCollisionEnter(Collision obj)
	{
		Enemy enemy = obj.gameObject.GetComponent<Enemy>();

		if (enemy != null) 
		{
			enemy.TakeDamage(bulletDamage);
		}

		GameObject sparks = ObjectPoolManager.GetInstance().GetObjectFromPool(ObjectPoolManager.ObjectType.SPARKS_EFFECT);
		sparks.transform.position = obj.contacts[0].point;

        Vector3 sparksDir = originPos - obj.contacts[0].point;
		sparks.transform.forward = sparksDir.normalized;

		sparks.SetActive(true);

		DisableBullet();
	}

    public void SetOriginPos(Vector3 _originPos)
    {
        originPos = _originPos;
    }
}
