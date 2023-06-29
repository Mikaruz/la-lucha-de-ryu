using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int totalHealth = 3;
	public int maxHealth = 18;

	public RectTransform heartUI;
	public RectTransform gameOverUI;

	[SerializeField] private float cantidadPuntos;
	[SerializeField] private Puntaje puntaje;


	public Transform startPoint;

	public GameObject objetoConCollider; // Variable pública para almacenar una referencia al objeto con el BoxCollider2D

	BoxCollider2D boxCollider; // Variable para almacenar el componente BoxCollider2D


	private bool gameStart = true;

	public GameObject hordes;

	private int health;
	private float heartSize = 16f;

	private SpriteRenderer _renderer;
	private Animator _animator;
	private PlayerController _controller;



	private void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_animator = GetComponent<Animator>();
		_controller = GetComponent<PlayerController>();
	}

	void Start()
    {
		health = totalHealth;
		boxCollider = objetoConCollider.GetComponent<BoxCollider2D>();

	}

	public void AddDamage(int amount)
	{
		health = health - amount;

		// Visual Feedback
		StartCoroutine("VisualFeedback");

		// Game  Over
		if (health <= 0) {
			health = 0;
			gameObject.SetActive(false);
		}

		heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
		Debug.Log("Player got damaged. His current health is " + health);
	}

	public void AddHealth(int amount)
	{
		health = health + amount;

		// Max health
		if (health > maxHealth) {
			health = maxHealth;
		}

		puntaje.SumarPuntos(cantidadPuntos);

		heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);

		Debug.Log("Player got some life. His current health is " + health);
	}

	private IEnumerator VisualFeedback()
	{
		_renderer.color = Color.red;

		yield return new WaitForSeconds(0.1f);

		_renderer.color = Color.white;
	}

    private void OnEnable()
    {
		Vector2 newSize1 = new Vector2(8, 3); // Creamos un nuevo Vector2 con el tamaño deseado
		boxCollider.size = newSize1;
		health = totalHealth;

		
        
		if(gameStart == false)
        {
			health = 3;
			heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
		}	
		
		
		
		
	}

    private void OnDisable()
    {
		Vector2 newSize2 = new Vector2(21, 30); // Creamos un nuevo Vector2 con el tamaño deseado
		boxCollider.size = newSize2; // Establecemos la propiedad size del BoxCollider2D con el nuevo tamaño
		gameStart = false;
		gameOverUI.gameObject.SetActive(true);
		//hordes.SetActive(false);

		puntaje.RestartPoints();

		_animator.enabled = false;
		_controller.enabled = false;
		transform.position = startPoint.position;
		_renderer.color = Color.white;

		
		


		
	}
}
