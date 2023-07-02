using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float speed = 1f;
	public float wallAware = 0.5f;
	public LayerMask groundLayer;
	public float playerAware = 3f;
	public float aimingTime = 0.5f;
	public float shootingTime = 1.5f;

	private Rigidbody2D _rigidbody;
	private Animator _animator;
	private Weapon _weapon;
	private AudioSource _audio;

	public PolygonCollider2D ataque;

	// Movimiento
	private Vector2 _movement;
	private bool _facingRight;

	private bool _isAttacking;
	public int damage = 1;

	

	private PlayerHealth vida;


	
	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_weapon = GetComponentInChildren<Weapon>();
		_audio = GetComponent<AudioSource>();

		vida = GetComponent<PlayerHealth>();
	}

	// Start is called before the first frame update
	void Start()
	{
		if (transform.localScale.x < 0f)
		{
			_facingRight = false;
		}
		else if (transform.localScale.x > 0f)
		{
			_facingRight = true;
		}
	}

	// Volterase
	void Update()
	{
		Vector2 direction = Vector2.right;

		if (_facingRight == false)
		{
			direction = Vector2.left;
		}

		if (_isAttacking == false)
		{
			if (Physics2D.Raycast(transform.position, direction, wallAware, groundLayer))
			{
				Flip();
			}
		}
		

	}

	private void FixedUpdate()
	{
		float horizontalVelocity = speed;

		if (_facingRight == false)
		{
			horizontalVelocity = horizontalVelocity * -1f;
		}

		if (_isAttacking)
		{
			horizontalVelocity = 0f;
		}

		_rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
	}

	private void LateUpdate()
	{
		_animator.SetBool("Idle", _rigidbody.velocity == Vector2.zero);
	}




	private void OnTriggerStay2D(Collider2D collision)
	{
		if (_isAttacking == false && collision.CompareTag("Player"))
		{
			StartCoroutine("AimAndShoot");
			if (collision.CompareTag("Player"))
			{

				StartCoroutine(DamageCooldownCoroutine(collision));
				//collision.SendMessageUpwards("AddDamage", damage);
				Debug.Log("Se detectó una colisión con un CircleCollider2D");

				
			}
		}

		
	}

	private bool canDamage = true;
	private float damageCooldown = 1.1f;

	private IEnumerator DamageCooldownCoroutine(Collider2D collision)
	{
		
		ataque.enabled = true;
		yield return new WaitForSeconds(damageCooldown);
		

		collision.SendMessageUpwards("AddDamage", damage);
		ataque.enabled = false;
		yield return new WaitForSeconds(damageCooldown);
		

	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}


	

	private void Flip()
	{
		_facingRight = !_facingRight;
		float localScaleX = transform.localScale.x;
		localScaleX = localScaleX * -1f;
		transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
	}

	private IEnumerator AimAndShoot()
	{
		_isAttacking = true;

		yield return new WaitForSeconds(aimingTime);

		
		_animator.SetTrigger("Shoot");
		

		yield return new WaitForSeconds(shootingTime);

		_isAttacking = false;
	}

	void CanShoot()
	{

		
		
		Debug.Log("ATAQUE -1");
		

		
		if (_weapon != null)
		{
			_weapon.Shoot();
			_audio.Play();
		}

		
	}




	private void OnEnable()
	{
		ataque.enabled = false;
		_isAttacking = false;
		
		
	}

	private void OnDisable()
	{
		ataque.enabled = false;
		StopCoroutine("AimAndShoot");
		_isAttacking = false;
	}
}