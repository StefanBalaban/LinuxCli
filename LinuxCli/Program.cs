using System;
using System.Diagnostics;

namespace LinuxCli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var command = "uhubctl -l 2 -a 0";
            var result = "";
            using (var proc = new Process())
            {
                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \" " + command + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.Start();

                result += proc.StandardOutput.ReadToEnd();
                result += proc.StandardError.ReadToEnd();

                proc.WaitForExit();
            }

            Console.WriteLine("USB Hub is on");
        }
    }
}