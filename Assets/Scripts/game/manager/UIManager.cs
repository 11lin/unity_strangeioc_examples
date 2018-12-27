using strange.extensions.mediation.api;
using UnityEngine;

namespace com.ztgame.ioc
{
    public class UIManager : ManagerBase
    {
        public static UIManager instance = new UIManager();
        private Canvas UICanvas;
        private UIJoystick joystick;

        override public string name
        {
            get
            {
                return "UIManager";
            }
        }        
        private UIManager()
        {

        }
        override public void onInit()
        {
            base.onInit();
            UICanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
            joystick = GameObject.Find("UICanvas/UIJoysick").GetComponent<UIJoystick>();
        }
        public UIJoystick getJoystick()
        {
            return joystick;
        }
        public IView show(string name)
        {
            UnityEngine.Debug.Log("show ui:" + name);

            GameObject go = GameObject.Instantiate(Resources.Load("Prefab/" + name)) as GameObject;
            go.transform.SetParent(UICanvas.gameObject.transform,false);
            return null;
        }
    }
}