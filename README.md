# BasicTextEditor
Implementation of a simple text editor on WindowsForms using the MVP(Model-View-Presenter) pattern.
The MODEL level is implemented as a separately linked library (namespace BasicTextEditor.BL, class FileManager.cs). 
Interaction between MVP layers is implemented through interfaces.

Functional:

- Can open a text file in .txt format
- Can edit the opened text file
- Counting the number of characters in a text file
- Saving the changes made
- Increasing and decreasing the font in the displayed file content
