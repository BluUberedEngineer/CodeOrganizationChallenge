using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA {
	public float agility;
	public float strength;
	public float intelligence;
	public int age;

	public DNA (float agility, float strength, float intelligence) {
		this.agility = agility;
		this.strength = strength;
		this.intelligence = intelligence;
		this.age = 0;
	}

	public DNA MergeStats(DNA otherDna){
		float finalAG, finalST, finalIN;

		if (agility < otherDna.agility) {
			finalAG = Random.Range (agility, otherDna.agility +agility);
		} else {
			finalAG = Random.Range (otherDna.agility, agility + otherDna.agility);
		}

		if (strength < otherDna.strength) {
			finalST = Random.Range (strength, otherDna.strength + strength);
		} else {
			finalST = Random.Range (otherDna.strength, strength + otherDna.strength);
		}

		if (intelligence < otherDna.intelligence) {
			finalIN = Random.Range (intelligence, otherDna.intelligence + intelligence);
		} else {
			finalIN = Random.Range (otherDna.intelligence, intelligence + otherDna.intelligence);
		}
	
		return new DNA (finalAG, finalST, finalIN);
	}

	public void AddStats(DNA otherDna, float statPercentage){
		agility = agility + agility * statPercentage;
		strength = strength + strength * statPercentage;
		intelligence = intelligence + intelligence * statPercentage;


	}

}
