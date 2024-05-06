#include <iostream>
#include <array>
#include <fstream>
#include <string>
using namespace std;

enum Opponent {A, B, C};
enum Player {X, Y, Z};

int Calculate (Opponent Column1, Player Column2, Score Rock, Score Paper. Score Scissors) {
    int CurrentScore = 0;
    string Letter;
    switch (Column1) {
        case A:
            Letter = "A";
        case B:
            Letter = "B";
        case C:
            Letter = "C";
    }
    switch (Column2) {
        case X:
            CurrentScore += 1;
            CurrentScore += Rock.Letter;
            break;
        case Y:
            CurrentScore += 2;
            CurrentScore += Paper.Column1;
            break;
        case Z:
            CurrentScore += 3;
            CurrentScore += Scissors.Column1;
            break;
    }
    return CurrentScore;
}

int main() {
    struct Score
    {
        int A;
        int B;
        int C;
    };
    Score Rock, Paper, Scissors;
    Rock.A = 3; Rock.B = 0; Rock.C = 6;
    Paper.A = 6; Paper.B = 3; Paper.C = 0;
    Scissors.A = 0; Scissors.B = 6; Scissors.C = 3;

    int TotalScore = 0;

    return 0;
};