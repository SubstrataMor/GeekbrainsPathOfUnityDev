using UnityEngine;

namespace WildBall.InputHandler
{
    [RequireComponent(typeof(Rigidbody))]   // Атрибут указывающий на необходимый компонент
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 2f;
        private Rigidbody playerRigidbody;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            playerRigidbody.AddForce(movement * speed);
        }

#if UNITY_EDITOR
        [ContextMenu("Reset Values")]
        void ResetValues()
        {
            speed = 2f;
        }
#endif
    }
}