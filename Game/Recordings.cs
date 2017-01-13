public class Recordings{

	public int collectedRedStars;
	public int collectedBlueStars;
	public int collectedGreenStars;
	public int collectedYellowStars;
	int startingCollectedStars = 0;
	
	public int collectedRedDiamonds;
	public int collectedBlueDiamonds;
	public int collectedGreenDiamonds;
	public int collectedYellowDiamonds;
	int startingCollectedDiamonds = 0;
	
	public int flashedRedLight;
	public int flashedBlueLight;
	public int flashedGreenLight;
	public int flashedYellowLight;
	int startingFlashLight = 0;

	public Recordings(){
		//Stars
		collectedRedStars = startingCollectedStars;
		collectedBlueStars = startingCollectedStars;
		collectedGreenStars = startingCollectedStars;
		collectedYellowStars = startingCollectedStars;
		//Diamonds
		collectedRedDiamonds = startingCollectedDiamonds;
		collectedBlueDiamonds = startingCollectedDiamonds;
		collectedGreenDiamonds = startingCollectedDiamonds;
		collectedYellowDiamonds = startingCollectedDiamonds;
		//Flash light
		flashedRedLight = startingFlashLight;
		flashedBlueLight = startingFlashLight;
		flashedGreenLight = startingFlashLight;
		flashedYellowLight = startingFlashLight;
	}

}
