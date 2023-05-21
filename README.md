# SrtInjector

## Overview
SrtInjector is a simple command-line tool designed to inject the content of a TXT file into an SRT file (https://en.wikipedia.org/wiki/SubRip). 

The tool is useful for scenarios where you have an SRT subtitle file and you want to easily translate or modify itwithout all the extra metadata present in the SRT file itself.

This assumes you can generate a TXT file from the SRT file. Search `SRT to TXT converter online`.

The TXT is just the contents of the text subtitles in the SRT file.

Once you have the TXT file with the relevant changes, run the application and it will update the SRT file with them.

## Format

SRT
```
1
00:02:16,612 --> 00:02:19,376
Senator, we're making our final approach into Coruscant.

2
00:02:19,482 --> 00:02:21,609
Very good, Lieutenant.

3
00:03:13,336 --> 00:03:15,167
We made it.

4
00:03:18,608 --> 00:03:20,371
I guess I was wrong.

5
00:03:20,476 --> 00:03:22,671
There was no danger at all.
```

TXT without empty lines in between
```
Senator, we're making our final approach into Coruscant.
Very good, Lieutenant.
We made it.
I guess I was wrong.
There was no danger at all.
```

TXT with empty lines in between
```
Senator, we're making our final approach into Coruscant.

Very good, Lieutenant.

We made it.

I guess I was wrong.

There was no danger at all.
```

If you want to remove a subtitle, instead of leaving a line completely empty on the TXT file, add an ` ` empty space character

```
The line below has an empty space
  
The line on top has an empty space
```

## How to Use
Ensure that you have the .NET 6 Runtime installed on your system. (https://aka.ms/dotnet-core-applaunch?missing_runtime=true)

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