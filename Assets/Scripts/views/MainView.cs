using System;

using UnityEngine;

using strange.extensions.context.impl;

namespace Demo {
	public class MainView : ContextView {
		
		void Awake() {
			this.context = new MainContext(this);
		}

	}
}