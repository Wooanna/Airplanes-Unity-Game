using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour
{

		public int topSpeed;
		public float currentSpeed;
		public int speedStep;
		public int speedModifier;
		public Transform airplane;
		public int upperBound;
		public int downBound;
		public AirplaneStats stats;

		public int currentAngle;
		public int maxAngle = 35;

		void Awake ()
		{
				topSpeed = 5;
				currentSpeed = 0;
				speedStep = 10;
				upperBound = 6;
				downBound = -4;
				speedModifier = 0;
				airplane = gameObject.transform;
				stats = (AirplaneStats)GetComponent ("AirplaneStats");
		}

		bool decreaseSpeed = false;
		Vector3 currentDirection;

		void Update ()
		{
				airplane.Translate (Vector3.forward * (Time.deltaTime * (GetAirplaneSpeed ())), Space.World);

				if (Input.GetKeyUp (KeyCode.UpArrow)) {
						decreaseSpeed = true;
				} else	if (!decreaseSpeed && Input.GetKey (KeyCode.UpArrow) && airplane.position.y < upperBound) {
						currentSpeed += Time.deltaTime * speedStep;
						if (currentSpeed > topSpeed) {
								currentSpeed = topSpeed;
						}

						currentDirection = Vector3.up;
				} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
						decreaseSpeed = true;
				} else if (!decreaseSpeed && Input.GetKey (KeyCode.DownArrow) && airplane.position.y > downBound) {
						currentSpeed += Time.deltaTime * speedStep;
						if (currentSpeed > topSpeed) {
								currentSpeed = topSpeed;
						}
						currentDirection = Vector3.down;
				}
				if (decreaseSpeed) {
						currentSpeed -= Time.deltaTime * (speedStep * .7f);
			
						if (currentSpeed <= 0) {
								currentSpeed = 0;
								decreaseSpeed = false;
								currentDirection = Vector3.zero;
						}
				}

				if (currentDirection != Vector3.zero) {
						airplane.Translate (currentDirection * (Time.deltaTime * currentSpeed), Space.World);
						if (currentDirection == Vector3.up) {
								airplane.rotation = Quaternion.AngleAxis ((currentSpeed / (float)topSpeed) * maxAngle, Vector3.left);
						} else {
								airplane.rotation = Quaternion.AngleAxis ((currentSpeed / (float)topSpeed) * maxAngle, Vector3.right);
						}

				}

				//else if (Input.GetKey(KeyCode.Z))
				//{
				//    airplane.Translate(Vector3.left * (Time.deltaTime * currentSpeed));
				//}
				//else if (Input.GetKey(KeyCode.X))
				//{
				//    airplane.Translate(Vector3.right * (Time.deltaTime * currentSpeed));
				//}

				if (Input.GetKey (KeyCode.LeftArrow)) {
						speedModifier = -2;
				} else if (Input.GetKey (KeyCode.RightArrow)) {
						speedModifier = 2;
				} else {
						speedModifier = 0;
				}

		}

		void OnTriggerEnter (Collider other)
		{
				if (other.tag == "Obstacle") {
						//game over
				} else if (other.tag == "Enemy") {
						stats.AdjustHealth (((CollisionDamage)other.GetComponent ("CollisionDamage")).GetDamage () * -1);
						Destroy (other.gameObject);
				}
		}

		public int GetAirplaneSpeed ()
		{
				return topSpeed + speedModifier;
		}
}
