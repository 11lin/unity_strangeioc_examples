using strange.extensions.command.impl;

namespace com.ztgame.ioc
{
    public class StartGameCommand : Command
    {
        [Inject]
        public UIManager uiMgr {get;set;}
        public override void Execute()
        {
            // 初始化
            UnityEngine.Debug.Log("StartGameCommand...");

            uiMgr.show("EntryView");
        }
    }
}