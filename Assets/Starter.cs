using UnityEngine;

public class Starter : MonoBehaviour
{

		public string GameLevelName;

		void Update ()
		{		
				if (Input.GetKeyDown ("space")) {
						Application.LoadLevel (GameLevelName);
				}
		}

}
