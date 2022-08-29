# GartnerApp

## Environment development used
- Visual Studio 2022
- Windows System x64
- .Net Core 6
- NSubstitute for testing

## Installation steps
 1) Download the project from [https://github.com/inavarrojoaquin/gartnerapp](https://github.com/inavarrojoaquin/gartnerapp) 
 2) Open the .sln file with eg. Visual Studio

## To run the program
- Option 1:
 1) Run it from Visual Studio

- Option 2:
 1) Build the project (The GartnerApp.exe is created)
 2) Open a command line eg. cmd and go to the path where the GartnerApp.exe is.  
> **cd** C:\..\GartnerApp\GartnerApp\bin\Debug\net6.0

- Now the prompt shout be placed in the previous location eg.
> C:\..\GartnerApp\GartnerApp\bin\Debug\net6.0>

- From here run the program like:
> C:\..\GartnerApp\GartnerApp\bin\Debug\net6.0> GartnerApp.exe "import" "capterra" "feed-products/capterra.yaml"

- As you see it takes 3 params. The third could be "feed-products/capterra.yaml" or "feed-products/softwareadvice.json"

- Inside the project you will find a folder called "feed-products" where the processed files are.

## To run all unit tets from VS
- Right click on the solution then right click and "Run tests"

## Extras
- It is not the firts time writing unit tests. I daily work with it
- With more time I would apply:
> Command Pattern for managing multiple console command inputs
Database implementation
Logging for errors
Managing Exceptions
