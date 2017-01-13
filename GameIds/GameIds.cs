public class GameIds{

	public class Achievements{
		public static string[] BestScore{
			get{	
				#if UNITY_EDITOR
				return null;
				#elif UNITY_ANDROID
				return GooglePlay.Achievements.bestScore;
				#elif UNITY_IOS
				return GameCenter.Achievements.bestScore;
				#endif
			}
		}
		public static int[] BestRequired = { 0, 50, 80, 150, 220, 270, 350, 450, 600, 800, 1000 };
	}

	public class Leaderboard{
		public static string Best{
			get{	
				#if UNITY_EDITOR
				return null;
				#elif UNITY_ANDROID
				return GooglePlay.Leaderboard.best;
				#elif UNITY_IOS
				return GameCenter.Leaderboard.best;
				#endif
			}
		}
		public static string TotalStars{
			get{	
				#if UNITY_EDITOR
				return null;
				#elif UNITY_ANDROID
				return GooglePlay.Leaderboard.totalStars;
				#elif UNITY_IOS
				return GameCenter.Leaderboard.totalStars;
				#endif
			}
		}
		public static string TotalDiamonds{
			get{	
				#if UNITY_EDITOR
				return null;
				#elif UNITY_ANDROID
				return GooglePlay.Leaderboard.totalDiamonds;
				#elif UNITY_IOS
				return GameCenter.Leaderboard.totalDiamonds;
				#endif
			}
		}
		public static string TotalFlashLightIlluminate{
			get{	
				#if UNITY_EDITOR
				return null;
				#elif UNITY_ANDROID
				return GooglePlay.Leaderboard.totalFlashLightIlluminate;
				#elif UNITY_IOS
				return GameCenter.Leaderboard.totalFlashLightIlluminate;
				#endif
			}
		}
	}

	public class GooglePlay{

		public class Achievements{
			public static string[] bestScore = {
				"CgkI4e-WnfMeEAIQAA", // firstplay
				"CgkI4e-WnfMeEAIQAQ", // beginner
				"CgkI4e-WnfMeEAIQAg", // amateur
				"CgkI4e-WnfMeEAIQAw", // professional
				"CgkI4e-WnfMeEAIQBA", // expert
				"CgkI4e-WnfMeEAIQBQ", // master
				"CgkI4e-WnfMeEAIQBg", // god
				"CgkI4e-WnfMeEAIQBw", // devil
				"CgkI4e-WnfMeEAIQCA", // areyouserious
				"CgkI4e-WnfMeEAIQDg", // missionimpossible
				"CgkI4e-WnfMeEAIQCQ" // chunknorris
			};
		}

		public class Leaderboard{
			public static string best = "CgkI4e-WnfMeEAIQCg";
			public static string totalStars = "CgkI4e-WnfMeEAIQCw";
			public static string totalDiamonds = "CgkI4e-WnfMeEAIQDA";
			public static string totalFlashLightIlluminate = "CgkI4e-WnfMeEAIQDQ";
		}

	}

	public class GameCenter{

		public class Achievements{
			public static string[] bestScore = {
				"FirstPlay", // firstplay
				"Beginner", // beginner
				"Amateur", // amateur
				"Professional", // professional
				"Expert", // expert
				"Master", // master
				"God", // god
				"Devil", // devil
				"AreYouSerious", // areyouserious
				"MissionImpossible", // missionimpossible
				"ChunkNorris" // chunknorris
			};
		}
		
		public class Leaderboard{
			public static string best = "Best";
			public static string totalStars = "TotalStars";
			public static string totalDiamonds = "TotalDiamonds";
			public static string totalFlashLightIlluminate = "TotalFlashLightIlluminate";
		}

	}

}
