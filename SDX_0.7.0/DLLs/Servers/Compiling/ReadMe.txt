This modified Plugin.dll will allow you to skip the Localization step that SDX 0.7.0 attempts to do when compiling SDX mods for servers.

You will have to make all your changes to the localization text files yourself, rather than relying on SDX to merge.


This DLL fixes the following errors:


This avoids the following errors:

	EVENT: Begin task: Patch localization

	Unhandled Exception: System.ArgumentException: An item with the same key has already been added.
	   at System.ThrowHelper.ThrowArgumentException(ExceptionResource resource)
	   at System.Collections.Generic.Dictionary`2.Insert(TKey key, TValue value, Boolean add)
	   at System.Collections.Generic.Dictionary`2.Add(TKey key, TValue value)
	   at SevenDaysToDiePlugin.LocalizationTable.ReadFromStream(BinaryReader br)
   
--------------------------------------------------
   
	EVENT: Begin task: Patch localization
	 PatchFile: C:\SDX_0.7.0/Targets\7DaysToDie\Mods\True Survival SDX\Text/Localization.txt
	 Save text file: C:\Program Files (x86)\Steam\steamapps\common\7 Days to Die/Data/Config/Localization.txt

	Unhandled Exception: System.ArgumentNullException: Value cannot be null.
	Parameter name: source
	   at System.Linq.Enumerable.Contains[TSource](IEnumerable`1 source, TSource value, I