using strange.extensions.command.impl;

namespace com.ztgame.ioc
{
    public class ToView3Command : EventCommand
    {
        [Inject]
        public UIManager uiMgr {get;set;}
        
        public override void Execute()
        {
            uiMgr.show("Entry3View");
        }
    }
}