using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;

namespace com.ztgame.ioc
{
    public class AppContext : MVCSContext
    {
        public AppContext(MonoBehaviour view) : base(view)
        {

        }

		protected override void mapBindings()
		{
			injectionBinder.Bind <EntryData>().ToSingleton();
            injectionBinder.Bind <UIManager>().ToSingleton();

			commandBinder.Bind (ContextEvent.START).To<StartAppCommand>().To<StartGameCommand>().Once();
            mediationBinder.Bind<EntryView>().To<EntryMediator>();
            mediationBinder.Bind<Entry2View>().To<Entry2Mediator>();
            mediationBinder.Bind<Entry3View>().To<Entry3Mediator>();

			commandBinder.Bind(GameEvent.CHANGE_TEXT).To<ChangeTextCommand>();
			commandBinder.Bind(GameEvent.TO_VIEW_2).To<ToView2Command>();
            commandBinder.Bind(GameEvent.TO_VIEW_3).To<ToView3Command>();
        }
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>(); //Unbind to avoid a conflict!
            injectionBinder.Bind<ICommandBinder>().To<EventCommandBinder>().ToSingleton();
        }		
    }
}