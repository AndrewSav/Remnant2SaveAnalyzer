# Remnant 2 Save Analyzer

This is a fork of the excellent [Remnant Save Guardian](https://github.com/Razzmatazzz/RemnantSaveGuardian) originally created by Razzmatazz.

## Archival Notice

I forked Remnant Save Guardian because I needed a UI to test and debug my Remnant 2 Save parsing libraries (links are at the bottom of this page). Since then a different UI based on my library was created: [Remnant Overseer](https://github.com/Angelore/remnant-two-overseer). Because of this, this particular project outlived its usefulness, and thus I'm archiving it.

## Differences with Remnant Save Guardian

- The underlying save parsing engine is completely different and allows for more fidelity in item detection
- Every single item showed by the program has a tooltip that describes how to find it
- Hide Ward 13, Labyrinth and Root Earth, once you feel you know them by heart
- Hide Tomes of Knowledge, once you are maxed out, you might not be that much interested in them
- See connections between locations
- See World Stones
- See if a Simulacrum is present in a location
- Items already looted in a save are dimmed in World Analyzer (not all items can be detected as looted)
- Items that cannot be obtained in a save without re-rolling because of missing prerequisites are shown in italic in World Analyzer
- Export save as json for geeks only


## Potential improvements

See <https://github.com/Angelore/remnant-two-overseer/issues>

## Known issues

Since the project is archived, these issues are not planned to be fixed:

- This program is a bit slower than RSG due to different parsing engine. On SSD the slowdown is noticeable but IMO tolerable
- Translations might not work as they used, and for the newer content there are none
- [If you are using Norton Antivirus, it may cause weirdness with your game saves and RemnantSaveGuardian](https://github.com/Razzmatazzz/RemnantSaveGuardian/issues/70)

## Save Parsing

These are the save parsing libraries being used underneath:
- <https://github.com/AndrewSav/lib.remnant2.saves> - This parses the save files to an object model
- <https://github.com/AndrewSav/lib.remnant2.analyzer> - Uses the above to get information about items from the saves

*Note: The object model for and Unreal Engine game save is incredibly complicated, it is not mean for usage out of the game, the way we do it here. It can lead to a lot of subtle usage issues, but it is much better than the original string parsing*

## Acknowledgement

Thanks to all original project contributors!
