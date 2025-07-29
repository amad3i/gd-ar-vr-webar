using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public GameObject sfx;
	public AudioClip[] audioClips;

	public void PlaySound(int soundNum)
	{
		GameObject s = Instantiate(sfx,Vector2.zero,Quaternion.identity) as GameObject;
		AudioSource AS = s.GetComponent<AudioSource>();

		AS.clip = audioClips[soundNum];
		AS.Play();
		Destroy(s,audioClips[soundNum].length);
	}

}
