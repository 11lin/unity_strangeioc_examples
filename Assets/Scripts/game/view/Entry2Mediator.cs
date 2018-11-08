using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace com.ztgame.ioc
{

    public class Entry2Mediator : EventMediator
    {
        [Inject]
        public Entry2View view {get;set;}

        public override void OnRegister()
        {
            dispatcher.AddListener(GameEvent.SET_CHANGE_TEXT,onEventSetText);
            view.dispatcher.AddListener(Entry2View.START_CLICK, onClickChangeText);
            view.init();
        }

        private void onEventSetText(IEvent evt)
        {
            view.setChangeText(evt.data.ToString());
        }

        private void onClickChangeText(IEvent evt)
        {
            dispatcher.Dispatch(GameEvent.TO_VIEW_3);
        }

        public override void OnRemove()
        {
            view.dispatcher.RemoveListener(EntryView.CLICK_TEXT,onClickChangeText);
            dispatcher.RemoveListener(GameEvent.SET_CHANGE_TEXT, onEventSetText);
        }
    }
}