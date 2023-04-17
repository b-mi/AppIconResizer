# AppIconResizer
Resize source png/ico image into other sizes of app icons (for Angular PWA application)

## Usage:

Console application:

AppIconResizer <input-file-name> [list of sizes divided by comma]

## Example:
- AppIconResizer C:\source-image.png 72 96 128 144
- AppIconResizer C:\source-image.png
	- create images for this default list: 72, 96, 120, 128, 144, 152, 192, 384, 512

## Naming convention:
-icon-384x384.png
-icon-128x128.png
-icon-512x512.png
-icon-120x120.png
-icon-144x144.png
-icon-152x152.png
-icon-192x192.png
-icon-72x72.png
-icon-96x96.png

Resizing of image preserve transparent background
