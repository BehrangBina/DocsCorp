

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace DocsCorp.StepDefinition
{
    [Binding]
    class CMDEnvStepDefinition
    {
        private string _usercommand;
        [Given(@"user-command is configured in Environment variable")]
        public void GivenUser_CommandIsConfiguredInEnvironmentVariable()
       
        {
            var  environmentVariables =Enum.GetValues(typeof(EnvironmentVariableTarget));
            bool exists=false;
            foreach (var variable in environmentVariables)
            {
                if (variable.ToString() == "user-command")
                {
                    exists = true;
                }
            }
            if(!exists) Environment.SetEnvironmentVariable("user-command", "echo");
            _usercommand = Environment.GetEnvironmentVariable("user-command");

        }
        [Then(@"can echo (.*)")]
        public void ThenCanEchoTempMessage(string message)
        {
       
            using (Process process = new Process())
            {
                process.StartInfo.FileName = $@"resources\{_usercommand}.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.Arguments = message;
                process.Start();

                // Synchronously read the standard output of the spawned process.
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();

                // Write the redirected output to this application's window.
                Console.WriteLine(output);
                Assert.AreEqual(output, message+"\n");
                
                process.WaitForExit();
            }


        }



    }
}
