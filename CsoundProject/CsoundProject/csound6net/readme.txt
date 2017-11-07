Csound is a library of tools for generating and processing digital sound.

It is hosted by applications as simple as a command line processor or as complex as a full-featured gui front end.  These applications are built using bridges from many languages like python, java and c++.  Take a look at Csound Frontends for a list of some of these.

The csound6netlib.dll contains the object wrappers that expose the csound “c” API in a format idiomatic to C# and other DotNet CLR languages.  It maps “c”-style functions into C# idioms such as classes, properties, enums, IDisposable’s (for “using” blocks), delegates and events.  

Added to the csound’s dll function libraries, the csound6NetLib’s dll class library makes it possible to build host front ends to csound using DotNet languages like C# and VB.  One only need add csound6netlib.dll and msvcrt.dll to csound’s “bin” directory and reference it from your Visual Studio project to begin developing.

--------------------------------------------------------------------------------

Checklist for Setting up a Dot Net Project using csound 6:  

1. Download and install csound 6.01. 

2. Follow csound’s set up instructions:


Csound’s Windows installer should install things in their expected places.   Getting Started with Csound and  Configuring csound may be useful to verify this.


Csound uses several Environment variables which you’ll probably want to set up.  See  Useful environment variables for default behavior

Csound 6 makes use of additional open source audio libraries which it supplies in its bin directory upon installation: libsndfile, portaudio  and portmidi as well as various support gnu libraries.  By default, it expects Python 2.7 to be installed.  If you don’t want to install Python, delete py.dll from csound’s “bin” directory as described here:  Configuring Csound

3. Download and install this project’s csound6netlib.dll and place it in the  bin directory within the directory where you installed csound.  Typically, this is “c:\Program Files (x86)\csound6\bin”.

4. Verify that Microsoft’s c-runtime dll (msvcr110.dll) is present.  With 6.01, it should be present.  Add a copy if it isn’t already there.

5. Create a new project in Visual Studio and add a reference to csound6netlib.dll and start developing.


