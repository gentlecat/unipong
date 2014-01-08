using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
		public float MoveSpeed = 10f;
		public string AxisName;
		public GameObject Camera;

		void FixedUpdate ()
		{
				float v = Input.GetAxis (AxisName);
				float paddleHeight = transform.lossyScale.y;
				if ((v > 0 && (transform.position.y + paddleHeight / 2) < Camera.camera.orthographicSize) || 
						(v < 0 && (transform.position.y - paddleHeight / 2) > -Camera.camera.orthographicSize)) {						
						transform.Translate (Vector2.up * v * MoveSpeed * Time.deltaTime);
				}
		}

}