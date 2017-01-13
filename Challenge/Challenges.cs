public class Challenges{

	public static int[] challengeReward = {
		20, 30, 35, 45, 65,
		80, 110, 150, 220, 300,
		600 ,800
	};

	public static int ChallengeReward{
		get{
			return ChallengeManager.musicIndex == GameData.savings.currentChallenge ? 
				challengeReward[ChallengeManager.musicIndex] : 0 ;
		}
	}

}
