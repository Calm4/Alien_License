using DG.Tweening;
using UnityEngine;

namespace App.Scripts.GameScene.Room
{
    public class HelpFloorPlate : MonoBehaviour
    {
        [SerializeField] private float requiredTimeToHelp;
        [SerializeField] private GameObject UFO;
        private float _timeInHelpZone = 0f;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<HelpMovableObject>())
            {
                _timeInHelpZone += Time.deltaTime;
                if (_timeInHelpZone > requiredTimeToHelp)
                {
                    // Убрать возможность двигать предмет Other если он уже забирается
                    other.GetComponent<HelpMovableObject>().IsBeingKidnapped = true;
                    AudioManager.Instance.StopBackgroundMusic();
                    AudioManager.Instance.PlayNLOSound();
                    other.transform.DOMove(UFO.transform.position, 2f);
                    other.transform.DOScale(0, 2f).OnComplete(() =>
                    {
                        Destroy(other.gameObject);
                        AudioManager.Instance.PlayBackgroundMusic();
                    });
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _timeInHelpZone = 0f;
        }
    }
}