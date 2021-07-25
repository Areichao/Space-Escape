using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
	public class AudioManager : MonoBehaviour
	{
		public Sound[] sounds;

		public bool muted;

		public bool muteMusic;

		private float musicVolume;
		private float soundVolume;

		public string song;

		public static AudioManager Instance { get; set; }

		void Awake()
		{
			Instance = this;

			if (PlayerPrefs.HasKey("music"))
				musicVolume = PlayerPrefs.GetFloat("music");
			else musicVolume = 0.5f;
			if (PlayerPrefs.HasKey("sound"))
				soundVolume = PlayerPrefs.GetFloat("sound");
			else soundVolume = 0.75f;

			foreach (Sound s in sounds)
			{
				s.source = gameObject.AddComponent<AudioSource>();
				s.source.clip = s.clip;

				s.source.loop = s.loop;
				if (s.volume == 0)
					s.source.volume = 0.5f;
				else s.source.volume = s.volume;
				if (s.pitch == 0)
					s.source.pitch = 1f;
				else s.source.pitch = s.pitch;
			}
			//song = "Level1";
			Play(song);
			SetVolume(musicVolume);
			SetAllVolume(soundVolume);
		}

		public void MuteSounds()
		{
			muted = !muted;
		}

		public void MuteMusic()
		{
			muteMusic = !muteMusic;
			float v;
			if (muteMusic) v = 0f;
			else v = 1f;
			foreach (Sound s in sounds)
			{
				if (s.name == song)
				{
					s.source.volume = v;
					return;
				}
			}
		}

		public void SetVolume(float v)
		{
			foreach (Sound s in sounds)
			{
				if (s.name == song)
				{
					s.source.volume = v;
					return;
				}
			}
		}

		public void SetAllVolume(float v)
		{
			foreach (Sound s in sounds)
			{
				if (s.name != song)
					s.source.volume = v;
			}
		}

		public void UnmuteMusic()
		{
			foreach (Sound s in sounds)
			{
				if (s.name == song)
				{
					s.source.volume = 1.15f;
					return;
				}
			}
		}

		public void Play(string n)
		{
			if (muted && n != song) return;
			foreach (Sound s in sounds)
			{
				if (s.name == n)
				{
					s.source.Play();
					return;
				}
			}
		}

		private IEnumerator fadeOut(string n)
		{
			foreach (Sound s in sounds)
			{
				if (s.name == song)
				{
					while (s.source.volume > 0.1f)
					{
						s.source.volume -= 0.05f;
						yield return new WaitForSecondsRealtime(0.15f);
					}
				}
			}
			song = n;
			StartCoroutine(fadeIn());
			StopCoroutine(fadeOut(n));
		}

		private IEnumerator fadeIn()
		{
			foreach (Sound s in sounds)
			{
				if (s.name == song)
				{
					Play(song);
					while (s.source.volume < musicVolume)
					{
						s.source.volume += 0.05f;
						yield return new WaitForSecondsRealtime(0.15f);
					}
					StopCoroutine(fadeIn());
				}
			}
		}

		public void ChangeSong(string n)
		{
			StartCoroutine(fadeOut(n));
		}

		public void Stop(string n)
		{
			foreach (Sound s in sounds)
			{
				if (s.name == n)
				{
					s.source.Stop();
					return;
				}
			}
		}

		public void StopAllButSong()
        {
			foreach(Sound s in sounds)
            {
				if(s.name != song)
                {
					s.source.Stop();
                }
            }
        }

		public void StopAll()
		{
			foreach (Sound s in sounds)
			{
				s.source.Stop();
			}
		}
	}
}