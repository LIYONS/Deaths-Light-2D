using UnityEngine;

namespace DeathLight.Player
{
    public class Hiding : MonoBehaviour
    {
        [SerializeField] private Transform frontCheck;
        [SerializeField] private float radius;
        [SerializeField] private Transform backCheck;
        [SerializeField] private LayerMask ground;
        [SerializeField] private GameObject eyes;
        [HideInInspector]
        private bool isHiding;

        private void Start()
        {
            isHiding = false;
        }
        private void Update()
        {
            if (Physics2D.OverlapCircle(frontCheck.position, 0.2f, ground) || Physics2D.OverlapCircle(backCheck.position, radius, ground))
            {
                isHiding = true;
                eyes.SetActive(false);
            }
            else
            {
                isHiding = false;
                eyes.SetActive(true);
            }
        }

        public bool GetIsHiding { get { return isHiding; } }
    }
}
