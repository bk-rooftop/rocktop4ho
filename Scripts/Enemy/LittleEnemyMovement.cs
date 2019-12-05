using UnityEngine;
using System.Collections;

public class LittleEnemyMovement : MonoBehaviour {

	public enum MonsterState { idle, trace, attack, die};
	public MonsterState currentState = MonsterState.trace;

	public float attackSpeed = 4f;
	public float attackDist = 3f;
	public float traceDist = 5f;

	public float timeBetweenAttack = 0.5f;
	public int attackDamage = 10;

	Transform player;
	PlayerHealth playerHealth;
	LittleEnemyHealth enemyHealth;
	UnityEngine.AI.NavMeshAgent nav;


	Animator anim;
	Vector3 movement;


	float timer = 0f;
	Rigidbody myRigidbody;
	bool playerInRange;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		playerHealth = player.GetComponent<PlayerHealth> ();
		enemyHealth = GetComponent<LittleEnemyHealth> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();



	}



	void Start()
	{
		StartCoroutine (UpdatePath ());

	}

	void Update()
	{
		timer += Time.deltaTime;

		float dist = (player.position - transform.position).sqrMagnitude;
		float attackEnable = Mathf.Pow (attackDist, 2);

		if (timer >= timeBetweenAttack && dist <= attackEnable && playerHealth.currentHealth > 0 && enemyHealth.currentHealth >0) 
		{
			StartCoroutine (Attack ());

		} 
		else if (timer < timeBetweenAttack && dist <= attackEnable && playerHealth.currentHealth > 0) 
		{
			IdleState ();

		} 
		else
		{
			currentState = MonsterState.trace;
		}



	}

	void IdleState()
	{
		currentState = MonsterState.idle;
		nav.enabled = false;
		anim.SetBool ("IsWalking", false);
	}

	IEnumerator UpdatePath()
	{
		float refreshRate = .25f;


		while (enemyHealth.currentHealth >= 0) 
		{

			if (currentState == MonsterState.trace && playerHealth.currentHealth > 0) 
			{
				nav.enabled = true;
				anim.SetBool ("IsWalking", true);

				Vector3 playerPosition = new Vector3 (player.position.x, 0, player.position.z);
				Vector3 attackDirection = (player.position - transform.position).normalized;
				Vector3 attackPosition = playerPosition - attackDirection * 1f;
				nav.SetDestination (attackPosition);


			} 

			else
			{
				currentState = MonsterState.idle;
				nav.enabled = false;
				anim.SetBool ("IsWalking", false);


			}


			yield return new WaitForSeconds (refreshRate);
		}

	}


	IEnumerator Attack()
	{
		currentState = MonsterState.attack;
		nav.enabled = false;

		timer = 0f;	

		transform.LookAt (player);

		anim.SetBool ("Attack", true);




		float percent = 0;
		bool hasDamage = false;

		while (percent <= 1) 
		{		
			if (percent >= .5f && !hasDamage) {
				hasDamage = true;
				playerHealth.TakeDamage (attackDamage);
			}

			percent += Time.deltaTime * attackSpeed;


			yield return null;
		}		



	



		currentState = MonsterState.trace;
		nav.enabled = true;
		anim.SetBool ("Attack", false);


	}





}
