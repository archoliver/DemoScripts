using UnityEngine;
using System.Collections;

public class Levels{

	public static int maxLevel = 19;

	static int fourColorLevel = 4;

	public static bool IsFourColor{
		get{
			return GameManager.currentLevel >= fourColorLevel;
		}
	}

	public static int[] advancedLevelScores = { 
		5, 10, 20, 25, 40,
		50, 60, 70, 85, 100,
		110, 125, 130, 150, 170,
		200, 220, 250, 300, 500
	};

	static float[] spawningSpeedMin = {
		2.0f, 1.9f, 1.7f, 1.5f, 1.4f,
		1.2f, 1.1f, 1.1f, 1.0f, 0.9f,
		0.9f, 0.9f, 0.8f, 0.7f, 0.7f,
		0.7f, 0.6f, 0.6f, 0.6f, 0.5f
	};
	
	static float[] spawningSpeedMax = {
		1.3f, 1.1f, 1.0f, 0.9f, 0.8f,
		0.7f, 0.6f, 0.5f, 0.4f, 0.4f,
		0.4f, 0.3f, 0.3f, 0.3f, 0.2f,
		0.2f, 0.2f, 0.2f, 0.1f, 0.1f,
	};

	public static float SpawningSpeed{
		get{
			return Random.Range(
						spawningSpeedMax[GameManager.currentLevel],
					    spawningSpeedMin[GameManager.currentLevel]
						);
		}
	}

	public static int[][] spawnWeight = { //Red, Blue, Green, Yellow
		new int[]{ 20, 20, 0, 0 },//2 colors
		new int[]{ 20, 20, 20, 20 }//4 colors
	};
	
	static float[] rotationForcemin = {
		0f, 30f, 50f, 70f, 90f,
		110f, 130f, 150f, 180f, 180f, 
		180f, 180f, 180f, 180f, 180f, 
		180f, 180f, 180f, 180f, 200f, 
	};

	static float[] rotationForcemax = {
		0f, 100f, 130f, 170f, 200f,
		230f, 260f, 300f, 330f, 370f,
		370f, 370f, 370f, 370f, 370f, 
		370f, 370f, 370f, 370f, 400f, 
	};
	
	public static float RandomRotationForce{
		get{
			return ChallengeGameManager.isMusicGame ? 
				Random.value >= 0.5 ? 
					Random.Range(-rotationForcemax[2], -rotationForcemin[2]) : 
					Random.Range(rotationForcemin[2], rotationForcemax[2]) :
				Random.value >= 0.5 ? 
					Random.Range(-rotationForcemax[GameManager.currentLevel], -rotationForcemin[GameManager.currentLevel]) : 
					Random.Range(rotationForcemin[GameManager.currentLevel], rotationForcemax[GameManager.currentLevel]);
		}
	}

}
