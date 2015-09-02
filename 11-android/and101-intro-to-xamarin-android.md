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
			android:layout_width="fill_parent"
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
			*	layout_width		
			*	layout_height			
	*	element prefix: not needed
		&lt;EditText /&gt;
	