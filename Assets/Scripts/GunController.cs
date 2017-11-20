using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public bool isFiring;

	public BulletController bullet;
	public float bulletSpeed;

	public float TimeBetweenShots;
	private float shotCounter;

	public Transform shotSpawn;





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFiring)
		{
			shotCounter-= Time.deltaTime;
				if(shotCounter <= 0)
					{
					shotCounter = TimeBetweenShots;

					BulletController newBullet = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation) as BulletController;
					newBullet.speed = bulletSpeed;
					}

		} else {
			shotCounter = 0;
		}
		
	}
}
