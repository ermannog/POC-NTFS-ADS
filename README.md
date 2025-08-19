This VB.NET application based on the .NET Framework 4.8 implements a simple keylogger using Windows Hooks and records the keystroke log to an NTFS Alternate Data Stream of the executable itself.

The Proof of Concept (POC) application creates multiple streams with a unique hash identifier based on the POC start date, the username of the session in which the POC is started, and the computer name on which the POC is running.

The application allows you to start and stop the keylog and open or delete the generated NTFS Alternate Data Streams.
