using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    public class HellShit : MonoBehaviour
    {
        private List<GameObject> _chessList;
    
        // Start is called before the first frame update
        void Start()
        {
            var blackChessParent = GameObject.Find("BlackChess");

            _chessList = new List<GameObject>();
            foreach (var child in blackChessParent.GetComponentsInChildren<Transform>())
                if (child.gameObject.name != "BlackChess")
                {
                    Debug.Log(child.gameObject);
                    _chessList.Add(child.gameObject);
                }
            
            StartCoroutine(nameof(ShootChess));
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private IEnumerator ShootChess()
        {
            foreach (var chess in _chessList)
            {
                chess.GetComponent<Rigidbody>().AddForce(0, 0, 1000, ForceMode.Force);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
