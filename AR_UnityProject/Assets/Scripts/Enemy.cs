﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health = 100;

	void Update ()
	{
		if (health <= 0)
			Destroy(this.gameObject);
	}
}
