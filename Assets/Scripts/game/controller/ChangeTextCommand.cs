using strange.extensions.command.impl;

namespace com.ztgame.ioc
{
    public class ChangeTextCommand : EventCommand
    {
        [Inject]
        public EntryData entryData {get;set;} 
        public override void Execute()
        {
            double number = (double)evt.data;
            entryData.number += number;
            dispatcher.Dispatch(GameEvent.SET_CHANGE_TEXT,entryData.number.ToString());
            // 初始化
            UnityEngine.Debug.Log("ChangeTextCommand...");
        }
    }
}