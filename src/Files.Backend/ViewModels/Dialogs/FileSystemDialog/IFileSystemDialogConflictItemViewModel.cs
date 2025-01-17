﻿using Files.Shared.Enums;

namespace Files.Backend.ViewModels.Dialogs.FileSystemDialog
{
    public interface IFileSystemDialogConflictItemViewModel
    {
        string? SourcePath { get; }

        string? DestinationPath { get; }

        FileNameConflictResolveOptionType ConflictResolveOption { get; }
    }
}
