using App.Scripts.GameScene.GameItems;
using App.Scripts.MainMenuScene;
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
                Debug.Log("FIND!!!!!!");
                _timeInHelpZone += Time.deltaTime;
                if (_timeInHelpZone > requiredTimeToHelp)
                {
                    Debug.Log("ВАРУЕМ!");
                    other.GetComponent<HelpMovableObject>().IsBeingKidnapped = true;
                    AudioManager.Instance.StopBackgroundMusic();
                    AudioManager.Instance.PlayNLOSound();
                    UFO.transform.DOMove(UFO.transform.position * 1.5f, 1F);
                    other.transform.DOMove(UFO.transform.position * 2, 2f);
                    other.transform.DOScale(0, 2f).OnComplete(() =>
                    {
                        Destroy(other.gameObject);
                        Destroy(UFO.gameObject);
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
