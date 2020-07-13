using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Chess
{
    public class HellShit : MonoBehaviour
    {
        private List<GameObject> _chess1List;
        private List<GameObject> _chess2List;
        private List<GameObject> _chess3List;
        private List<GameObject> _chess4List;
    
        // Start is called before the first frame update
        void Start()
        {
            var chess1 = GameObject.Find("Chess1");
            var chess2 = GameObject.Find("Chess2");
            var chess3 = GameObject.Find("Chess3");
            var chess4 = GameObject.Find("Chess4");

            _chess1List = new List<GameObject>();
            foreach (var child in chess1.GetComponentsInChildren<Transform>())
                if (child.gameObject.name.Contains("Pawn"))
                {
                    Debug.Log(child.gameObject);
                    _chess1List.Add(child.gameObject);
                }
            
            _chess2List = new List<GameObject>();
            foreach (var child in chess2.GetComponentsInChildren<Transform>())
                if (child.gameObject.name.Contains("Pawn"))
                {
                    Debug.Log(child.gameObject);
                    _chess2List.Add(child.gameObject);
                }
            
            _chess3List = new List<GameObject>();
            foreach (var child in chess3.GetComponentsInChildren<Transform>())
                if (child.gameObject.name.Contains("Pawn"))
                {
                    Debug.Log(child.gameObject);
                    _chess3List.Add(child.gameObject);
                }
            
            _chess4List = new List<GameObject>();
            foreach (var child in chess4.GetComponentsInChildren<Transform>())
                if (child.gameObject.name.Contains("Pawn"))
                {
                    Debug.Log(child.gameObject);
                    _chess4List.Add(child.gameObject);
                }

            StartCoroutine(nameof(ShootChess1));
            StartCoroutine(nameof(ShootChess2));
            StartCoroutine(nameof(ShootChess3));
            StartCoroutine(nameof(ShootChess4));
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private IEnumerator ShootChess1()
        {
            for (var i = 0; i < 8; i++)
            {
                if (_chess1List[i] != null)
                    _chess1List[i].GetComponent<Rigidbody>().AddForce(0, 0, 1000, ForceMode.Force);
                
                yield return new WaitForSeconds(0.8f);
            }
        }
        
        private IEnumerator ShootChess2()
        {
            yield return new WaitForSeconds(0.1f);
            
            for (var i = 0; i < 8; i++)
            {
                if (_chess2List[i] != null)
                    _chess2List[i].GetComponent<Rigidbody>().AddForce(-1000, 0, 0, ForceMode.Force);
                
                yield return new WaitForSeconds(0.8f);
            }
        }
        
        private IEnumerator ShootChess3()
        {
            yield return new WaitForSeconds(0.2f);

            for (var i = 0; i < 8; i++)
            {
                if (_chess3List[i] != null)
                    _chess3List[i].GetComponent<Rigidbody>().AddForce(0, 0, -1000, ForceMode.Force);
                
                yield return new WaitForSeconds(0.8f);
            }
        }
        
        private IEnumerator ShootChess4()
        {
            yield return new WaitForSeconds(0.3f);

            for (var i = 0; i < 8; i++)
            {
                if (_chess4List[i] != null)
                    _chess4List[i].GetComponent<Rigidbody>().AddForce(1000, 0, 0, ForceMode.Force);
                
                yield return new WaitForSeconds(0.8f);
            }
        }
    }
}
