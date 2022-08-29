using UnityEngine;

namespace DeathLight.EnemyServices
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private float waitTime;

        private void Update()
        {
            if (Time.time > waitTime)
            {
                Destroy(gameObject);
            }
        }

    }
}
