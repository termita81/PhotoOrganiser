https://raw.githubusercontent.com/dlemstra/Magick.NET/master/Documentation/ReadingImages.md

# Reading images

## Read image

#### C#
```C#
// Read from file.
using (MagickImage image = new MagickImage("Snakeware.jpg"))
{
}

// Read from stream.
using (MemoryStream memStream = LoadMemoryStreamImage())
{
    using (MagickImage image = new MagickImage(memStream))
    {
    }
}

// Read from byte array.
byte[] data = LoadImageBytes();
using (MagickImage image = new MagickImage(data))
{
}

// Read image that has no predefined dimensions.
MagickReadSettings settings = new MagickReadSettings();
settings.Width = 800;
settings.Height = 600;
using (MagickImage image = new MagickImage("xc:yellow", settings))
{
}

using (MagickImage image = new MagickImage())
{
    image.Read("Snakeware.jpg");
    image.Read(memStream);
    image.Read("xc:yellow", settings);

    using (MemoryStream memStream = LoadMemoryStreamImage())
    {
        image.Read(memStream);
    }
}
```

#### VB.NET
```VB.NET
' Read from file.
Using image As New MagickImage("Snakeware.jpg")
End Using

' Read from stream.
Using memStream As MemoryStream = LoadMemoryStreamImage()
    Using image As New MagickImage(memStream)
    End Using
End Using

' Read from byte array.
Dim data As Byte() = LoadImageBytes()
Using image As New MagickImage(data)
End Using

' Read image that has no predefined dimensions.
Dim settings As New MagickReadSettings()
settings.Width = 800
settings.Height = 600
Using image As New MagickImage("xc:yellow", settings)
End Using

Using image As New MagickImage()
    image.Read("Snakeware.jpg")
    image.Read(memStream)
    image.Read("xc:yellow", settings)

    Using memStream As MemoryStream = LoadMemoryStreamImage()
        image.Read(memStream)
    End Using
End Using
```

## Read basic image information:

#### C#
```C#
// Read from file
MagickImageInfo info = new MagickImageInfo("Snakeware.jpg");

// Read from stream
using (MemoryStream memStream = LoadMemoryStreamImage())
{
    info = new MagickImageInfo(memStream);
}

// Read from byte array
byte[] data = LoadImageBytes();
info = new MagickImageInfo(data);

info = new MagickImageInfo();
info.Read("Snakeware.jpg");
using (MemoryStream memStream = LoadMemoryStreamImage())
{
    info.Read(memStream);
}
info.Read(data);

Console.WriteLine(info.Width);
Console.WriteLine(info.Height);
Console.WriteLine(info.ColorSpace);
Console.WriteLine(info.Format);
Console.WriteLine(info.Density.X);
Console.WriteLine(info.Density.Y);
Console.WriteLine(info.Density.Units);
```

#### VB.NET
```VB.NET
' Read from file
Dim info As New MagickImageInfo("Snakeware.jpg")

' Read from stream
Using memStream As MemoryStream = LoadMemoryStreamImage()
    info = New MagickImageInfo(memStream)
End Using

' Read from byte array
Dim data As Byte() = LoadImageBytes()
info = New MagickImageInfo(data)

info = New MagickImageInfo()
info.Read("Snakeware.jpg")
Using memStream As MemoryStream = LoadMemoryStreamImage()
    info.Read(memStream)
End Using
info.Read(data)

Console.WriteLine(info.Width)
Console.WriteLine(info.Height)
Console.WriteLine(info.ColorSpace)
Console.WriteLine(info.Format)
Console.WriteLine(info.Density.X);
Console.WriteLine(info.Density.Y);
Console.WriteLine(info.Density.Units);
```

## Read image with multiple layers/frames:

#### C#
```C#
// Read from file
using (MagickImageCollection collection = new MagickImageCollection("Snakeware.gif"))
{
}

// Read from stream
using (MemoryStream memStream = LoadMemoryStreamImage())
{
    using (MagickImageCollection collection = new MagickImageCollection(memStream))
    {
    }
}

// Read from byte array
byte[] data = LoadImageBytes();
using (MagickImageCollection collection = new MagickImageCollection(data))
{
}

// Read pdf with custom density.
MagickReadSettings settings = new MagickReadSettings();
settings.Density = new Density(144);

using (MagickImageCollection collection = new MagickImageCollection("Snakeware.pdf", settings))
{
}

using (MagickImageCollection collection = new MagickImageCollection())
{
    collection.Read("Snakeware.jpg");
    using (MemoryStream memStream = LoadMemoryStreamImage())
    {
        collection.Read(memStream);
    }
    collection.Read(data);
    collection.Read("Snakeware.pdf", settings);
}
```

#### VB.NET
```VB.NET
' Read from file
Using collection As New MagickImageCollection("Snakeware.gif")
End Using

' Read from stream
Using memStream As MemoryStream = LoadMemoryStreamImage()
    Using collection As New MagickImageCollection(memStream)
    End Using
End Using

' Read from byte array
Dim data As Byte() = LoadImageBytes()
Using collection As New MagickImageCollection(data)
End Using

' Read pdf with custom density.
Dim settings As New MagickReadSettings()
settings.Density = New Density(144)

Using collection As New MagickImageCollection("Snakeware.pdf", settings)
End Using

Using collection As New MagickImageCollection()
    collection.Read("Snakeware.jpg")
    Using memStream As MemoryStream = LoadMemoryStreamImage()
      collection.Read(memStream)
    End Using
    collection.Read(data)
    collection.Read("Snakeware.pdf", settings)
End Using
```






https://raw.githubusercontent.com/dlemstra/Magick.NET/master/Documentation/ExifData.md
# Exif data

## Read exif data

#### C#
```C#
// Read image from file
using (MagickImage image = new MagickImage("FujiFilmFinePixS1Pro.jpg"))
{
    // Retrieve the exif information
    ExifProfile profile = image.GetExifProfile();

    // Check if image contains an exif profile
    if (profile == null)
        Console.WriteLine("Image does not contain exif information.");
    else
    {
        // Write all values to the console
        foreach (ExifValue value in profile.Values)
        {
            Console.WriteLine("{0}({1}): {2}", value.Tag, value.DataType, value.ToString());
        }
    }
}
```

#### VB.NET
```VB.NET
' Read image from file
Using image As New MagickImage("FujiFilmFinePixS1Pro.jpg")
    ' Retrieve the exif information
    Dim profile As ExifProfile = image.GetExifProfile()

    ' Check if image contains an exif profile
    If profile Is Nothing Then
        Console.WriteLine("Image does not contain exif information.")
    Else
        ' Write all values to the console
        For Each value As ExifValue In profile.Values
            Console.WriteLine("{0}({1}): {2}", value.Tag, value.DataType, value.ToString())
        Next
    End If
End Using
```

## Create thumbnail from exif data

#### C#
```C#
// Read image from file
using (MagickImage image = new MagickImage("FujiFilmFinePixS1Pro.jpg"))
{
    // Retrieve the exif information
    ExifProfile profile = image.GetExifProfile();

    // Create thumbnail from exif information
    using (MagickImage thumbnail = profile.CreateThumbnail())
    {
        // Check if exif profile contains thumbnail and save it
        if (thumbnail != null)
            thumbnail.Write("FujiFilmFinePixS1Pro.thumb.jpg");
    }
}
```

#### VB.NET
```VB.NET
' Read image from file
Using image As New MagickImage("FujiFilmFinePixS1Pro.jpg")
    ' Retrieve the exif information
    Dim profile As ExifProfile = image.GetExifProfile()

    ' Create thumbnail from exif information
    Using thumbnail As MagickImage = profile.CreateThumbnail()
        ' Check if exif profile contains thumbnail and save it
        If thumbnail IsNot Nothing Then
            thumbnail.Write("FujiFilmFinePixS1Pro.thumb.jpg")
        End If
    End Using
End Using
```





https://raw.githubusercontent.com/dlemstra/Magick.NET/master/Documentation/ResizeImage.md
# Resize image

## Resize animated gif

#### C#
```C#
// Read from file
using (MagickImageCollection collection = new MagickImageCollection(SampleFiles.SnakewareGif))
{
    // This will remove the optimization and change the image to how it looks at that point
    // during the animation. More info here: http://www.imagemagick.org/Usage/anim_basics/#coalesce
    collection.Coalesce();

    // Resize each image in the collection to a width of 200. When zero is specified for the height
    // the height will be calculated with the aspect ratio.
    foreach (MagickImage image in collection)
    {
        image.Resize(200, 0);
    }

    // Save the result
    collection.Write(SampleFiles.OutputDirectory + "Snakeware.resized.gif");
}
```

#### VB.NET
```VB.NET
' Read from file
Using collection As New MagickImageCollection(SampleFiles.SnakewareGif)
    ' This will remove the optimization and change the image to how it looks at that point
    ' during the animation. More info here: http://www.imagemagick.org/Usage/anim_basics/#coalesce
    collection.Coalesce()

    ' Resize each image in the collection to a width of 200. When zero is specified for the height
    ' the height will be calculated with the aspect ratio.
    For Each image As MagickImage In collection
        image.Resize(200, 0)
    Next

    ' Save the result
    collection.Write(SampleFiles.OutputDirectory + "Snakeware.resized.gif")
End Using
```

## Resize to a fixed size

#### C#
```C#
// Read from file
using (MagickImage image = new MagickImage(SampleFiles.SnakewarePng))
{
    MagickGeometry size = new MagickGeometry(100, 100);
    // This will resize the image to a fixed size without maintaining the aspect ratio.
    // Normally an image will be resized to fit inside the specified size.
    size.IgnoreAspectRatio = true;

    image.Resize(size);

    // Save the result
    image.Write(SampleFiles.OutputDirectory + "Snakeware.100x100.png");
}
```

#### VB.NET
```VB.NET
' Read from file
Using image As New MagickImage(SampleFiles.SnakewarePng)

    Dim size = New MagickGeometry(100, 100)
    ' This will resize the image to a fixed size without maintaining the aspect ratio.
    ' Normally an image will be resized to fit inside the specified size.
    size.IgnoreAspectRatio = True

    image.Resize(size)

    ' Save the result
    image.Write(SampleFiles.OutputDirectory + "Snakeware.100x100.png")
End Using
```