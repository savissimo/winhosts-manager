# WinHosts Manager

Hosts file management for Windows machines with a GUI and productivity features. 

![License](https://img.shields.io/github/license/savissimo/winhosts-manager)
![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/savissimo/winhosts-manager?label=stable)
![GitHub release (latest SemVer including pre-releases)](https://img.shields.io/github/v/release/savissimo/winhosts-manager?include_prereleases&label=latest)
![GitHub top language](https://img.shields.io/github/languages/top/savissimo/winhosts-manager)

## Why this project?

Pretty much any dev has to edit the hosts file sooner or later. On Windows, this means opening the file in a text editor that was launched with elevated privileges. This is cumbersome and often means you have to do the changes twice, because you forgot to run as administrator the first time. The file path is also easy to forget if you only use it occasionally. 

I tried to improve that workflow by adding a GUI, and making it easy to enable or disable the entries. More features are planned in the future. 

# Features

- Graphical interface for easy and intuitive visual editing. 
- Administrator privileges obtained through UAC at launch. 
- Hosts can be enabled and disabled — disabled hosts won't appear in the hosts file. 
- Writing to hosts file means that the changes are applied immediately! 
- Autosave: your changes are immediately stored to an internal file, and you'll be free to apply them at will. 

## Planned features

- Environments: single entries may have different values in different contexts. 
- CLI commands

# Install and run

Download the latest release from the [Releases page](https://github.com/savissimo/winhosts-manager/releases) and run the setup. 

Run "WinHosts Manager" from the Start Menu or from a link. 

# License

WinHosts Manager is released under the [MIT License](https://mit-license.org). See [LICENSE](LICENSE) for the full text of the license. 

# Contributing

If you wish to help this project, consider contributing a fix, an improvement or a new feature. Please file an issue before starting to work on it, and let me know that you intend to contribute the solution yourself. 

You're also invited to open an issue if you find any bug or if you have a feature request. The software is in a working state but it's still in beta, so a few known bugs are there, but let me know if you find anything anyway. 
