using strange.extensions.command.impl;

namespace com.ztgame.ioc
{
    public class StartAppCommand : Command
    {
        public override void Execute()
        {
            // 初始化
            UnityEngine.Debug.Log("StartAppCommand...");
        }
    }
}