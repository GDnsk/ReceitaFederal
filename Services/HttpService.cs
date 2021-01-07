using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Http;
using System.IO;

namespace ReceitaFederal.Services
{
    public static class HttpService
    {
        /// <summary>
        /// Download File from uri and returns path
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>Downloaded File Path</returns>
        public static string DownloadFile(Uri uri)
        {
            WebClient myWebClient = new WebClient();
            Console.WriteLine("Downloading File .......\n\n");
            myWebClient.DownloadFile(uri, $"{FileService.GetProjectRootPath()}/download/cnpjBase.zip");
            Console.WriteLine("Successfully Downloaded File");
            return $"{FileService.GetProjectRootPath()}/download/cnpjBase.zip";
        }
    }
}
