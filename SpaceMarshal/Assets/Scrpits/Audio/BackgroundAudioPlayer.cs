using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BackgroundAudioPlayer : MonoBehaviour
{

	public AudioSource AudioSource;
	public List<AudioClip> ListOfAudioClips;
	//public AudioClip AudioClip;

	public int LastNumberGenerated;//the last number generated
	public int PlayCount;//Number of times a clip as played
	public int randomNumber;

	public bool EnableAudio;
	public bool IsClipReady;

	public int WaitTime;
	public int MaxWaitTime;

	// Use this for initialization
	void Start()
	{
		AudioSource = GetComponent<AudioSource>();
		AudioSource.clip = ListOfAudioClips[2];
	}

	// Update is called once per frame
	void Update()
	{

		if (EnableAudio && IsClipReady)
		{
			PlayAudio();
			IsClipReady = false;
		}

		if (!AudioSource.isPlaying)
		{
			PickATrack();
			if (WaitTime >= MaxWaitTime)
			{
				IsClipReady = true;
				WaitTime = 0;
			}
			else
			{
				WaitTime++;
			}
			
		}


	}//END UPDATE

	public void PickATrack()
	{
		randomNumber = GenerateRandomNumber();
		bool IsTrackSet = false;
		while (!IsTrackSet)
		{
			if (CompareNumber(LastNumberGenerated, randomNumber))
			{
				AudioSource.clip = ListOfAudioClips[randomNumber];
				LastNumberGenerated = randomNumber;
				IsTrackSet = true;
			}
			else
			{
				randomNumber = GenerateRandomNumber();
				IsTrackSet = false;
			}
		}
	}

	public int GenerateRandomNumber()
	{
		return Random.Range(0, 3);
	}

	public bool CompareNumber(int LastNumber, int NewNumber)
	{
		if (NewNumber == LastNumber)
		{
			return false;
		}
		return true;
	}

	public void PlayAudio()
	{
		AudioSource.Play();
	}

}
