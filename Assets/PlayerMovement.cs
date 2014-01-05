using UnityEngine;

public class PlayerMovement : MonoBehaviour {
		public float MoveForce = 40f;
		public float MaxSpeed = 2f;
		public string AxisName;

		void Update() {
				float v = Input.GetAxis(AxisName);
				if (v * rigidbody2D.velocity.y < MaxSpeed) {
						rigidbody2D.AddForce(Vector2.up * v * MoveForce);
				}
		}
}
