using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

public class FileSystemNodeVisitor : IVisitor
{
    private readonly IWriter _writer;

    private readonly int _maxDepth;

    private readonly TreeViewSymbolsSettings _treeViewSymbolsSettings;

    private int _currentDepth;

    public FileSystemNodeVisitor(
        IWriter writer,
        int maxDepth,
        TreeViewSymbolsSettings treeViewSymbolsSettings)
    {
        _writer = writer;
        _maxDepth = maxDepth;
        _currentDepth = 0;
        _treeViewSymbolsSettings = treeViewSymbolsSettings;
    }

    public void Visit(DirectoryFileSystemNode directoryFileSystemNode)
    {
        if (_currentDepth >= _maxDepth)
        {
            return;
        }

        _writer.Write(FormatName(directoryFileSystemNode.Name, true));

        _currentDepth++;

        foreach (IFileSystemNode child in directoryFileSystemNode.Children)
        {
            child.Accept(this);
        }

        _currentDepth--;
    }

    public void Visit(FileFileSystemNode fileFileSystemNode)
    {
        if (_currentDepth >= _maxDepth)
        {
            return;
        }

        _writer.Write(FormatName(fileFileSystemNode.Name, false));
    }

    private string FormatName(string name, bool isDirectory)
    {
        string shift = _treeViewSymbolsSettings.IndentSymbols;
        var builder = new StringBuilder();

        for (int i = 0; i < _currentDepth; i++)
        {
            builder.Append(shift);
        }

        string symbol = isDirectory
            ? _treeViewSymbolsSettings.FolderSymbols
            : _treeViewSymbolsSettings.FileSymbols;
        return $"{builder}{symbol} {name}";
    }
}