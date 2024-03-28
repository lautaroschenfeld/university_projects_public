using System;
using System.Diagnostics;

public class PrintMenu
{
    public static void MainMenu()
    {
        Console.Clear();
        TextFormat.TextFormat.Format(
            "---------- Adventure Circuit ----------\n\nSELECT AN OPTION:\n1 - Individual Ticket\n2 - Group Passport\n3 - Show Cash Register\n4 - Close Application",
            ConsoleColor.Blue, ConsoleColor.Black,
            "left", "center");
    }

    public static void IndividualEntry()
    {
        Console.Clear();
        TextFormat.TextFormat.Format(
            "You selected INDIVIDUAL TICKET",
            ConsoleColor.Blue, ConsoleColor.Black,
            "center", "top");
        TextFormat.TextFormat.Format(
            "\nNext, enter the data below, or '0' to finish the process",
            ConsoleColor.Blue, ConsoleColor.Black,
            "center", "top");
    }

    public static void PassportEntry()
    {
        Console.Clear();
        TextFormat.TextFormat.Format(
            "You selected GROUP PASSPORT",
            ConsoleColor.Blue, ConsoleColor.Black,
            "center", "top");
        TextFormat.TextFormat.Format(
            "\nNext, enter the number of group members, or '0' to finish the process",
            ConsoleColor.Blue, ConsoleColor.Black,
            "left", "top");
    }
}