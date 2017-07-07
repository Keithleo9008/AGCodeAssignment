This application was built as a simple console app in C# due to the simplicity of the requirement. This program can be launched using the command line and passing the name of the two input files in as arguments. The firectory of these files has been fixed (for no reason other than simplicity) and only the name of the files can be changed. I.e The files must always be stored in the "Files" directory in the root folder of the .exe

<br/>
<h1>Application Architecture</h1>

![alt text](CodeAssignment/Help/ArchDiagram.png "Application Architecture")

<h2>Some points on the architecture</h2>
<ol>
  <li>Abstract class used to handle file inputs that could be used to create a generic repository, with each new file the "Process" method must be overrideen in the new implentation</li>
  <li>Service layer created to abstract data logic from application logic, ie files could be replaced with api feed. This implementation of this service would normally injected as a dependency using IoC</li>
  <li>Basic exception handling done</li>
  <li>No Logging as this is a small console application</li>
</ol>

<h1>How To Launch</h1>

<h2>Cloning The Repo</h2>
By cloning this repo, building the project and then running the exe from the command line and passing the two arguments
E.g.


<h2>Launching the precompiled verision</h2>
<ol>
  <li>Download the file "xxxx"</li>
  <li>Run from Command line</li>
</ol>

<h2>Debug in Visual Studio</h2>
<ol>
  <li>Download the Repo</li>
  <li>Open the project/li>
  <li>Make surevthe default arguments have been sett/li>
  <li>Debug</li>
</ol>

<h1>Assumptions</h1>
