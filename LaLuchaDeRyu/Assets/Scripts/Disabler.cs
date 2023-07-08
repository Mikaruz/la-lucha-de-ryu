using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{

	public AudioSource audioSource;
	private void Awake()
	{

		audioSource = GetComponent<AudioSource>();
		audioSource.enabled = false;
	}

	private void Start()
    {
		audioSource.enabled = false;
	}

   

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
		{
			audioSource.enabled = true;
			collision.gameObject.SetActive(false);
			audioSource.Play();
		}
		
	}
}
