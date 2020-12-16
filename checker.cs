//check if is running
        public bool amiRunning(){
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                //MessageBox.Show("Another instance of this application is running.");
                
                return true;
            }
        }

// check admin or root
        public bool amiAdmin(){
            bool isElevated;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return isElevated;
        }

// set and check autostart -- non testato

        private void setAutostart(bool enable)
        {
            if (enable)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Application.ProductName,
                    string.Format("\"{0}\" " + "-startup", Application.ExecutablePath));

            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, "");
            }
        }
            