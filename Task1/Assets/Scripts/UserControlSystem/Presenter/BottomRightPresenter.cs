using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UserControlSystem.Presenter
{
    public class BottomRightPresenter : MonoBehaviour
    {
        [SerializeField] private Button _moveButton;
        [SerializeField] private Button _attacButton;
        [SerializeField] private Button _patrolButton;
        [SerializeField] private Button _holdButton;

        private void Start()
        {
            _moveButton.onClick.AddListener(Move);
            _attacButton.onClick.AddListener(Attact);
            _patrolButton.onClick.AddListener(Patrol);
            _holdButton.onClick.AddListener(Hold);
        }

        private void OnDestroy()
        {
            _moveButton.onClick.RemoveAllListeners();
            _attacButton.onClick.RemoveAllListeners();
            _patrolButton.onClick.RemoveAllListeners();
            _holdButton.onClick.RemoveAllListeners();
        }

        private void Move()
        {
            Debug.Log("Moving");
        }
        
        private void Attact()
        {
            Debug.Log("Attacking");
        }
        
        private void Patrol()
        {
            Debug.Log("Patrolling");
        }
        
        private void Hold()
        {
            Debug.Log("Holding a position");
        }
    }
}