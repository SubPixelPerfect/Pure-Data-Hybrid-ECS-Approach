using System.Collections.Generic;
using UnityEngine;

namespace Code{
	public class PrefabsList : MonoBehaviour{

		public List<GameObject> prefabs = new List<GameObject>();
		public static PrefabsList instance;
	
		[RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.AfterSceneLoad )]
		private static void Init(){
			instance = GameObject.Find( "GameSettings" ).GetComponent<PrefabsList>();
		}
	
	}
}
