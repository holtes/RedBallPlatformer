using UnityEngine;

namespace _Poject.Develop.Runtime.Data
{
    [CreateAssetMenu(fileName = "New GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _jumpForce;

        public float PlayerSpeed => _playerSpeed;
        public float JumpForce => _jumpForce;
    }
}