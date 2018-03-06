using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour{
	public DNA Dna;
	public enum ageMode {young, prime, decay};
	public ageMode agemode;

	//creature lifetime etc

	

	void OnTriggerEnter(Collision coll){
		if (Random.Range (0, 1) == 1) {
			if (Random.Range (0f, 0.1f * Dna.intelligence) == 1) {
				Run (coll.gameObject);
			} else {
				Fight (coll.gameObject);
			}
		} else {
			Mate (coll.gameObject);
		}
	}

	void start(){
		StartCoroutine (AgeDecay ());
	}

	void Update(){
		if (Dna.age > 40) {
			agemode = ageMode.prime;
		}
	}

	public void Mate(GameObject collObj){
		for (int i = 0; i < Random.Range (1f, 3f); i++) {
			
			Instantiate (gameObject, transform.position, transform.rotation);
		}
	}

	public void Fight(GameObject collObj){
		if (Dna.strength > collObj.GetComponent <Creature>().Dna.strength) {
			Dna.AddStats (collObj.GetComponent <Creature>().Dna, 0.2f);
		} else {
			Destroy (gameObject, 0.3f);
		}
	}

	public void Run(GameObject collObj){
		//iets met de nav mesh agent ofzo
	}

	public IEnumerator AgeDecay(){
		Dna.age = Dna.age + 1;
		yield return new WaitForSeconds(1f);

		switch (agemode) {
		case ageMode.young:
			Dna.age = Dna.age + 1;
			yield return new WaitForSeconds(1f);
			break;

		case ageMode.prime:
			yield return new WaitForSeconds (40f);
			agemode = ageMode.decay;
			break;

		case ageMode.decay:
			Dna.age = Dna.age - 1;
			yield return new WaitForSeconds(1.8f);
			break; 
		}

		StartCoroutine (AgeDecay ());
	}



}
