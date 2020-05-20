# Android Developer Notes

This chapter contains random notes that I discovered while developing mobile apps
with Xamarin Forms on the Android platform.  I hope they are useful to you.

## Unfortunately, your app has stopped

Sometimes, when operating with Android emulators, things will just break.  Some of the ideas here may assist with getting things going again:

1. Don't use a Shared Mono Runtime

    In Visual Studio, right-click the Android project, then select **Properties** or **Options**.  In the **Android Build** section, select the **General** tab.  Uncheck the checkbox next to **Use Shared Mono Runtime**.

2. Disable non-required ABIs

    Also in Visual Studio, right-click the Android project, then select **Properties** or **Options**.  In the **Android Build** section, select the **Advanced** tab.  Select only the ABIs that you are using.  For example, if you are running on the x86 emulator, you will want to disable the **armeabi** ABI.

Rebuild the entire project and then try running again.

## Missing libaot-mscorlib.dll.so

When running an application is debug mode, I sometimes saw the following deployment issue:

```bash
D/Mono    ( 1366): AOT module 'mscorlib.dll.so' not found: dlopen failed: library "/data/app-lib/TaskList.Droid-2/libaot-mscorlib.dll.so" not found
```

To fix this:

* Right-click on the **Droid** project and select **Properties**.
* Select the **Android Options** tab.
* Uncheck the **Use Fast Deployment** option.
* Save the properties sheet.
* Redeploy the application.

## Fixing Errors with the Visual Studio Emulator for Android

One of the issues I found while running on the Visual Studio Emulator for Android involved debugging.  The Android app
starts, then immediately closes and debugging stops.  In the output window, you see `Could not connect to the debugger`.
To fix this:

* Close the Android Emulator window.
* Open the **Hyper-V Manager**.
* Right-click the emulator you are trying to use and select **Settings...**.
* Expand the **Processor** node and select **Compatibility**.
* Check the **Migrate to a physical computer with a different processor version** box.
* Click on **OK**.

It's a good idea to do this on all the emulators.  When you start the emulator, this error should be gone.

## Disabling Visual Studio Emulator for Android

There are two emulators for Android.  One is supplied by Microsoft (the Visual Studio Emulator for Android) and
one is supplied by Google (the Google Android Emulator).  You can only use one of them.  To enable the usage of
the Google Android Emulator, you have to disable the Visual Studio Emulator for Android.

To disable the Visual Studio Emulator for Android, disable Hyper-V with this command:

```
bcdedit /set hypervisorlaunchtype off
```

You should then reboot.  If you wish to switch back to using the Visual Studio Emulator for Android, set the
hypervisorlaunchtype to auto and reboot again.

