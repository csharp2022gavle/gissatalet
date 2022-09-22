using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace gissatalet.models;

internal class ToFile
{
    public static async Task MainTask(string userScore, string name, string tries)
    {
        string[] textFilePath = await File.ReadAllLinesAsync(Tasks.path);
        List<string> textFile = new(textFilePath);
        if (!textFile.Contains(name))
        {
            string appendText = userScore + " | " + name + " | " + tries + Environment.NewLine;
            await File.AppendAllTextAsync(Tasks.path, appendText);
        }
    }
}
