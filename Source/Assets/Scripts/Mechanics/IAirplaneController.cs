using UnityEngine;
using System.Collections;

public interface IAirplaneController {

	void GoUp();
	void GoDown();
	void KeepCenterVertical();

	void GoLeft();
	void GoRight();
	void KeepCenterHorizontal();

	void SpeedUp();
	void SlowDown();
	void KeepConstantSpeed();
}
