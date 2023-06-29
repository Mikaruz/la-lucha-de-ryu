using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	private bool _isAttacking;
	private Animator _animator;

	public bool bulletPlayer = false;

	[SerializeField] private float cantidadPuntos1;
	[SerializeField] private float cantidadPuntos2;
	[SerializeField] private Puntaje puntaje;
	

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void LateUpdate()
	{
		// Animator
		if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
		{
			_isAttacking = true;
			
		}
		else
		{
			_isAttacking = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_isAttacking == true)
		{
			Debug.Log("TRUE1");
			if (collision.CompareTag("Enemy"))
			{
				Debug.Log("TRUE2");
				puntaje.SumarPuntos(cantidadPuntos1);
				collision.SendMessageUpwards("AddDamage");
			}
			else if (collision.CompareTag("Big Bullet"))
			{
				puntaje.SumarPuntos(cantidadPuntos2);
				bulletPlayer = true;
				collision.SendMessageUpwards("AddDamage");
				
			}


	}	}
}
