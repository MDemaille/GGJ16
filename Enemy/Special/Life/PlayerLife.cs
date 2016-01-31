using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLife : AgentLife {

	public Image cellLife;

	public void AddLife(int amount){
		if(currentLife == startingLife){
			return;
		}

		if(currentLife + amount < startingLife){
			currentLife += amount;
		}else{
			currentLife = startingLife;
		}

		UpdateLifeImage();
	}

	/// <summary>
	/// Inflige des dégats à l'agent.
	/// </summary>
	/// <param name="amount">Quantité de dégats reçus.</param>
	/// <param name="virus">Si <c>true</c> alors c'est un virus qui inflige des dégats.</param>
	public override void TakeDamage (int amount, Color colorHit)
	{
		if(isDead)
			return;

		currentLife -= amount;
		StartCoroutine(IsHit(colorHit, 0.1f));

		if(currentLife <= 0)
		{
			if(cellLife.enabled == false){
				cellLife.enabled = true;
			}

			float percentageLife = (float)currentLife / (float)startingLife;
			cellLife.fillAmount = percentageLife;
			cellLife.color = Color.Lerp(Color.red, Color.green, percentageLife);

			Death ();
			return;
		}

		UpdateLifeImage();
	}

	/// <summary>
	/// Met à jour la barre de vie de l'agent.
	/// </summary>
	public void UpdateLifeImage(){
		if(cellLife.enabled == false){
			cellLife.enabled = true;
		}

		float percentageLife = (float)currentLife / (float)startingLife;
		StartCoroutine (CoroutineLife (percentageLife));
	}

	IEnumerator CoroutineLife(float percentageLife) {

		float percent = cellLife.fillAmount;

		float p;
		float elapsedTime = 0f;
		while (elapsedTime < 1f) {
			p = Mathf.Lerp(percent, percentageLife, elapsedTime);
			cellLife.fillAmount = p;
			cellLife.color = Color.Lerp(Color.red, Color.green, p);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		cellLife.fillAmount = percentageLife;
		cellLife.color = Color.Lerp(Color.red, Color.green, percentageLife);
	}
}
