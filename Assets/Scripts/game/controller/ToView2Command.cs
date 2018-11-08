using strange.extensions.command.impl;

namespace com.ztgame.ioc
{
    public class ToView2Command : EventCommand
    {
        [Inject]
        public UIManager uiMgr {get;set;}
        
        public override void Execute()
        {
            uiMgr.show("Entry2View");
        }
    }
}