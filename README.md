# SrtInjector

## Overview
SrtInjector is a simple command-line tool designed to inject the content of a TXT file into an SRT file. The tool is useful for scenarios where you have an SRT subtitle file and a corresponding TXT file with additional or modified subtitle content. SrtInjector allows you to replace specific lines in the SRT file with the content from the TXT file, creating a new SRT file with the updated subtitles.

SRT files have this format: https://en.wikipedia.org/wiki/SubRip

The TXT is just the contents of the text subtitles in the SRT file. 

## How to Use
Ensure that you have the .NET Runtime installed on your system.

Download the SrtInjector tool and extract it to a directory of your choice.

Place the SRT file and TXT file you want to inject into in the same directory as the SrtInjector executable.

The SRT and TXT files should be named `<fileName>.txt` and `<fileName>.srt` where `<fileName>` is the same for both files.

Note: It's always a good practice to keep backup copies of your original SRT files before using any modification tools like SrtInjector to avoid any unintentional data loss.

Run the SrtInjector application
After execution, a new SRT file will be created in the same directory, with the name `<fileName>.new.srt`. This new file will inject the original SRT file text contents with the contents of the TXT file.

If the new srt file could not be created due to problems with the original file, an error file will be created instead.

## Important Notes
The SrtInjector tool replaces the content of specific lines in the SRT file with the content from the TXT file. It assumes a specific format and structure for both files.
Make sure to review the resulting new SRT file to ensure that the injection was performed correctly and that the subtitle synchronization is maintained.
SrtInjector is a convenient tool for modifying or supplementing SRT subtitle files using the content from a TXT file. It simplifies the process of injecting new or updated subtitle content into existing SRT files, saving you time and effort in manually editing the files.