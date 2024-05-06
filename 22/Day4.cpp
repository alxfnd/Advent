#include <iostream>
#include <string>
#include <vector>
#include <fstream>
using namespace std;

int main () {
    fstream Advent(".\\Day4.txt", ios::in | ios::out);
    string cur_text;
    int Overlaps = 0;
    vector<int> line;
    while (getline(Advent, cur_text)) {
        istringstream iss (cur_text);
        string s;
        while (getline(iss, s)) {
            line.clear();
            int value = 0;
            stringstream ss (s);
            while (ss >> value) {
                line.push_back(value);
            }
            for (int i : line) {
                cout << line[i];
                if (line[0] <= line[2] && line[1] >= line[3]) {
                    Overlaps++;
                }
                if (line[0] >= line[2] && line[1] <= line[3]) {
                    Overlaps++;
                }
            }
        }
    }
    /*
    while (getline(Advent, cur_line)) {
        cur_line.
        if (cur_line[0] <= cur_line[4] && cur_line[2] >= cur_line[6]) {
            Overlaps++;
        }
        if (cur_line[0] >= cur_line[4] && cur_line[2] <= cur_line[6]) {
            Overlaps++;
        }
    }
    */
    cout << Overlaps;
    return 0;
}