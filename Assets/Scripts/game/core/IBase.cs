using System;

namespace com.ztgame.ioc
{
    public interface IBase
    {
        string name {set;get;}
        void onInit();
        void onUpdate();
        void onFixUpdate();
    }
}