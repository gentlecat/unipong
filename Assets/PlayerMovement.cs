using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
		public float MoveSpeed = 40f;
		public string AxisName;
		public float TopLimit = 7;
		public float BottomLimit = -7; 

		void Update ()
		{
				float v = Input.GetAxis (AxisName); 
				if ((v > 0 && transform.position.y < TopLimit) || (v < 0 && transform.position.y > BottomLimit)) {						
						transform.Translate (Vector2.up * v * MoveSpeed * Time.deltaTime);
				}
		}
}