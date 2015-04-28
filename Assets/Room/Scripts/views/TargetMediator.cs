using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using strange.extensions.context.impl;

namespace Demo { 
    public class TargetMediator : Mediator
    {

        [Inject]
        public TouchpadInputSignal<TouchEvent> touchInputSignal { get; set; }

        [Inject]
        public TargetView view { get; set; }


		// Use this for initialization
		public override void OnRegister()
		{
			touchInputSignal.AddListener(InputHandler);
		}
		
		override public void OnRemove()
		{
			touchInputSignal.RemoveListener(InputHandler);
		}
		
		
		protected void InputHandler(TouchEvent inputType){
			
			view.receivedInteraction(inputType);
		}
    }
}

