# Changelog


## v0.0.27 (2 Nov 2024)
- Fix Cessation Bulbel detection

## v0.0.26 (30 Oct 2024)
- Minor fixes for Mortal Coil and Repair Tool detection

## v0.0.25 (28 Oct 2024)
- Add DLC3 items

## v0.0.24 (14 Oct 2024)
- Fix a DLC3 crash

## v0.0.23 (12 Oct 2024)
- Fix a DLC3 crash

## v0.0.22 (20 July 2024)
- Added check for 10 corrupted shards for corrupted weapon prerequisites
- Added missing prerequisite of Savior to Corrupted Savior in the database
- Improved notes for Game Master's Pride in the database

## v0.0.21 (Unreleased)
- Includeed Location and Type into filter on World Analyzer tab
- Fixed regression with connections showing x2 for non-Yaesha zones
- Fixed various typos and formatting
- Updated dependencies

## v0.0.20 (13 June 2024)
- Fixed a crash when a loadout has one archetype only
- Fixed a crash on new character creation

## v0.0.19 (8 June 2024)
- Further performance optimizations (still need more)
- Relic fragments, Consumables, Concoctions and Dreams are now shown on the missing items page. The do not appear on the campaign/adventure page with a few minor exceptions (All-Seeing Eye, Dried Fruit, Koara Pellet and the four Dreams). They may be added at a later date.
- The number next to Archetypes in the character drop down and on the Backups page is the actual number of acquired items by the character, and not some abstract ever growing number any more. At the time of writing there are 751 items to acquire.

## v0.0.18 (5 June 2024)
- Amended Fix Necklace of Flowing Life crash fix from yesterday to not crash on Void Heart

## v0.0.17 (4 June 2024)
- Fixed Necklace of Flowing Life crash

## 0.0.16 (4 June 2023)
- Added the  Nimue/Dran/Huntress/Root Walker "Dream" consumables for detection of "craftable" items

## 0.0.15 (4 June 2023)
- Added a section to items not tied to a location with "craftable" items that the character already has materials for in the inventory

## 0.0.14 (4 June 2023)
- Performance improvements
- Stopped displaying warning about unknown Dran Dream item
- Fixed co-op option completely broken in World Analyser

## 0.0.13 (31 May 2023)
- Added an option to World Analyzer to display items not bound to a particular location
- Added Anguish detection

Here is how Anguish detection works. If you have not started the Anguish quest and you do not have Ethereal Manor, Anguish will not appear in World Analyzer. If you have not started the Anguish quest, but do have Ethereal Manor in the save, Anguish will appear in Ethereal Manor loot group. From this point on, it will move to the location where the next Dran is.

It will disappear from World Analyzer again, once you get the Dran Dream item. (There is an [issue](https://github.com/AndrewSav/Remnant2SaveAnalyzer/issues/6) to improve this part)

## 0.0.12 (28 May 2023)
- All items except for Anguish should be correctly detected now, if available (Crimson Guard armor set, Quilted Heart, Ripened Heart, Profane Heart, Downgraded Ring, Band of the Fanatic, Trinity Crossbow, Echo of the Forest, Crescent Moon)

## 0.0.11 (17 May 2023)
- Fixed a few database typos
- Fixed an issue where loading profile only was not updating profile correctly
- Added an option to hide empty lines in World Analyzer

## 0.0.10 (11 May 2023)
- Add ability to display in italic items that cannot be obtained in the current save, because they depend on something else not available in the current save that the character does not currently have
- Changed to file-scoped namespaces
- Add settings path tooltip to the settings page about button

## 0.0.9 (10 May 2023)
- Small fix for adventure panel not updating

## 0.0.8 (10 May 2023)
- Nothing user facing - reworked internal logging system for easier integrations with the dependencies

## 0.0.7 (9 May 2024)
- Detect Resolute trait acquisition
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
