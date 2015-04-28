using System;

using UnityEngine;

using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

namespace Demo {
	public class SignalContext : MVCSContext {
		
		/**
         * Constructor
         */
		public SignalContext (MonoBehaviour contextView) : base(contextView) {
		}
		
		protected override void addCoreComponents() {
			base.addCoreComponents();
			
			// bind signal command binder
			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}
		
		public override void Launch() {
			base.Launch();
			Signal startSignal = injectionBinder.GetInstance<StartSignal>();
			startSignal.Dispatch();
		}

		
	}
}