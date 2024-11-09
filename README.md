# Random Number Occurrence & Word Counter Console App

This is a C# console application that allows users to choose between two options:
1. Generating occurrences of random numbers within a specified range.
2. Counting occurrences of specific words within a provided string (case-insensitively).

The program uses Dependency Injection to manage and inject services for each functionality, following a modular and testable design.

## Table of Contents
- [Features](#features)
- [Structure](#structure)
- [.NET Framework](#net-framework)

## Features

- **Random Number Occurrence Generator**: Generates a set of random numbers within a specified range and counts the occurrences of each unique number.
- **Word Counter**: Counts occurrences of given words in a string, ignoring case differences.

## Structure

The program is divided into three main components:

- **Interfaces**:
  - `IRandomNumberGenerator`: Defines the method for generating random number occurrences.
  - `IWordCounter`: Defines the method for counting word occurrences.

- **Implementations**:
  - `RandomNumberGenerator`: Implements `IRandomNumberGenerator` to generate random numbers within a given range and count their occurrences.
  - `WordCounter`: Implements `IWordCounter` to count occurrences of specific words in a string, ignoring case.

- **Main Program**:
  - `Program`: The main application logic, with dependency injection of `IRandomNumberGenerator` and `IWordCounter`.

## .NET Framework

This application is built using **.NET 8.0**.
