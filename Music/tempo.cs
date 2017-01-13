using UnityEngine;
using System.Collections;

public class tempo {
	float intervalTime;
	public float IntervalTime {
		get {
			return intervalTime;
		}
		set {
			intervalTime = value;
		}
	}

	public tempo (float speed, float reference) {
		this.intervalTime = (1/(speed/60)) / (1/reference);  // time interval of note ( 1 )
	}
}

