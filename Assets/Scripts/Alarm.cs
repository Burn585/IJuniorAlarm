using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedRate = 0.5f;

    private AudioSource _audioSource;
    private bool _isPlayingAlarm = false;
    private bool isVolumeDown = true;
    private float _currentVolume = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isPlayingAlarm)
        {
            VolumeControl();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (_isPlayingAlarm == false)
            {
                _audioSource.Play();
                _isPlayingAlarm = true;
            }
            else
            {
                _audioSource.Stop();
                _isPlayingAlarm = false;
            }
        }
    }

    private void VolumeControl()
    {
        float maxVolume = 1;
        float minVolume = 0;

        if (isVolumeDown)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, maxVolume, _speedRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }
        else
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, minVolume, _speedRate * Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }

        if (_currentVolume <= minVolume)
        {
            isVolumeDown = true;
        }
        else if (_currentVolume >= maxVolume)
        {
            isVolumeDown = false;
        }
    }
}
