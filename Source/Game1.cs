using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using FontBuddyLib;
using GameTimer;
using HadoukInput;

namespace DeadZoneTest
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		#region Members

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		/// <summary>
		/// A font buddy we will use to write out to the screen
		/// </summary>
		private FontBuddy _text = new FontBuddy();
		
		/// <summary>
		/// THe controller objects we gonna use to test
		/// </summary>
		private DeadZoneSample[] _controllers;

		/// <summary>
		/// The input that will be passed to the controller wrpapers
		/// </summary>
		private InputState m_Input = new InputState();

		#endregion //Members

		#region Methods

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
			Content.RootDirectory = "Content";
			graphics.PreferredBackBufferWidth = 1024;
			graphics.PreferredBackBufferHeight = 768;
			graphics.IsFullScreen = false;
			
			_controllers = new DeadZoneSample[(int)DeadZoneType.PowerCurve + 1];
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			_text.LoadContent(Content, "ArialBlack10");

			for (int i = 0; i < ((int)DeadZoneType.PowerCurve + 1); i++)
			{
				Vector2 position = Vector2.Zero;

				//y position is center of screen
				position.Y = (graphics.GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

				//slice up screen so each dead zone drawn in its own thing
				float xSlice = graphics.GraphicsDevice.Viewport.TitleSafeArea.Width / ((int)DeadZoneType.PowerCurve + 1);
				position.X = (i * xSlice) + (xSlice * 0.5f);

				//x position is 
				_controllers[i] = new DeadZoneSample((DeadZoneType)i, position);
			}
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
			    Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
			{
				this.Exit();
			}

			//Update the controller
			m_Input.Update();
			foreach (DeadZoneSample controller in _controllers)
			{
				controller.Update(m_Input);
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			
			spriteBatch.Begin();

			//draw the current state of each controller
			foreach (DeadZoneSample controller in _controllers)
			{
				controller.Draw(_text, spriteBatch, GraphicsDevice);
			}
			
			spriteBatch.End();
			
			base.Draw(gameTime);
		}

		#endregion //Methods
	}
}
