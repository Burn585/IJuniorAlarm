using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private float _speedRate = 0.5f;

    private AudioSource _audioSource;
    private Coroutine _fadeJob;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Run()
    {
        _audioSource.Play();
        _fadeJob = StartCoroutine(FadeInOutVolume());
    }

    public void Stop()
    {
        StopCoroutine(_fadeJob);
        StartCoroutine(ChangeVolume(0));
        _audioSource.Stop();
    }

    private IEnumerator FadeInOutVolume()
    {
        while (true)
        {
            yield return StartCoroutine(ChangeVolume(1));
            yield return StartCoroutine(ChangeVolume(0));
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        while(_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speedRate * Time.deltaTime);

            yield return null;
        }
    }
}
