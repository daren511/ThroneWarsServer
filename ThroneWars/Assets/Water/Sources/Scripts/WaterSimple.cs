using UnityEngine;
using System.Collections;

// Sets up transformation matrices to scale&scroll water waves
// for the case where graphics card does not support vertex programs.

[ExecuteInEditMode]
public class WaterSimple : MonoBehaviour
{
	public float scrollSpeed = 0.5F;
	void Update() {
		float offset = Time.time * scrollSpeed;
		renderer.sharedMaterial.mainTextureOffset = new Vector2(offset, 0);
	}
}
