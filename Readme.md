<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128621345/10.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1602)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MyTextEdit.cs](./CS/Q212749'/MyTextEdit.cs) (VB: [MyTextEdit.vb](./VB/Q212749'/MyTextEdit.vb))
<!-- default file list end -->
# How to implement the IncrementalBackColor and IncrementalForeColor properties


<p>When a user performs an incremental search within the XtraGrid, the colors used to highlight the matching text are obtained from the current skin. It's possible to create your own skin and provide your own background and foreground colors. If you don't want to create a new skin, you can accomplish this task by creating a descendant to the existing in-place editor and introducing properties allowing you to manually specify these colors. Then create a descendant of the corresponding ViewInfo class and override the GetSystemColor method.</p>


<h3>Description</h3>

<p>Starting from version 10.2, the TextEditPainter.DrawMatchedString method retrieves the appearance for the matching string from the current Skin. Therefore, the code responsible for replacing the default colors with custom ones was moved into the TextEditPainter class.</p>

<br/>


