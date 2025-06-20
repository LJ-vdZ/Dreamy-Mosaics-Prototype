using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip Music;
    public AudioClip btnGeneralSFX;
    public AudioClip btnExitSFX;
    public AudioClip wrongSFX;
    public AudioClip rightSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = Music;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBtnGeneralSFX()
    {
        sfxSource.PlayOneShot(btnGeneralSFX);
    }

    public void PlayBtnExitSFX() 
    {
        sfxSource.PlayOneShot(btnExitSFX);
    }

    public void PlayWrongSFX()
    {
        sfxSource.PlayOneShot(wrongSFX);
    }

    public void PlayRightSFX()
    {
        sfxSource.PlayOneShot(rightSFX);
    }

    //This might not work for the buttons, but I am testing it out
    public void MuteMusic(bool mMute)
    {
        musicSource.mute = mMute;
    }
}
