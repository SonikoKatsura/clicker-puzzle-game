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
        sfxClips["NextLevel"] = Resources.Load<AudioClip>("SFX/next_level");
        sfxClips["StartLevel"] = Resources.Load<AudioClip>("SFX/start_level");
        sfxClips["DefeatLevel"] = Resources.Load<AudioClip>("SFX/defeat_level");
        sfxClips["Click"] = Resources.Load<AudioClip>("SFX/click");
        sfxClips["Damage"] = Resources.Load<AudioClip>("SFX/damage");
        sfxClips["Shot"] = Resources.Load<AudioClip>("SFX/shot");

    }

    private void LoadMusicClips() {
        musicClips["MainTheme"] = Resources.Load<AudioClip>("Music/MusicLoop");
        musicClips["MenuMusic"] = Resources.Load<AudioClip>("Music/MenuMusicLoop");
    }

    public void PlaySFX(string clipName) {
        if (sfxClips.ContainsKey(clipName)) {
            sfxSource.clip = sfxClips[clipName];
            sfxSource.Play();
        } else Debug.LogWarning("El AudioClip " + clipName + " no se encontr� en el diccionario de sfxClips.");
    }

    public void PlayMusic(string clipName) {
        if (musicClips.ContainsKey(clipName)) {
            Debug.Log("aja");
            musicSource.clip = musicClips[clipName];
            musicSource.Play();
        } else Debug.LogWarning("El AudioClip " + clipName + " no se encontr� en el diccionario de musicClips.");

        musicSource.loop = (clipName == "mainTheme") ? true : false;
    }

}