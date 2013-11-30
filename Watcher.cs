using System;
using System.IO;
using System.Security.Permissions;

namespace FaceRecogService
{
    public class Watcher
    {
        public Watcher()
        {
            Run();
        }
        public static FileSystemWatcher watcher;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run()
        {
            
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            watcher.Path = "C:\\ImageProcessing\\Images\\Detected\\";
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.jpg";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        // Define the event handlers. 
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            MailingModule mm = new MailingModule();
            mm.sendMailModule(e.FullPath, true);
            mm = null;
            GC.Collect();
        }

    }
}