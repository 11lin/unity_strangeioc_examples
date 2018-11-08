using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

namespace com.ztgame.ioc
{
    public class AppRoot : ContextView
    {
        void Awake()
        {
            context = new AppContext(this);
        }
    }
}