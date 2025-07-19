using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace CMSL.UI.Utils;

public class ImageUtils
{
    public static Bitmap LoadFromResource(string path)
    {
        return LoadFromResource(new Uri(path));
    }

    public static Bitmap LoadFromResource(Uri uri)
    {
        return new Bitmap(AssetLoader.Open(uri));
    }
}
