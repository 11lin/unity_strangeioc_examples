using System.Collections.Generic;

namespace com.ztgame.ioc
{
    class ManagerCenter : IBase
    {
        public static ManagerCenter Instance = new ManagerCenter();
        private ManagerCenter()
        {

        }
        protected Dictionary<string, ManagerBase> mgrDict = new Dictionary<string, ManagerBase>();

        public string name
        {
            get
            {
                return "ManagerCenter";
            }
            set {}
        }

        public void AddManager(ManagerBase mgr)
        {
            ManagerBase outMgr;
            if(mgrDict.TryGetValue(mgr.name,out outMgr))
            {
                mgrDict.Remove(mgr.name);
            }
            mgrDict.Add(mgr.name,mgr);
        }
        public void onFixUpdate()
        {
            
        }

        public void onInit()
        {
            foreach (var item in mgrDict)
            {
                item.Value.onInit();
            }
            UnityEngine.Debug.Log(name + " -> onInit");
        }

        public void onUpdate()
        {
            
        }
    }
}