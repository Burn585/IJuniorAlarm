using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private float _speedRate = 0.5f;

    private AudioSource _audioSource;
    private float _currentVolume = 0;
    private Coroutine _fadeJob;

    public void Run()
    {
        _audioSource.Play();
        _fadeJob = StartCoroutine(FadeInOutVolume());
    }

    public void Stop()
    {
        StopCoroutine(_fadeJob);
        _audioSource.Stop();
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator FadeInOutVolume()
    {
        while (true)
        {
            yield return StartCoroutine(UpVolume());
            yield return StartCoroutine(DownVolume());
        }
    }

    private IEnumerator UpVolume()
    {
        float maxVolume = 1;

        while(_currentVolume < maxVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, maxVolume, _speedRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;

            yield return null;
        }
    }

    private IEnumerator DownVolume()
    {
        float minVolume = 0;

        while(_currentVolume > minVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, minVolume, _speedRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;

            yield return null;
        }
    }
}
