using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace com.ztgame.ioc
{
    public class EntryView : EventView
    {
        public const string CLICK_TEXT = "CLICK_TEXT";
        private Button changeBtn;
        private Text changeText;
        internal void init()
        {
            changeBtn = transform.Find("Button").GetComponent<Button>();
            changeText = transform.Find("Text").GetComponent<Text>();
            changeBtn.onClick.AddListener(onClickChange);
        }

        private void onClickChange()
        {
            dispatcher.Dispatch(CLICK_TEXT,2.1);
        }
        public void setChangeText(string text)
        {
            changeText.text = text;
        }
    }
}