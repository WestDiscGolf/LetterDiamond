# Letter Diamond

The concept of this is to allow for displaying a 'Letter Diamond' to the console window when the target letter is specified on execution. The letter specified when running the application will determine how many rows, as per the index of the letter in the alphabet, and hence how big the diamond should be.

## Requirements
The code is built on the latest .NET 6 SDK which is currently rc1 of writing. This can be found - https://dotnet.microsoft.com/download/dotnet/6.0

## How to Run

1) Clone the repository
2) Build the LetterDiamond project in the `src` directory
3) Run the generated `exe` from the bin output folder with the target letter specified

## Example

```
C:\Temp\LetterDiamond> .\LetterDiamond.exe E
Selected Answer: E
    A
   B B
  C   C
 D     D
E       E
 D     D
  C   C
   B B
    A
```
