using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace com.ztgame.ioc
{
    public class Entry2View : EventView
    {
        public const string START_CLICK = "START_CLICK";
        private Button changeBtn;
        private Text changeText;
        internal void init()
        {
            changeBtn = transform.Find("Button").GetComponent<Button>();
            changeText = transform.Find("Text").GetComponent<Text>();
            changeBtn.onClick.AddListener(onClickStart);
        }

        private void onClickStart()
        {
            dispatcher.Dispatch(START_CLICK);
        }
        public void setChangeText(string text)
        {
            changeText.text = text;
        }
    }
}