using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject shooter;

	private Transform _firePoint;



	void Awake()
	{
		_firePoint = transform.Find("FirePoint");
	}

	// Start is called before the first frame update
	void Start()
    {
		//Invoke("Shoot", 1f);
		//Invoke("Shoot", 2f);
		//Invoke("Shoot", 3f);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Shoot()
	{
		if (bulletPrefab != null && _firePoint != null && shooter != null) {
			GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

			Bullet bulletComponent = myBullet.GetComponent<Bullet>();

			if (shooter.transform.localScale.x < 0f) {
				// Left
				bulletComponent.direction = Vector2.left; // new Vector2(-1f, 0f)
			} else {
				// Right
				bulletComponent.direction = Vector2.right; // new Vector2(1f, 0f)
			}
		}
	}
}
