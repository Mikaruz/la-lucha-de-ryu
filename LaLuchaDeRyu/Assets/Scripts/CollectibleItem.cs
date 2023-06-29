using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
	

	public int healthRestoration = 1;
	public GameObject lightingParticles;
	public GameObject burstParticles; 
	public AudioSource audioSource;

	


	

	private SpriteRenderer _rederer;
	private Collider2D _collider;

	private void Awake()
	{
		burstParticles.SetActive(false);
		_rederer = GetComponent<SpriteRenderer>();
		_collider = GetComponent<Collider2D>();
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.CompareTag("Player")) {

			


			// Cure Player 
			collision.SendMessageUpwards("AddHealth", healthRestoration);
			
			audioSource.Play();
			// Disable Collider
			_collider.enabled = false;

			// Visual stuff
			_rederer.enabled = false;
			lightingParticles.SetActive(false);
			burstParticles.SetActive(true);

			// Destroy after some  time
			Destroy(gameObject, 1f);

			
		}
	}
}
