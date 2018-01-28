using UnityEngine;
using System.Collections;

public class ScrollGround : MonoBehaviour {
    public float scrollSpeedx = 0.5F;
	public float scrollSpeedy = 0.5F;

    //don't forget to change the image to a texture and set the boundary to repeat, not clamp

    public Renderer rend;
    void Start() {
        rend = GetComponent<Renderer>();
    }
    void Update() {
        float offsetX = Time.time * scrollSpeedx;
		float offsetY = Time.time * scrollSpeedy;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}