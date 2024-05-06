#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <algorithm>
using namespace std;

int main() {
    fstream Advent(".\\Day13.txt", ios::in | ios::out);
    vector<string> code;
    string cur_line;
    while (getline(Advent, cur_line)) {
        if (cur_line.length() > 0) {
        code.push_back(cur_line);
        }
    }
    cout << code.size();
    code[0]
    sort(code.begin(), code.end());
    for (int i = 0; i < code.size(); i++) {
        cout << code[i] << endl;
    }
    return 0;
}