public class Missions{
	
	public static float missionPanelHeightPlusSpacing = 160f;

	public class Type{
		public static int total = 1;
		public static int single = 2;

		public static string star = "a";
		public static string diamond = "b";
		public static string flashLight = "c";
		public static string score = "d";

		public static string red = " red";
		public static string blue = " blue";
		public static string green = " green";
		public static string yellow = " yellow";
		public static string allColor = "";
	}

	public class MissionContent{
		public int type1;
		public string type2;
		public string color;
		public int progressTotal;
		public string content;

		public MissionContent(int _type1, string _type2, string _color, int _amount){
			type1 = _type1;
			type2 = _type2;
			color = _color;
			progressTotal = _amount;
			content = GenMissionContent(_type1, _type2, _color, _amount);
		}

		string GenMissionContent(int type1, string type2, string color, int amount){
			string temp = "";
			if (type1 == 1) {
				if (type2 == "a") temp = "Collect a total of " + amount.ToString() + color + " stars";
				else if (type2 == "b") temp = "Collect a total of " + amount.ToString() + color + " diamonds";
				else if (type2 == "c") temp = "Switch on" + color + " flashlight a total of " + amount.ToString() + " times";
				else if (type2 == "d") temp = "Get a total of " + amount.ToString() + " score";
			}else if (type1 == 2){
				if (type2 == "a") temp = "Collect " + amount.ToString() + color + " stars in a single game";
				else if (type2 == "b") temp = "Collect " + amount.ToString() + color + " diamonds in a single game";
				else if (type2 == "c") temp = "Switch on" + color + " flashlight " + amount.ToString() + " times in a single game";
				else if (type2 == "d") temp = "Get " + amount.ToString() + " score in a single game";
			}
			return temp;
		}
	}
	
	//Mission type
	//	- 1. Total / 2. Single Game
	//	- a. Stars(4 colors) / b. Diamond(4 colors) / c. SwitchOn Flashlight(4 colors) / d. Score
	public static MissionContent[] missionContent = {
		//0
		new MissionContent(2, "a", "", 5),
		new MissionContent(1, "a", "", 20),
		new MissionContent(1, "b", "", 5),
		new MissionContent(2, "a", " red", 5),
		new MissionContent(2, "b", " blue", 3),
		new MissionContent(1, "b", "", 10),
		new MissionContent(2, "c", "", 25),
		new MissionContent(2, "d", "", 30),
		new MissionContent(2, "a", "", 25),
		new MissionContent(2, "a", " blue", 10),
		//10
		new MissionContent(1, "c", "", 50),
		new MissionContent(1, "b", "", 15),
		new MissionContent(2, "c", " red", 15),
		new MissionContent(1, "d", "", 45),
		new MissionContent(2, "d", "", 60),
		new MissionContent(1, "a", " red", 25),
		new MissionContent(2, "c", " blue", 45),
		new MissionContent(1, "d", "", 85),
		new MissionContent(1, "a", " green", 25),
		new MissionContent(2, "b", " yellow", 5),
		//20
		new MissionContent(2, "c", "", 90),
		new MissionContent(2, "b", " green", 7),
		new MissionContent(1, "d", "", 110),
		new MissionContent(1, "a", "", 45),
		new MissionContent(2, "a", " blue", 30),
		new MissionContent(2, "b", " yellow", 8),
		new MissionContent(1, "a", " green", 30),
		new MissionContent(1, "c", " blue", 180),
		new MissionContent(1, "b", "", 15),
		new MissionContent(1, "a", "", 70),
		//30
		new MissionContent(1, "a", " yellow", 50),
		new MissionContent(2, "b", " blue", 10),
		new MissionContent(1, "d", "", 180),
		new MissionContent(2, "c", " red", 120),
		new MissionContent(1, "b", " green", 20),
		new MissionContent(2, "a", " blue", 45),
		new MissionContent(1, "b", " yellow", 20),
		new MissionContent(2, "b", "", 25),
		new MissionContent(1, "a", " red", 90),
		new MissionContent(1, "c", " red", 200),
		//40
		new MissionContent(1, "c", " green", 260),
		new MissionContent(1, "d", "", 250),
		new MissionContent(2, "b", "", 35),
		new MissionContent(2, "a", " red", 60),
		new MissionContent(1, "d", "", 300),
		new MissionContent(2, "c", " yellow", 130),
		new MissionContent(2, "b", "", 40),
		new MissionContent(1, "a", " blue", 130),
		new MissionContent(1, "a", " red", 150),
		new MissionContent(2, "b", "", 60)
	};

}
