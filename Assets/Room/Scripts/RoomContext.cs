using UnityEngine;
using System;
using strange.extensions.context.impl;

namespace Demo{
	public class RoomContext : SignalContext {

		/**
         * Constructor
         */
		public RoomContext(MonoBehaviour contextView) : base(contextView) {
		}
		
		protected override void mapBindings() {
			base.mapBindings();
			
			// we bind a command to StartSignal since it is invoked by SignalContext (the parent class) on Launch()
			commandBinder.Bind<StartSignal>().To<GameStartCommand>().Once();

			// Views
			// bind our view to its mediator
			//mediationBinder.Bind<GuiView>().To<GuiMediator>();
			mediationBinder.Bind<TargetView>().To<TargetMediator>();
			mediationBinder.Bind<PictureFrameView>().To<PictureFrameMediator>();
			mediationBinder.Bind<SecretRoomView>().To<SecretRoomMediator>();
            mediationBinder.Bind<ProductDisplayView>().To<ProductDisplayMediator>();

			// Managers
			// bind our interface to a concrete implementation
			// so when ever something asks for ISomeManager, it will inject a single instance of TestManager.
			injectionBinder.Bind<InputManager>().To<TouchpadInputManager>().ToSingleton();
			injectionBinder.Bind<TouchpadInputSignal<TouchEvent>>().ToSingleton();

		}

        public override void Launch()
        {
            base.Launch();
            InputManager inputManager = injectionBinder.GetInstance<InputManager>();

        }
		
	
	}
}
