using UnityEngine;

public class BallMovement :MonoBehaviour
{

		public Vector2 Direction;

		public GameObject Camera;

		// Players
		public GameObject PlayerLeft;
		public GameObject PlayerRight;

		// Score
		public GameObject ScoreLeft;
		public GameObject ScoreRight;

		// Borders
		public float BorderLeft = -10;
		public float BorderRight = 10;

		// Safe direction
		private bool goingDown;
		private bool goingRight;

		void Start ()
		{
				// Ball starts by going to the top right side
				Direction.x = 6;
				Direction.y = 8;
				goingDown = false;
				goingRight = true;
		}

		void Update ()
		{		
				// Win detection
				if (transform.position.x < BorderLeft && !goingRight) { // Right wins			
						Reset ();
						ScoreRight.guiText.text = (int.Parse (ScoreRight.guiText.text) + 1).ToString ();
				} else if (transform.position.x > BorderRight && goingRight) { // Left wins
						Reset ();
						ScoreLeft.guiText.text = (int.Parse (ScoreLeft.guiText.text) + 1).ToString ();
				} 

				float ballHeight = transform.lossyScale.y;
				if (((transform.position.y + ballHeight / 2) < -Camera.camera.orthographicSize && goingDown) ||
						((transform.position.y - ballHeight / 2) > Camera.camera.orthographicSize && !goingDown)) {
						ChangeDirectionY ();
				}
				transform.Translate (Direction * Time.deltaTime);
		}

		
		void OnTriggerEnter2D (Collider2D other)
		{
				// Detecting collision with a player
				if (other.gameObject == PlayerRight || other.gameObject == PlayerLeft) {
						ChangeDirectionX ();
				}
		}

		void Reset ()
		{		
				Vector3 newPos = new Vector3 (0, 0, 0);
				transform.position = newPos;
				ChangeDirectionX ();
		}

		void ChangeDirectionX ()
		{
				Direction.x *= -1;
				goingRight = !goingRight;
		}

		void ChangeDirectionY ()
		{
				Direction.y *= -1;
				goingDown = !goingDown;
		}

}
