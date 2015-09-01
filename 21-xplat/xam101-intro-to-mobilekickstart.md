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

*	Preprocessor Directives == Conditional Compilation
	# if __ANDROID__ || __IOS__ ||
	*	macros/defines:
		*	__ANDROID__
		*	__IOS__
		*	__MOBILE__
			__ANDROID__ && __IOS__
		*	WINDOWS_PHONE		
		*	SILVERLIGHT			
		*	Platforms:		
			*	Windows Phone 7 = WINDOWS_PHONE && SILVERLIGHT		
	*	partial classes and methods
	*	class mirroring
	
	