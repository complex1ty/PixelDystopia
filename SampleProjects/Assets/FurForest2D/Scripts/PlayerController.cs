using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float maxSpeed = 6f;
	public float jumpForce = 500f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float verticalSpeed = 20;
	[HideInInspector]
	public bool lookingRight = true;
	bool doubleJump = false;

	public GameObject Boom1;
	public GameObject Boom2;
	public ParticleSystem GreenParticle;

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool isGrounded = false;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		Boom1 = GameObject.Find("Prefabs/CloudParticle");
		Boom2 = GameObject.Find("Prefabs/CloudParticle");

		GreenParticle.GetComponent<ParticleSystem> ().enableEmission = false;
	}


	void OnCollisionEnter2D(Collision2D collision2D) 
	{
		
		if (collision2D.relativeVelocity.magnitude > 2 && collision2D.gameObject.tag =="Cloud")
		{
			Boom1 = Instantiate(Resources.Load("Prefabs/CloudParticle"), transform.position, transform.rotation) as GameObject;
		}

		else if (collision2D.relativeVelocity.magnitude > 15 && collision2D.gameObject.tag =="MushroomBlue")
		{
			rb2d.AddForce(new Vector2(0,1000));
		}

		else if (collision2D.gameObject.tag =="CloudBounce")
		{
			rb2d.AddForce(new Vector2(0,700));
			Boom2 = Instantiate(Resources.Load("Prefabs/CloudParticle"), transform.position, transform.rotation) as GameObject;
		}



	}


	void OnTriggerEnter2D(Collider2D triggering)
	{
		if (triggering.gameObject.tag =="Cloud")
		{
			Boom2 = Instantiate(Resources.Load("Prefabs/CloudParticle"), transform.position, transform.rotation) as GameObject;
		}

	
		else if (triggering.gameObject.tag =="MushroomGreen")
		{
			GreenParticle.GetComponent<ParticleSystem> ().enableEmission = true;
		}


	}

	
	// Update is called once per frame
	void Update () {

	if (Input.GetButtonDown("Jump") && (isGrounded || !doubleJump) )
		{
			rb2d.AddForce(new Vector2(0,jumpForce));

			if (!doubleJump && !isGrounded)
			{
				doubleJump = true;
			
	
			}
		}


	if (Input.GetButtonDown("Vertical") && !isGrounded )
		{
			rb2d.AddForce(new Vector2(0,-jumpForce*2));
		}

	}


	void FixedUpdate()
	{
		if (isGrounded) 
			doubleJump = false;


		float hor = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (hor));

		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
		  
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();
		 
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}


	
	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

}
