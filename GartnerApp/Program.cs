﻿// See https://aka.ms/new-console-template for more information

using Infrastructure;

try
{
    StartProgram startProgram = new StartProgram(args);
    startProgram.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}