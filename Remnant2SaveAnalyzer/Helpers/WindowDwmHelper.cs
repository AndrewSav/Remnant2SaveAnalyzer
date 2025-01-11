﻿using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Wpf.Ui.Appearance;
using Wpf.Ui.Interop;

namespace Remnant2SaveAnalyzer.Helpers;

internal class WindowDwmHelper
{
    internal class Win32Api
    {
        /// <summary>
        /// Determines whether the specified window handle identifies an existing window.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>If the window handle identifies an existing window, the return value is nonzero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
        public static extern bool IsWindow([In] IntPtr hWnd);
    }
    internal class Utilities
    {
        private static readonly PlatformID OsPlatform = Environment.OSVersion.Platform;

        private static readonly Version OsVersion = Environment.OSVersion.Version;

        // ReSharper disable UnusedMember.Global
        /// <summary>
        /// Whether the operating system is NT or newer. 
        /// </summary>
        public static bool IsNt => OsPlatform == PlatformID.Win32NT;

        /// <summary>
        /// Whether the operating system version is greater than or equal to 6.0.
        /// </summary>
        public static bool IsOsVistaOrNewer => OsVersion >= new Version(6, 0);

        /// <summary>
        /// Whether the operating system version is greater than or equal to 6.1.
        /// </summary>
        public static bool IsOsWindows7OrNewer => OsVersion >= new Version(6, 1);

        /// <summary>
        /// Whether the operating system version is greater than or equal to 6.2.
        /// </summary>
        public static bool IsOsWindows8OrNewer => OsVersion >= new Version(6, 2);

        /// <summary>
        /// Whether the operating system version is greater than or equal to 10.0* (build 10240).
        /// </summary>
        public static bool IsOsWindows10OrNewer => OsVersion.Build >= 10240;

        /// <summary>
        /// Whether the operating system version is greater than or equal to 10.0* (build 22000).
        /// </summary>
        public static bool IsOsWindows11OrNewer => OsVersion.Build >= 22000;

        /// <summary>
        /// Whether the operating system version is greater than or equal to 10.0* (build 22523).
        /// </summary>
        public static bool IsOsWindows11Insider1OrNewer => OsVersion.Build >= 22523;

        /// <summary>
        /// Whether the operating system version is greater than or equal to 10.0* (build 22557).
        /// </summary>
        public static bool IsOsWindows11Insider2OrNewer => OsVersion.Build >= 22557;
        // ReSharper restore UnusedMember.Global
    }
    internal enum UxMaterials
    {
        None = BackgroundType.None,
        Mica = BackgroundType.Mica,
        Acrylic = BackgroundType.Acrylic
    }
    internal static Color TransparentColor = Color.FromArgb(0x1, 0x80, 0x80, 0x80);
    internal static Brush TransparentBrush = new SolidColorBrush(TransparentColor);
    internal static bool IsSupported(UxMaterials type)
    {
            return type switch
            {
                UxMaterials.Mica => Utilities.IsOsWindows11OrNewer,
                UxMaterials.Acrylic => Utilities.IsOsWindows7OrNewer,
                UxMaterials.None => true,
                _ => false
            };
        }
    internal static WindowInteropHelper GetWindow(Window window)
    {
            return new(window);
        }
    internal static bool ApplyDwm(Window window, UxMaterials type)
    {
        IntPtr handle = GetWindow(window).Handle;

        if (type == UxMaterials.Mica && !Utilities.IsOsWindows11Insider1OrNewer)
        {
            type = UxMaterials.Acrylic;
        }
            
        if (!IsSupported(type))
            return false;

        if (handle == IntPtr.Zero)
            return false;

        if (!Win32Api.IsWindow(handle))
            return false;

        if (type == UxMaterials.None)
        {
            RestoreBackground(window);

#pragma warning disable CS0618 // Type or member is obsolete
            return UnsafeNativeMethods.RemoveWindowBackdrop(handle);
#pragma warning restore CS0618 // Type or member is obsolete

        }
        // First release of Windows 11
        if (!Utilities.IsOsWindows11Insider1OrNewer)
        {
            if (type == UxMaterials.Mica)
            {
                RemoveBackground(window);
#pragma warning disable CS0618 // Type or member is obsolete
                return UnsafeNativeMethods.ApplyWindowLegacyMicaEffect(handle);
#pragma warning restore CS0618 // Type or member is obsolete
            }

            if (type == UxMaterials.Acrylic)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                return UnsafeNativeMethods.ApplyWindowLegacyMicaEffect(handle);
#pragma warning restore CS0618 // Type or member is obsolete
            }

            return false;
        }

        // Newer Windows 11 versions
        RemoveBackground(window);
#pragma warning disable CS0618 // Type or member is obsolete
        return UnsafeNativeMethods.ApplyWindowBackdrop(handle, (BackgroundType)type);
#pragma warning restore CS0618 // Type or member is obsolete
    }

    /// <summary>
    /// Tries to remove background from <see cref="Window"/> and it's composition area.
    /// </summary>
    /// <param name="window">Window to manipulate.</param>
    /// <returns><see langword="true"/> if operation was successful.</returns>
    internal static void RemoveBackground(Window? window)
    {
            if (window == null)
                return;

            // Remove background from visual root
            window.Background = TransparentBrush;
        }
    internal static void RestoreBackground(Window? window)
    {
            if (window == null)
                return;

            object? backgroundBrush = window.Resources["ApplicationBackgroundBrush"];

            // Manual fallback
            if (backgroundBrush is not SolidColorBrush)
                backgroundBrush = GetFallbackBackgroundBrush();

            window.Background = (SolidColorBrush)backgroundBrush;
        }
    private static SolidColorBrush GetFallbackBackgroundBrush()
    {
            return Theme.GetAppTheme() == ThemeType.Dark
                ? new(Color.FromArgb(0xFF, 0x20, 0x20, 0x20))
                : new SolidColorBrush(Color.FromArgb(0xFF, 0xFA, 0xFA, 0xFA));
        }
}