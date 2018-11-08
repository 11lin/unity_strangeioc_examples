using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace com.ztgame.ioc
{

    public class EntryMediator : EventMediator
    {
        [Inject]
        public EntryView view {get;set;}

        public override void OnRegister()
        {
            dispatcher.AddListener(GameEvent.SET_CHANGE_TEXT,onEventSetText);

            view.dispatcher.AddListener(EntryView.CLICK_TEXT, onClickChangeText);
            view.init();
        }

        private void onEventSetText(IEvent evt)
        {
            view.setChangeText(evt.data.ToString());
        }

        private void onClickChangeText(IEvent evt)
        {
            dispatcher.Dispatch(GameEvent.TO_VIEW_2);
        }

        public override void OnRemove()
        {
            view.dispatcher.RemoveListener(EntryView.CLICK_TEXT,onClickChangeText);
            dispatcher.RemoveListener(GameEvent.SET_CHANGE_TEXT, onEventSetText);
        }
    }
}