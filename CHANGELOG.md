# Changelog


## 0.0.11 (17 May 2023)
- Fixed a few database typos
- Fixed an issue where loading profile only was not updating profile correctly
- Added an option to hide empty lines in World Analyzer

## 0.0.10 (11 May 2023)
- Add ability to display in italic items that cannot be obtained in the current save, because they depend on something else not avialable in the current save that the character does not currently have
- Changed to file-scoped namespaces
- Add setings path tooltip to the settings page about button

## 0.0.9 (10 May 2023)
- Small fix for adventure panel not updating

## 0.0.8 (10 May 2023)
- Nothing user facing - reworked internal logging system for easier integrations with the dependencies

## 0.0.7 (9 May 2024)
- Detect Resolute trait aquisition
- Fix rare crashes with backups pane

## 0.0.6 (8 May 2024)
- Fixed a crash on World Analyzer tab
- Made improvements so that next time something like this happens, it at least gives a error

## 0.0.5 (8 May 2024)
- Fixed release zip file, it wrongly used to have the release in the "publish" subfolder
- Dim items in "Possible Items" columns if these items were already looted in the save if possible. This does not work for all items, as not all items appear in saves. Also added an option not to dim
- Also added an option to completely hide the looted items above in the World Analyzer


## 0.0.4 (6 May 2024)
- Add option to log save data for debugging purposes
- Add option to dump analyzer data structures in json for debugging purposes
- Add option to log performance metrics for debugging purposes
- Fixed a few typos

## 0.0.3 (3 May 2024)

- Improve filtering out DLC items (in case you do not own DLC and do not want them shown)
- Fixed an issue where localisation to Location column in World Analyser should be applied and it was not
- Fixed potential crash on backup save [Razzmatazzz#228](https://github.com/Razzmatazzz/RemnantSaveGuardian/issues/228) [Razzmatazzz#208](https://github.com/Razzmatazzz/RemnantSaveGuardian/issues/208)

## 0.0.2 (3 May 2024)

- Initial release
