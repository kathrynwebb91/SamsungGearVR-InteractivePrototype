using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using strange.extensions.context.impl;

namespace Demo { 
    public class ProductDisplayMediator : Mediator
    {

        [Inject]
        public TouchpadInputSignal<TouchEvent> touchInputSignal { get; set; }

        [Inject]
		public ProductDisplayView view { get; set; }
	
    }
}

