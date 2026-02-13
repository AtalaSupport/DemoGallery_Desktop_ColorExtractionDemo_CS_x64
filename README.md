# ColorExtractionDemo
This application provides a demonstration of the ColorExtractionCommand included 
in the Atalasoft DotImage Advanced Document Cleanup module.

This command is used to detect color in a color image, and returns a 32-bit BGRA 
image with the alpha channel covering the non-color regions.  This can be used 
to determine if a scanned image is actually grayscale, in which case the image 
can be thresholded to B&W and saved using CCIT or JBIG2 compression, or saved as 
8-bit grayscale instead of 24-bit color.

This is the C# version

## Prerequisites
This demo assumes you have the Atalasoft DotImage SDK installed and licensed for 
DotImage Document Imaging. Optionally, you may wish to have a licnse for our 
PdfReader add-on if you would like for this demo to be able to read images from 
PDF files.

You may also request a 30 day evaluation when installing / activating.

[Download DotImage](https://www.atalasoft.com/BeginDownload/DotImageDownloadPage)

## Cloning
We recommend the following to ensure you clone with the required submodule

Example: git for windows
```bash
git clone https://github.com/AtalaSupport/DemoGallery_Desktop_ColorExtractionDemo_CS_x64.git ColorExtractionDemo
cd ColorExtractionDemo
git submodule init
git pull
```
