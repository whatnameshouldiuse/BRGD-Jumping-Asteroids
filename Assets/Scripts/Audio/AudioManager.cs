using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FMOD_Thuleanx {
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance = null;

		// Settings
		FMOD.Studio.Bus Music;
		FMOD.Studio.Bus SFX;
		FMOD.Studio.Bus Master;
		bool prepped = false;

		void Awake() {
			Instance = this;
		}

		void Prep() {
			Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
			SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
			Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
		}

		public float GetMusicVolume() {
			if (!prepped) Prep();
			float amt;
			if (Music.getVolume(out amt) != FMOD.RESULT.OK) {
				Debug.LogError("Cannot get volume for bus //Master//Music");
				return 0;
			}
			return amt;
		}

		public float GetMasterVolume() {
			if (!prepped) Prep();
			float amt;
			if (Master.getVolume(out amt) != FMOD.RESULT.OK) {
				Debug.LogError("Cannot get volume for bus //Master");
				return 0;
			}
			return amt;
		}

		public float GetSFXVolume() {
			if (!prepped) Prep();
			float amt;
			if (SFX.getVolume(out amt) != FMOD.RESULT.OK) {
				Debug.LogError("Cannot get volume for bus //Master//SFX");
				return 0;
			}
			return amt;
		}

		public void SetMusicVolume(float amt) {
			if (!prepped) Prep();
			Music.setVolume(amt);
		}
		public void SetSFXVolume(float amt) {
			if (!prepped) Prep();
			SFX.setVolume(amt);
		}
		public void SetMasterVolume(float amt) {
			if (!prepped) Prep();
			Master.setVolume(amt);
		}
		public void PlayOneShot(string soundRef) {
			if (soundRef != null && soundRef.Length > 0)
				FMODUnity.RuntimeManager.PlayOneShot(soundRef);
		}

		public FMOD.Studio.EventInstance GetInstance(string soundRef) {
			return FMODUnity.RuntimeManager.CreateInstance(soundRef);
		}
	}
}
