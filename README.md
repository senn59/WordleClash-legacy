[![Tests](https://github.com/senn59/WordleClash-legacy/actions/workflows/test.yml/badge.svg)](https://github.com/senn59/WordleClash-legacy/actions/workflows/test.yml)
# WordleClash
WordleClash is a web platform for playing Wordle both alone, or online with friends. 
The platorm has 3 different gamemodes namely:
- Singleplayer (play Wordle just as how you are used to)
- 1v1 (turn based Wordle against another opponent)
- Party (play Wordle with up to 4 friends and compete together to see who can guess the word first)

![Wordleclash preview](preview.png)
## Installation
(To be added)

## Technical info
This project was created in C# following the N-Tier architecture style meaning
there are 3 different layers in which the application is divided namely:
- .Web (Razor pages web application serving as the presentation layer)
- .Core (Class library serving as the business logic layer)
- .Data (Class library built for data retrieval and storage)

Furthermore there is a .Tests project which contains unit tests for the business logic
