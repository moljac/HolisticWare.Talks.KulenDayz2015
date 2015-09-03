# Intro to Xamarin.Android

Intro to Xamarin.Android w Xamarin.Studio
Intro to Xamarin.Android w Visual Studio

## History

*	Monodroid
*	Mono for Android
*	Xamarin.Adroid

## Agenda

Build Xamarin.Android app:

1.	Create Xamarin.Android project
	1.	Xamarin.Android features
	2.	project types in IDE (overview and creation)
2.	App Decomposition into Activities
3.	Activity UI
4.	Activity Code Behind
5.	Update Android SDK


Definition:

*	Xamarin.Android app is:
	*	an Android native app 
	*	built with Xamarin toolchain
	*	Android native classes wrapped (bound) with Xamarin tools
		extended/advanced PInvoke (interoperability)
	*	code behind: 
		*	.net langueges
			*	c#
				v.5: async/await, Linq, lambdas, anonymous functions and delegates
			*	f#
		*	compiled into 
			*	CIL/MSIL
				*	executed in VM Dalvik and Mono
				*	AheadOfTime (AOT) compiled to ARM code
	*	Xamarin.Android bindings
		*	wrap java API
		*	add .net features (.net/c# idioms)
			*	events 		
				instead of classes for Listener implementations
			*	properties 		
				instead of get/set methods
		*	bindings provided		
			all Android system libraries
			*	java.*
				StringBuffer, Array
			*	android.*
				Button
		*	updates 
			*	within days after google
		*	3rd party java libraries (jars)
			*	Java Binding Lobraries
				*	project type Java Binding Library Project
			*	samples
				*	GIS			
					Esri ArcGIS
				*	financial
					PayPal
				*	mutlimedia:
					*	music
						*	Triton
					*	video
						*	Brigtcove
						*	Ooyala
	*	additional libraries
		Mono/.net classes
		
		
## Project creation:

*	Xamarin.Studio
	*	Mac OSX
	*	Windows
	*	unsupported: Linux
*	Visual Studio

## Android App Architecture

Applies both to Android and Xamarin.Android apps.

Android app:

*	consists of 
	*	Activities that work together to achieve some goal 
		*	with or without UI
		*	Activity
	*	Resources and Assets
		*	Data files
		*	images

		
*	components of Android app:				
		*	Activities		
		*	Intents		
		*	BroadcastReceivers		
		*	Services		
		*	ContentProviders		
		
## Android UI

*	UI consists of:
	*	Views (widgetz/controls)			
		Android.Widgets (android.widget)		
		Button
		TextView
		EditText
		...
	*	widget is Android app pinned to HomeScreen
	*	ViewGroups
		*	Layout panels for sizing and positioning child Views and ViewGroups
			*	calculates size of children
			*	layouts
				*	LinearLayout		
				*	RelativeLayout		
					layout constraints		
				*	GridLayout		
				*	AbsoluteLayout
			*	defined in	
				*	folder: 
					Resources/layout
					res/layout 
				*	xml code	
					*.xml android
					*.axml	Xamarin.Android (BuildAction=)
				*	BuildAction=AndroidResource
		*	Collection Views: Lists, Grids
	
			
		
## Android Project structure

Android (lowercase)

	res/
		drawable/
		drawable-hdpi/
		drawable-mdpi/
		drawable-xhdpi/
		drawable-xxhdpi/
		drawable-xxxhdpi/
		layout/
		values/
			strings.xml
			
Xamarin.Android (uppercase files and some folders)

	Resources/
		drawable/
		drawable-hdpi/
		drawable-mdpi/
		drawable-xhdpi/
		drawable-xxhdpi/
		drawable-xxxhdpi/
		layout/
				MainActivity.xml
		values/
			Strings.xml		
			Colors.xml
			Styles.xml
			

*	in values/	
	symbolic constants, values not hard-coded
	
## UI Designer

*	IDE integration
	*	Xamarin.Studio
	*	Visual Studio
*	features
	*	Drag&Drop
	*	

	
	
	<LinearLayout
		xmlns:android="http://schemas.android.com/apk/res/android"
		android:layout_width="fill_parent" 
		android:layout_height="fill_parent" 
		android:orientation="vertical"
		>
		<!--
			Button, TextView, EditText
			attribute
				android:text 
			sets Text property on object
			
			LinearLayout attribute
				android:orientation
			sets Orientation propert on object
			
			NOTE: Attribute names do not always match property names!
			check google Android docs
		-->
		<Button
			android:id="@+id/addJokeButton"
			android:layout_width="wrap_content"
			android:layout_height="wrap_content"
			android:text="@string/app_name"
		/>
		<EditText
			android:id="@+id/newJokeEditText"
			android:layout_width="match_parent"
			android:layout_height="wrap_content"
			>
		</EditText>
		<TextView
			android:id="@+id/newJokeEditText"
			android:layout_width="fill_parent"
			android:layout_height="wrap_content"
			>
		</TextView>
	</LinearLayout>
	
* 	xml format		
	*	attribute 
		*	prefix: android			
			xmlns:android="http://schemas.android.com/apk/res/android"		
			not required, but common practice		
			can be anything			
		*	required attributes		
			Binary XML file .... must supply ATTRIBUTE attribute
			*	attributes	
				*	layout_width		
				*	layout_height		
			*	common attribute values		
				*	match_parent - size of the parent (stretches)		
					fill_parent - deprecated	
				*	wrap_content - size of the content (smaller than parent)	
			*	size attribute values
				*	options
					*	dp
					*	px		
					*	in			
					*	mm		
					*	pt (1/72\")
				*	not recommended - do not adapt on different scrren sizes
				*	recommended: dp		
					density independent pixels		
					abstract measurement unit (pixels)		
					adapts to physical pixels at runtime based on screen density		
					100dp		
					the goal is to occupy the same area on-screen regardless of density		
					on high resolution display it might occupy more than 100 physical pixels
					baseline density DPI = 160dpi - 1dp = 1px			
					based on 1st android device G1 		
					conversion formula:  px = dp * DPI / 160; 		
					on 200dpi device 100dp is 200px
	*	element prefix: not needed				
		&lt;EditText /&gt;
	
Build proces generates:

		// Resource.designer.cs
		// R.java	
		// identifiers for Resources
		//						Layouts
		//						Views
		//						...
		// NOTE: implies some restrictions
		//		1.	cannot have resources with the same name 
		//			(not even in different folders)
		//				Resource/layout/SomeActivity.axml
		//				Resource/layout/special/SomeActivity.axml	
		//		2.	no double extensions allowed
		//				Resource/layout/SomeActivity.axml
		//				Resource/layout/SomeActivity.test.axml	
		public partial class Resource
		{
			public partial class Layout
			{
				public const int main_activity = 201010202;
			}
		}
	
	
## Activity

		[Activity/*Attribute*/
			// Attributes are used for AndroidManifest.xml
			// to generate Elements and Attributes
			(
				MainLauncher = true,		// entry point like main
				Label="SampleActivity",		// displayed on scrren when activity is running
				Icon="@drawable/icon"		// Activity Icon
			)
		]
		public partial class SampleActivity
		{
			// Initialization
			// ctors 
			//	*	allowed and run before OnCreate
			//	*	not common
			//	bundle is neccessary in cases when Android destroys activity and
			//	recreates new one (savedInstanceState), like during rotation
			//  . Android saves state in Bundle
			protected override void OnCreate(Bundle bundle)
			
			{
				// required - otherwise exception
				base.OnCreate(bundle);
				
				// UI loading - not required
				SetContentView(Resource.Layout.main_activity);
				
				return;
			}
		}
		
		
### Id

Android.Views.View class defines Id property for unique identification of the View 
in layout at runtime.

	namespace Android.Views
	{
		public partial class Activity
		{
			public virtual int Id
			{
				get;
				set;
			}
		}
	}

		
Set Id in xml using id attribute;

	<Edittext android:id="@+id/digitsInput" />
	
	
Build tools generate Id in Resource class and loads integer into Views Id

	namespace Android.Views
	{
		public partial class Resource
		{
			public partial class Id
			{
				public const int digitsInput = 201010202;
			}
		}
	}

Usage in code behind:

		[Activity/*Attribute*/
			(
				MainLauncher = true		// entry point like main
			)
		]
		public partial class Activity
		{
			EditText et;
			TextView tv;
			Button b;
			
			protected override void OnCreate(Bundle bundle)
			{
				// required - otherwise exception
				base.OnCreate(bundle);
				
				// UI loading - not required
				SetContentView(Resource.Layout.main_activity);

				// FindView cannot be used before SetContentView
				var et1 = FindViewById<EditText>(Resource.Id.digitsInput);
							
				return;
			}
		}
	
All views which need to be accessed from code (outside) in UI xml declaration/definition
must have Id (android:id) defined

		<EditText
			android:id="@+id/editTextNameLast"
			/>
		<Button
			android:id="@+id/buttonSubmit"
			/>

Code behind:


		[Activity/*Attribute*/
			(
				MainLauncher = true		// entry point like main
			)
		]
		public partial class Activity
		{
			EditText et;
			Button b;
			
			protected override void OnCreate(Bundle bundle)
			{
				// required - otherwise exception
				base.OnCreate(bundle);
				
				// UI loading - not required
				SetContentView(Resource.Layout.main_activity);

				// FindView cannot be used before SetContentView
				et = FindView<EditText>(Resource.Id.editTextNameFirst);
				tv = FindView<TextView>(Resource.Id.tv);
				b = FindView<Button>(Resource.Id.buttonSubmit);

				b.OnClick += OnClick;
				
				return;
			}
			
			void OnClick(object sender, EventArgs ea)
			{
				return;
			}
		}



Xamarin.Android wraps/uses following libraries:

*	native Java libraries			
	Java.* namespace		
	java.* package		
*	native Android java libraries - Android SDK			
	Android.* namespace		
	android.* package	
*	native Android c/c++ libraries - Android NDK
*	managed Mono libraries	

Updates necessary in order to target new versions:

*	Android SDK
*	Android NDK

*	Java Development Kit JDK
	*	used for building java apps		
		*	collection of 		
			*	libraries
			*	tools
		*	components	
			*	library packages		
				java.*		
			*	tools (used in Android build process)		
				*	compiler		
				*	jarsigner		
				*	decompiler		
			*	runtime		
				*	virtual machine JVM 
				*	libraries			
			*	docs and samples	
			*	source code		
*	Android SDK
	*	used for creating and running native java Android apps 
	*	components
		*	core java libraries		
			*	java.* packages			
			*	android.* packages			
		*	Google APIs	
			*	optional			
			*	components:
				*	calendar
				*	google mail access		
		*	tools (build tools)
			*	bytecode compiler	
			*	runtime tools		
				*	debug tools		
		*	docs and samples	
		*	emulator images
*	Android NDK 
	*	collection of code, libraries and tools for writing Android apps in c and c++
	*	not used very often - mostly for perfomrance
	*	increases complexity
	*	increases perfomrance (higher speed, smaller memmory footprint)		
	*	fore reusing c/c++ codebase
*	Mono Development Kit MDK
	*	Mono is open source implementation of .net framework
	*	several parts are used in Xamarin.Android development
	*	components
		*	managed .net libraries			
			*	Bace Class Libraries		
				System.*
			*	Mono Class Library		
				not used in Xamarin.Android		
		*	Mono runtime
			*	executes IL (CIL/MSIL)		
		*	compilers c#		
		
Process

1.	*.java source code is compiled into Dalvik bytecode *.dex 		
	bytecode is analogous to .net intermediate language IL (CIL/MSIL)		
	dex - Dalvik Executable format
2.	steps
	1.	*.java => java compiler => *.class	 	
		java source code compiled to btytecode		
	2.	*.class bytecode => Android dex compiler => *.dex		
		bytecode is compiled by Android dex compiler to Dalvik bytecode		
	3. *.dex and Resources => Android apk builder => .apk file/bundle/archive		
		dex files and resources are bundled by apk builder into apk file	
		apk - zip archive		
	4.	2 steps for releasing = deploying on App Store		
		not needed for local deployment on device or emulator (Debug build)
		1.	signing with jarsigner
		2.	optimizations with zipalign		
3.	to run/execute app	
	1.	app must be deployed/uploaded onto device/emulator	
	2.	new deployment v.5+ (Android Lollipop)
		1.	bytecode *.dex is compiled into native code during installation time		
			AOT Ahead of Time compilation		
		2.	Android Runtime ART	
			sandboxed apps
	3. 	old deployment < v.5	
		1.	dex files were not compiled to native
		2.	dex files were executed in Dalvik VM (optimized JVM)	
4.	Xamarin.Android process		
	1.	*.cs code is compiled by c# compiler into managed assemblies			
		manged assembly containes IL and metadata (eventually resources)		
	2.	Xamarin.Android Linking
		1.	linked/stripped assemblies:
			1.	users assemblies from step 1.
			2.	mono managed assemblies (System.*)		
				mscorlib, System.*.dll				
		2.	linker removes unused IL code from			
		3.	resulting in filtered assemblies - smaller size		
		4.	similar to strip tool		
		5.	possible problems with reflection		
		6.	contolling linker process	
			1.	project settings - disabling linking for	
				1.	everything	
				2.	SDK code	
				3.	users code	
			2.	PreserveAttribute for specific classes/types  		
	3.	Mono runtime 
		1.	execution of stripped/filtered assemblies	
		2.	mono runtime is added with android build tools apkbuilder to .apk file		
	4.	Mono VM  
		1.	runs in parallel with Dalvik VM/ and/or Android ART	but executes code
			1.	running code from .net libraries and user's code			
		2.	on top of linux kernel
	5.	Dalvik VM and/or Android ART 
		1.	runs in parallel with Mono RT but executes 
			1.	only Android dex code			
				1.	java.*		
				2.	android.*
		2.	on top of Linux kernel			
		