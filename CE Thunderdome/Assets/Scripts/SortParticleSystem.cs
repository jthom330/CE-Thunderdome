using UnityEngine;
using System.Collections;

public class SortParticleSystem : MonoBehaviour {

	//this script is just to force the blood particles into the right draw layer

	public string LayerName = "Particles";

	void Start () {
	
		particleSystem.renderer.sortingLayerName = LayerName;
	}
	

}
