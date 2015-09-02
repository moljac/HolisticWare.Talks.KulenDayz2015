# Into to Mobile Development

Mobile Kickstart

*	sharing code:
	*	linking/sharing code files *.cs
	*	portable class libraries
	*	shared/cross-platform components
	
## Shared Components

*	shareable code
	*	platform agnostic/independent
		excluded:
		*	filesystem (serialization)	
			organization of file system 		
			single rooted	(unix like) 
			multi rooted/forest (windows c:\ d:\)
		*	hardware specific 	
			*	input devices
				*	sensors		
				*	cameras		
			*	output devices		
				*	screens		
				*	audio
	*	non-shareable code (platform specific)
		10-30% [0%-70%]		
		difficult to avoid		
		Xamarin is native tecch ->  few % platform code			
	*	origins		
		*	application code 	
		*	reusable packages/components		
			*	Xamarin.*
				Xamarin.Auth		
				Xamarin.Social		
				Xamarin.Mobile		
			*	dotnetfoundation		
			*	Xamarin plugins			
			*	Xamarin.Forms		
				*	Line of Business (Enterprie) apps		
					mostly data display		
					no complex UI (possible but difficult)		
					PCL/SharedProjects for XAML pages and controls	(UI)		
*	nuget
*	Xamarin Components


Data Access Sharing

*	SQL Lite
*	cloud services		
	Azure	
	Amazon Web Services		
	Dropbox
*	Entity Framework 7
	Xamarin support
*	Web/HTTP Service API if component is missing		
	*	HttpClient for REST
		*	serialzation 
			*	System.Xml		
			*	System.Json		
			*	Newtonsoft.Json		
			*	Linq to XML
		*	components or nuget packages			
			*	ServiceStack
			*	RESTSharp
			*	Hammock
	*	SOAP
		*	WebServices asmx
		*	WCF		
			Business license Xamarin	
		
##	Distribution

### Nuget

*	[http://nuget.org](http://nuget.org)
*	Xamarin.Forms
*	not moderated		
*	prerelease

### Xamarin Component Store

*	[http://components.xamarin.com](http://components.xamarin.com)
*	moderated/validated		
*	samples
*	slightly older code

## Code Sharing 

*	Business Logic POCOs
*	network HTTP/WebServices
*	parsing	
	string -> char[] -> MemoryStream
*	check repetiton code (copy/paste)


## Demo

*	Xamarin.Studio	
	*	nuget			
		*	package restore		
		*	packages.config		
			source control
	*	components		
	
	
	
## Sharing Source Code

*	greatest common denominator principle
*	file linking/sharing	
	*	Project Linker	
		Microsoft Prism Project	- code sharing WP, Silverlight and WPF
	*	productivity tools:
		*	VSCommands		
*	Shared [Asset] Project		
	Visual Studio 2013 Update 2 
	unification for Windows Phone and Windows Store rpojects		
	file linking on stereoids
	*	no output - no binaries
	*	must be added to some other project
	*	link source project in Project Linker
	
	
### Platform Specific Code Strategies

Language and Compiler Technologies

Preprocessor Directives == Conditional Compilation

	*	macros/defines
	*	partial classes and methods
	*	class mirroring

#### macros/defines

	# if __ANDROID__ || __IOS__ ||
		
defines:

	__ANDROID__
	__IOS__
	__MOBILE__
	__ANDROID__ && __IOS__
	WINDOWS_PHONE		
	SILVERLIGHT			
	
Platforms:		

	Windows Phone 7 = WINDOWS_PHONE && SILVERLIGHT		
	
Sample:	
	
	public static string DatabaseFilePath 
	{
		get 
		{
			var filename = "MwcDB.db3";
			
			#if SILVERLIGHT
			var path = filename;
			#else
				#if __ANDROID__
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
				#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library");
				#endif
			var path = Path.Combine (libraryPath, filename);
			#endif
			
		return path;		
	}	
		
		
		
Disadvantages: maintanability, readibility

#### Class mirroring

Classes that implement the same infterface with different platform code.

Common/shared code:

	Alert.Show("Success!", "Backup coplete");
	
Xamarin.Android:

	public class Alert
	{
		public void Show(string title, string message)
		{
			new AlertDialog.Buider(Application.Context)
					.SetTitle(title)
					.SetMessage(message)
					;
					
			return;
		}
	}
	
Xamarin.iOS:

	public class Alert
	{
		public void Show(string title, string message)
		{
			new UIAlertView
					(
					  title,
					  message,
					  null,
					  "OK"
					)
					.Show();
					
			return;
		}
	}	
	
	
### partial classes and methods

partial classes

*	variant of Class Mirroring.
*	splitting source code across several files
	*	used a lot in generated code
		XAML, etc
	*	platform specific code in files extracted to platform project/libraries

partial methods:

	*	non existing code is removed from the call
		*	pre processing		
			customized initialization
		*	post processing
	
### Files with data

*	Android		
	Assets/ folder	
	BuidlAction=AndroidAsset
*	iOS		
	Resource/ folder	
	BuidlAction=BundleResource

	
## Portable Class Libraries PCLs

*	Class Libraries
	*	tied to runtime:
		*	platform
			desktop, Windows Phone, Silverlight, ...
		*	.net framework version
			3.5, 4.0, 4.5 ...
	*	cannot be shared
*	Portable Class Libraries
	*	not directly tied to platform 
	*	intersection of the API
		*	usually: more platforms -> less APIs (more restrictions)
		*	thus choose minimal set of platforms (can be added later)		
	*	binary output created (assemblies)
	*	profile based on selection of platforms
		*	list of profiles controlled/moderated by Microsoft
		*	
	
Available:
	
	Stream
	StreamReader
	MemoryStream

Not available:

	File
	Directory
	
PCL and platform specific code strategies:

	*	Events
	*	Callbacks
	*	Dependency Injection
	*	Factories
	

### Events

For simple cases.

Portable code:

	public class ApiConsumerPortable
	{
		public event bool DoSomething (string);
		
		public void PerformDoSomething(string s)
		{
			if (DoSomething(s))
			{
			}
		}
	}

Platform code:

	public class ApiImplementationPlatform
	{		
		public void UsePerformDoSomething(string s)
		{
			ApiConsumerPortable a = new ApiConsumerPortable();

			a.DoSomething += 
				(s) =>
				{
					new UIAlertView (s, "Do something", null, "OK!");
				}
		}
	}
	
### Platform Abstractions

Complex Requirements description through abstractions implemented by
platform specific code (project).

PCL needs to be informed about implementation.

*	Interfaces

Several techniques:

*	ServiceLocator pattern
	*	singleton with dynamic dependency registration
*	Factory pattern
*	Dependency Injection
	*	most common
	*	supplying concrete implementation through:
		*	constructor
		*	method (initialization method - usually required)
		*	property (get/set method - required)

Process:

1.	xplat code defines interface
2.	platform code implements intreface
3.	xplat code creates object that implements interface from 1.
	1.	ctor
	2.	method
	3.	property

	
*	Shared Projects
	* 	pros
		*	All API available
		*	platform logic added directly (defines used)
		*	all types shared
		*	for smaller teams with all code in solution
		* 	simple build systems		
	*	cons
		*	macros preprocessor directives / conditional compilation
			*	readability
			*	maintainability (spaghetti code)
			*	difficult unit testing
		* 	source code distribution Intellectual Property
*	Portable Class Libraries
	* 	pros
		*	enforces architectural design
		8	binary deployment and distribution (intellectual property)
			*	nuget package manager
		*	unit testable		
	*	cons
		*	limited APIs
		*	difficult platform specific implementations
			*	more effort to implement platform specific features
		