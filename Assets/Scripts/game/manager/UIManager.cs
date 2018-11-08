using strange.extensions.mediation.api;
using UnityEngine;

namespace com.ztgame.ioc
{
    public class UIManager
    {
        private Canvas canvas;
        public UIManager()
        {
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        }
        public IView show(string name)
        {
            UnityEngine.Debug.Log("show ui:" + name);

            GameObject go = GameObject.Instantiate(Resources.Load("Prefab/" + name)) as GameObject;
            go.transform.SetParent(canvas.gameObject.transform,false);
            return null;
        }
    }
}