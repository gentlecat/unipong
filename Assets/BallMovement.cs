using UnityEngine;

public class BallMovement :MonoBehaviour
{

		public Vector2 Direction;

		// Players
		public GameObject PlayerLeft;
		public GameObject PlayerRight;

		// Score
		public GameObject ScoreLeft;
		public GameObject ScoreRight;

		// Borders	
		public float BorderTop = 7;
		public float BorderBottom = -7;
		public float BorderLeft = -10;
		public float BorderRight = 10;

		void Start ()
		{
				Direction.x = 6;
				Direction.y = 8;
		}

		void Update ()
		{		
				// Win detection
				if (transform.position.x < BorderLeft) { // Right wins			
						Reset ();
						ScoreRight.guiText.text = (int.Parse (ScoreRight.guiText.text) + 1).ToString ();
				} else if (transform.position.x > BorderRight) { // Left wins
						Reset ();
						ScoreLeft.guiText.text = (int.Parse (ScoreLeft.guiText.text) + 1).ToString ();
				} 

				if (transform.position.y > BorderTop || transform.position.y < BorderBottom) {
						Direction.y *= -1;
				}
				transform.Translate (Direction * Time.deltaTime);
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject == PlayerRight || other.gameObject == PlayerLeft) {
						Direction.x *= -1;
				}
		}

		void Reset ()
		{		
				Vector3 newPos = new Vector3 (0, 0, 0);
				transform.position = newPos;
				Direction.x *= -1;
		}

}
