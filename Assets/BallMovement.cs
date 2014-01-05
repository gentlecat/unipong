using UnityEngine;

public class BallMovement :MonoBehaviour
{

		public Vector2 Direction;

		// Players
		public GameObject PlayerRight;
		public GameObject PlayerLeft;

		// Borders	
		public float BorderTop = 7;
		public float BorderBottom = -7;

		void Start ()
		{
				Direction.x = 3;
				Direction.y = 4;
		}

		void Update ()
		{
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

}
