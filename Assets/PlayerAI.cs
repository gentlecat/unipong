using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour
{
	
		public GameObject Camera;
		public GameObject Ball;
		public float DefaultMaxSpeed = 10f;
		public float MaxSpeedDeviation = 2f;
		public float SpeedDelta = 0.5f;

		private float currentMovement = 0f;
		private bool isLeftPlayer;

		void Start ()
		{
				// Determining what side this player is on
				if (transform.position.x < 0)
						isLeftPlayer = true;
				else
						isLeftPlayer = false;
		}

		void Update ()
		{
				if (isBallMovingAway ()) {
						// Move to the middle
						Vector3 target = new Vector3 (transform.position.x, 0f);
						transform.position = Vector3.MoveTowards (transform.position, target, DefaultMaxSpeed * Time.deltaTime);
				} else {
						// Maybe move towards ball
						int r1 = Random.Range (0, 3);
						if (r1 > 1) { // Adjust 
								float deviation = Random.Range (-MaxSpeedDeviation, MaxSpeedDeviation);			
								float currentMaxSpeed = DefaultMaxSpeed + deviation;
								if (Ball.transform.position.y > transform.position.y)
										currentMovement = Mathf.Lerp (currentMovement, currentMaxSpeed, SpeedDelta);
								else
										currentMovement = Mathf.Lerp (currentMovement, -currentMaxSpeed, SpeedDelta);
						}

						float paddleHeight = transform.lossyScale.y;
						if ((currentMovement >= 0 && (transform.position.y + paddleHeight / 2) < Camera.camera.orthographicSize) || 
								(currentMovement <= 0 && (transform.position.y - paddleHeight / 2) > -Camera.camera.orthographicSize)) {							
								transform.Translate (Vector2.up * currentMovement * Time.deltaTime);
						}
				}	
		}

		bool isBallMovingAway ()
		{
				if ((isLeftPlayer && Ball.rigidbody2D.velocity.x > 0) || (!isLeftPlayer && Ball.rigidbody2D.velocity.x < 0)) {
						return true;
				}
				return false;
		}

}
