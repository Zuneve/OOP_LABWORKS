namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public class TreeViewSymbolsSettings
{
    public TreeViewSymbolsSettings()
    {
        FileSymbols = "-";
        FolderSymbols = ">";
        IndentSymbols = "   ";
    }

    public TreeViewSymbolsSettings(
        string fileSymbols,
        string folderSymbols,
        string indentSymbols)
    {
        FileSymbols = fileSymbols;
        FolderSymbols = folderSymbols;
        IndentSymbols = indentSymbols;
    }

    public string FileSymbols { get; }

    public string FolderSymbols { get; }

    public string IndentSymbols { get; }
}