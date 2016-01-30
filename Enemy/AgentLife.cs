using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// La classe AgentLife permet de gérer la vie de l'agent.
/// </summary>

public class AgentLife : MonoBehaviour {

	public float startingLife;
	public float currentLife;

	public bool isDead;

	public GameObject DeathExplosion;
	public float scaleExplosion = 1f;

	// Use this for initialization
	void Awake () {
		currentLife = startingLife;
		isDead = false;
	}

	public void AddLife(int amount){
		if(currentLife == startingLife){
			return;
		}
		
		if(currentLife + amount < startingLife){
			currentLife += amount;
		}else{
			currentLife = startingLife;
		}
	}

	/// <summary>
	/// Inflige des dégats à l'agent.
	/// </summary>
	/// <param name="amount">Quantité de dégats reçus.</param>
	/// <param name="virus">Si <c>true</c> alors c'est un virus qui inflige des dégats.</param>
	public virtual void TakeDamage (int amount, Color colorHit)
	{
		if(isDead)
			return;
		
		currentLife -= amount;
		StartCoroutine(IsHit(colorHit, 0.1f));

		if(currentLife <= 0)
		{
			Death ();
			return;
		}
	}

	/// <summary>
	/// Permet de faire mourir l'agent lorsqu'il n'a plus de vie.
	/// </summary>
	protected virtual void Death ()
	{
		if (DeathExplosion != null) {
			GameObject explosion = Instantiate (DeathExplosion, transform.position, Quaternion.identity) as GameObject;
			explosion.transform.localScale = explosion.transform.localScale * scaleExplosion;
		}

		isDead = true;

		Destroy(gameObject);
	}

	/// <summary>
	/// Permet de détruire l'agent.
	/// </summary>
	public virtual void Kill ()
	{
		Death();
	}

	/// <summary>
	/// Affiche un effet lorsque l'agent subit des dégats.
	/// </summary>
	/// <param name="newColor">La couleur de l'effet.</param>
	public IEnumerator IsHit(Color newColor, float timeBetweenBlinks) {

		SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
		sprite.color = newColor;

		Color c;
		float elapsedTime = 0f;
		while (elapsedTime < timeBetweenBlinks) {
			if(sprite != null)
			{
				c = Color.Lerp(newColor, Color.white, elapsedTime / timeBetweenBlinks);
				sprite.color = c;
				elapsedTime += Time.deltaTime;
			}
			yield return null;
		}

        sprite.color = Color.white;

    }
}
