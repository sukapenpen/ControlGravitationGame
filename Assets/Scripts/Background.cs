using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
	[SerializeField]
	private float speed;
	private Vector3 myPos;
	private void Start ()
	{
		//myPos = this.transform.position;
	}
	
	private void Update ()
	{
		float y = Mathf.Repeat (Time.time * speed, 1);

		Vector2 offset = new Vector2 (0, y);

		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
