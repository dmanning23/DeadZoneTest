using System;
using HadoukInput;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using FontBuddyLib;
using Microsoft.Xna.Framework.Graphics;

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
		public Vector2 Position { get; set; }

		#endregion //Members

		/// <summary>
		/// Initializes a new instance of the <see cref="DeadZoneTest.Windows.DeadZoneSample"/> class.
		/// </summary>
		/// <param name="eDeadZone">E dead zone.</param>
		/// <param name="position">Position.</param>
		public DeadZoneSample(DeadZoneType eDeadZone, Vector2 position)
		{
			Controller = new ControllerWrapper(PlayerIndex.One);
			Controller.Thumbsticks.ThumbstickScrubbing = eDeadZone;
			this.Position = position;
		}

		/// <summary>
		/// Update the specified input, called once every frame
		/// </summary>
		/// <param name="input">Input.</param>
		public void Update(InputState input)
		{
			Controller.Update(input);
		}

		/// <summary>
		/// Draw the dead zone sample.  
		/// This will draw a circle for the thumbstick, the current thumbstick location as a white circle, the deadzone
		/// The type of dead zone scrubbing will be written above the diagram
		/// </summary>
		/// <param name="text">Text.</param>
		/// <param name="mySpriteBatch">My sprite batch.</param>
		public void Draw(FontBuddy text ,SpriteBatch mySpriteBatch)
		{
			//TODO: draw this thing
		}
	}
}

