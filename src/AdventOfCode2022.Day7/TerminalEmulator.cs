namespace AdventOfCode2022.Day7
{
    public class TerminalEmulator : ITerminalEmulator
    {
        private Directory workingDirectory = null!;

        public FileSystem ConstructFileSystem(IEnumerable<ITerminalLine> lines)
        {
            workingDirectory = null!;
            FileSystem? fileSystem = null;

            foreach (var line in lines)
            {
                switch (line)
                {
                    case TerminalCommandLine commandLine:
                        if (commandLine.Command == TerminalCommand.ChangeDirectory)
                        {
                            var directoryName = commandLine.Arguments;
                            if (directoryName == "..")
                            {
                                workingDirectory = workingDirectory?.Parent ?? throw new NotSupportedException();
                            }
                            else
                            {
                                if (workingDirectory == null)
                                {
                                    fileSystem ??= new FileSystem(directoryName);
                                    workingDirectory = fileSystem;
                                }
                                else
                                {
                                    var existingDirectory = workingDirectory.Children
                                        .OfType<Directory>()
                                        .SingleOrDefault(x => x.Name == directoryName);

                                    if (existingDirectory != null)
                                    {
                                        workingDirectory = existingDirectory;
                                    }
                                    else
                                    {
                                        workingDirectory.Add(new Directory(directoryName, workingDirectory));
                                    }
                                }
                            }
                        }
                        break;
                    case TerminalOutputLine outputLine:
                        var entry = GetOutputEntry(outputLine);
                        workingDirectory?.Add(entry);
                        break;
                }
            }

            return fileSystem ?? throw new NotSupportedException();
        }

        private IFileSystemEntry GetOutputEntry(TerminalOutputLine outputLine)
        {
            var parts = outputLine.Output.Split(' ');
            if (parts[0] == "dir")
            {
                return new Directory(parts[1], workingDirectory);
            }
            else
            {
                return new File(parts[1], int.Parse(parts[0]));
            }
        }

    }
}
