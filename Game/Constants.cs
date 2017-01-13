using UnityEngine;

public class Constants{

	public static int FrameRate = 60;

	public static float sceneFadingTime = 0.25f;

	public static float starsLifeTime = 2f;
	public static float diamondPlusOneLifeTime = 1.1f;

	public static float diamondsAppearWeight = 0.15f;

	public class Forces{
		public class Stars{
			public static Vector2 Red = new Vector2 (100f, 100f);
			public static Vector2 Blue = new Vector2 (-100f, 100f);
			public static Vector2 Green = new Vector2 (150f, 170f);
			public static Vector2 Yellow = new Vector2 (-150f, 170f);
		}
		public class Diamonds{
			public static Vector2 Red = new Vector2 (90f, 100f);
			public static Vector2 Blue = new Vector2 (-90f, 100f);
			public static Vector2 Green = new Vector2 (150f, 140f);
			public static Vector2 Yellow = new Vector2 (-150f, 140f);
		}

		public class MenuStarsRotation{
			public static float min = 200f;
			public static float max = 400f;
		}
	}


}
