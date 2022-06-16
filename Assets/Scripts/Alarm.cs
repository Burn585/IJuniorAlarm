using UnityEngine;

[RequireComponent(typeof(VolumeControl))]

public class Alarm : MonoBehaviour
{
    private VolumeControl _volumeControl;
    private bool _isPlayingAlarm = false;

    private void Start()
    {
        _volumeControl = GetComponent<VolumeControl>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            if (_isPlayingAlarm == false)
            {
                _volumeControl.Run();
                _isPlayingAlarm = true;
            }
            else
            {
                _volumeControl.Stop();
                _isPlayingAlarm = false;
            }
        }
    }
}
