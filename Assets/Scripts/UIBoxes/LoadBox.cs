using UnityEngine;

namespace UIBoxes
{
    public class LoadBox
    {
        public readonly GameObject BoxCanvas;
        
        public LoadBox()
        {
            var canvasParent = GameObject.Find("MainCanvas");
            var boxCanvasPrefab = Resources.Load<GameObject>("Prefabs/UI/UI_LoadBox");
            
            BoxCanvas = Object.Instantiate(boxCanvasPrefab, canvasParent.transform);
            HideBox();
        }
        
        public void ShowBox()
        {
            BoxCanvas.SetActive(true);
        }

        public void HideBox()
        {
            BoxCanvas.SetActive(false);
        }
    }
}