using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1"))
		{
			Debug.Log ("will move");
			anim.SetTrigger("Move");

			Debug.Log ("will fade");
			StartCoroutine(Fade(1.0f, 0.1f));
		}
	}

	IEnumerator Fade(float time, float targetAlpha)
	{
		Debug.Log ("test");
		float t = 0.0f;
		float currentAlpha = renderer.material.color.a;
		Color color = renderer.material.color;

		while(t <= 1.0f)
		{
			color.a = Mathf.Lerp(currentAlpha, targetAlpha, t);
			renderer.material.color = color;
			t += Time.deltaTime/time;
			yield return new WaitForSeconds(0.1f);
		}

		color.a = targetAlpha;
		renderer.material.color = color;
		Debug.Log ("color: " + renderer.material.color);
	}
}
