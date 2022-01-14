# MarkdownImageUploader

## General info
Console app that takes all image links from your markdown and puts those images on Azure Blob Storage.

## Example
First you have to fill the placeholder values with proper ones (when you browse through the code you will easily notice them).
For this example I used markdown in this form:

### Test
Example markdown file, remember to replace images paths with your own-local
![first](first.jpg)\n
![second](second.jpg) \n
![third](third.jpg) test\n

So my container was at the beginning empty:
![Begin image](https://raw.githubusercontent.com/ptakpiotr/MarkdownImageUploader/master/img1.png)

And after executing the code, those files appeared in it!
![After image](https://raw.githubusercontent.com/ptakpiotr/MarkdownImageUploader/master/img2.png)