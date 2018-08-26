﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	public float bulletSpeed = 10f;
	public int bulletDamage = 50;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		BulletMovement();
	}

	void BulletMovement()
	{
		if (rb != null)
		{
			transform.position += this.transform.forward * bulletSpeed * Time.deltaTime;
		}
	}

	private void OnCollisionEnter(Collision obj)
	{
		Enemy enemy = obj.gameObject.GetComponent<Enemy>();

		if (enemy != null)
			DamageEnemy(enemy);

		Debug.Log("Bullet was shot into " + obj.collider.name);
		Destroy(this.gameObject);
	}

	private void DamageEnemy(Enemy e)
	{
		e.health -= bulletDamage;
	}
}
