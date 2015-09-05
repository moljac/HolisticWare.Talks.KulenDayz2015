using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TestApp
{
	[Activity (Label = "TestApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.button2ndScreen);
			
//			button.Click += delegate
//			{
//				button.Text = string.Format ("{0} clicks!", count++);
//			};

			// button.SetOnClickListener(new ClickListener());	

			return;
		}

		class ClickListener : View.IOnClickListener
		{
			#region IOnClickListener implementation
			public void OnClick (View v)
			{
				throw new NotImplementedException ();
			}
			#endregion
			#region IDisposable implementation
			public void Dispose ()
			{
				throw new NotImplementedException ();
			}
			#endregion
			#region IJavaObject implementation
			public IntPtr Handle
			{
				get
				{
					throw new NotImplementedException ();
				}
			}
			#endregion
		}

		[Java.Interop.Export("sendMessage")]
		public void sendMessage(View view) 
		{
			//Intent intent = new Intent(this, Screen2.class);
			Intent intent = new Intent(this, typeof(Screen2Activity));
			this.StartActivity(intent);
		}

	}
}


