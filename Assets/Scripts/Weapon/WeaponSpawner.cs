using System.Collections;
using UnityEngine;

namespace AD.General
{
    public class WeaponSpawner : MonoBehaviour
    {
        [SerializeField] GameObject _swordInHand;
        [SerializeField] GameObject _swordInSheathe;

        private void Start()
        {
            _swordInHand.SetActive(false);
        }

        public void SpawnWeaponInHand()
        {
            _swordInHand.SetActive(true);
            _swordInSheathe.SetActive(false);
        }

        public void SpawnWeaponInSheathe()
        {
            _swordInHand.SetActive(false);
            _swordInSheathe.SetActive(true);
        }
    }
}