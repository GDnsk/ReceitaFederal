using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ReceitaFederal.Services
{
    public class CPNJBaseParser
    {
        public static bool ParseBaseToCSV(string basePath, string outputPath)
        {
            string command = @$"/c python ""{FileService.GetProjectRootPath()}CNPJ_Base_Parser\cnpj.py"" ""{basePath}"" csv ""{outputPath}"" ";
            
            Console.WriteLine("Extracting File...");
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");

            cmdsi.RedirectStandardOutput = true;
            cmdsi.UseShellExecute = false;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);

            cmd.WaitForExit();
            if (cmd.ExitCode == 0)
            {
                Console.WriteLine($"Extraction ended successfully");
                return true;
            }
            else
            {
                Console.WriteLine($"Extraction ended with errors");
                 return false;
            }
        }
    }
}
