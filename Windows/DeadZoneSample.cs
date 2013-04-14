using System;
using HadoukInput;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DeadZoneTest.Windows
{
	/// <summary>
	/// This is a class for drawing the deadzone of a controller.
	/// </summary>
	public class DeadZoneSample
	{
		#region Members

		/// <summary>
		/// The controller we are going to draw the deadzone for
		/// </summary>
		/// <value>The controller.</value>
		public ControllerWrapper Controller { get; private set; }

		/// <summary>
		/// where this deadzone example is going to be draw on the screen.
		/// This is the very center of the thing
		/// </summary>
		/// <value>The location.</value>
		public Vector2 Location { get; set; }

		#endregion //Members
		
		public DeadZoneSample(DeadZoneType eDeadZone)
		{
			Controller = new ControllerWrapper(PlayerIndex.One);
		}
	}
}

