using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour
{
	
		public GameObject Camera;
		public GameObject Ball;
		public float MaxSpeedAbs = 10f;
		public float SpeedDelta = 0.8f;

		private float currentSpeed = 0f;

		void Update ()
		{		
				float paddleHeight = transform.lossyScale.y;
				if ((currentSpeed > 0 && (transform.position.y + paddleHeight / 2) < Camera.camera.orthographicSize) || 
						(currentSpeed < 0 && (transform.position.y - paddleHeight / 2) > -Camera.camera.orthographicSize)) {						
						transform.Translate (Vector2.up * currentSpeed * Time.deltaTime);
				}

				// Adjusting direction
				if (Ball.transform.position.y > transform.position.y && currentSpeed < MaxSpeedAbs) {
						currentSpeed += SpeedDelta;
				} else if (Ball.transform.position.y < transform.position.y && currentSpeed > -MaxSpeedAbs) {
						currentSpeed -= SpeedDelta;
				}
		}

}
