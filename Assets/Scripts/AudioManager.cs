using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    private void Awake() {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);

        LoadSFXClips();
        LoadMusicClips();
    }

    private void LoadSFXClips() {
        sfxClips["DefeatJingle"] = Resources.Load<AudioClip>("SFX/defeat_level");
        sfxClips["StartLevelJingle"] = Resources.Load<AudioClip>("SFX/start_level");
        sfxClips["NextLevelJingle"] = Resources.Load<AudioClip>("SFX/next_level");
        sfxClips["Clic"] = Resources.Load<AudioClip>("SFX/click");
        sfxClips["BloodDamage"] = Resources.Load<AudioClip>("SFX/damage");
        sfxClips["Shot"] = Resources.Load<AudioClip>("SFX/shot");
        sfxClips["Impact"] = Resources.Load<AudioClip>("SFX/impact");
        sfxClips["Explosion"] = Resources.Load<AudioClip>("SFX/explosion");
    }

    private void LoadMusicClips() {
        musicClips["MainTheme"] = Resources.Load<AudioClip>("Music/MusicLoop");
        musicClips["MenuMusic"] = Resources.Load<AudioClip>("Music/MenuMusicLoop");
    }

    public void PlaySFX(string clipName) {
        if (sfxClips.ContainsKey(clipName)) {
            sfxSource.clip = sfxClips[clipName];
            sfxSource.Play();
        } else Debug.LogWarning("El AudioClip " + clipName + " no se encontró en el diccionario de sfxClips.");
    }

    public void PlayMusic(string clipName) {
        if (musicClips.ContainsKey(clipName)) {
            musicSource.clip = musicClips[clipName];
            musicSource.Play();
        } else Debug.LogWarning("El AudioClip " + clipName + " no se encontró en el diccionario de musicClips.");

        musicSource.loop = (clipName == "mainTheme") ? true : false;
    }

}