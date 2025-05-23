﻿#nullable disable

using System;

namespace SkiaSharp
{
	internal partial class SkiaApi
	{
#if (__IOS__ || __TVOS__ || __WATCHOS__) && !UNITY_EDITOR
		private const string SKIA = "@rpath/libSkiaSharp.framework/libSkiaSharp";
#else
		private const string SKIA = "libSkiaSharp";
#endif

#if USE_DELEGATES
		private static readonly Lazy<IntPtr> libSkiaSharpHandle =
			new Lazy<IntPtr> (() => LibraryLoader.LoadLocalLibrary<SkiaApi> (SKIA));

		private static T GetSymbol<T> (string name) where T : Delegate =>
			LibraryLoader.GetSymbolDelegate<T> (libSkiaSharpHandle.Value, name);
#endif
	}
}
