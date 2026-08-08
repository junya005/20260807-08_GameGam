using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{
    private AudioSource _audioSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip walkSound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkSound()
    {
        if (!_audioSource.isPlaying && walkSound != null)
        {
            _audioSource.clip = walkSound;
            _audioSource.Play();
        }
    }

    public void StopWalkSound()
    {
        if (_audioSource.clip == walkSound)
        {
            _audioSource.Stop();
        }
    }

    public void PlayAttackSound()
    {
        if (attackSound != null)
        {
            _audioSource.PlayOneShot(attackSound);
        }
    }
}
