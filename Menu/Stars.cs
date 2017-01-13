using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

	Collider2D objectDetectorColl;
	Collider2D flashLightRedColl;
	Collider2D flashLightBlueColl;

	ParticleSystem blueParticleSystem;
	ParticleSystem redParticleSystem;

	Animator StarAnim;

	void Awake(){
		objectDetectorColl = GameObject.Find ("ObjectDetector").GetComponent<Collider2D>();
		flashLightRedColl = GameObject.Find ("RedFlashLightColl").GetComponent<Collider2D>();
		flashLightBlueColl = GameObject.Find ("BlueFlashLightColl").GetComponent<Collider2D>();
		blueParticleSystem = GameObject.Find ("BlueParticle").GetComponent<ParticleSystem>();
		redParticleSystem = GameObject.Find ("RedParticle").GetComponent<ParticleSystem>();
		blueParticleSystem.Stop ();
		redParticleSystem.Stop ();
		StarAnim = GetComponent<Animator> ();
	}

	void OnEnable(){
		GetComponent<Rigidbody2D>().AddTorque (
			Random.value >= 0.5 ? 
			Random.Range(-Constants.Forces.MenuStarsRotation.max, -Constants.Forces.MenuStarsRotation.min) : 
			Random.Range(Constants.Forces.MenuStarsRotation.min, Constants.Forces.MenuStarsRotation.max));
		transform.localScale = new Vector3 (1f,1f,1f);
		Invoke ("Destroy", Constants.starsLifeTime);
	}

	void OnDisable(){
		CancelInvoke ("Destroy");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other == objectDetectorColl){
			GetComponent<Rigidbody2D>().AddForce(new Vector2(tag == Tags.Colors.tag_Blue ? -100f : 100f, 100f));
			StarAnim.SetTrigger("StarShrinkTrig");
		}
		else if (other == flashLightBlueColl && tag == Tags.Colors.tag_Blue){
			blueParticleSystem.Play();
			Destroy();
		}
		else if (other == flashLightRedColl && tag == Tags.Colors.tag_Red){
			redParticleSystem.Play();
			Destroy ();
		}
	}

	void Destroy(){
		gameObject.SetActive (false);
	}
}
