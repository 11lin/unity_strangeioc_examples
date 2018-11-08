using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace com.ztgame.ioc
{

    public class Entry3Mediator : EventMediator
    {
        [Inject]
        public Entry3View view {get;set;}

        public override void OnRegister()
        {
            dispatcher.AddListener(GameEvent.SET_CHANGE_TEXT,onEventSetText);

            view.dispatcher.AddListener(Entry3View.START_CLICK, onClickChangeText);
            view.init();
        }

        private void onEventSetText(IEvent evt)
        {
            view.setChangeText(evt.data.ToString());
        }

        private void onClickChangeText(IEvent evt)
        {
            dispatcher.Dispatch(GameEvent.CHANGE_TEXT, evt.data);
        }

        public override void OnRemove()
        {
            view.dispatcher.RemoveListener(Entry3View.START_CLICK,onClickChangeText);
            dispatcher.RemoveListener(GameEvent.SET_CHANGE_TEXT, onEventSetText);
        }
    }
}