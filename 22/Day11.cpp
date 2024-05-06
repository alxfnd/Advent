#include <iostream>
#include <algorithm>
#include <fstream>
#include <vector>
#include <string>
#include <sstream>
#include <cmath>
using namespace std;

class Turn;

enum Math {PLUS, MULTIPLY};

class Item
{
    public:
    int id;
    long long worry;
    Item(int id, long long worry);
};

Item::Item(int id, long long worry)
{
    this->id = id;
    this->worry = worry;
}

class Monkey
{
    public:
    int id;
    int inspections = 0;
    int sanity = 96577;
    Math OpMath;
    int OpValue;
    int TestValue;
    int truemonkey;
    int falsemonkey;
    vector<Item*> items;
    long long Operation(long long item);
    long long GetWorry();
    void SetWorry(int position, long long worry);
    bool TestItem(long long item);
    void ThrowItem(Turn& turn, bool test);
    Monkey(int itrue, int ifalse, Math math, int value, int test, int id);
};

Monkey::Monkey(int itrue, int ifalse, Math math, int value, int test, int id)
{
    this->truemonkey = itrue;
    this->falsemonkey = ifalse;
    this->OpMath = math;
    this->OpValue = value;
    this->TestValue = test;
}

long long Monkey::GetWorry()
{
    return this->items[0]->worry;
}

void Monkey::SetWorry(int position, long long worry)
{
    this->items[position]->worry = worry;
}

bool Monkey::TestItem(long long item)
{
    if ((item % this->TestValue) == 0) {
        return true;
    }else{
        return false;
    }
}

long long Monkey::Operation(long long item)
{
    switch (this->OpMath)
    {
        case Math::PLUS:
            if (this->OpValue == -1) {
                //return floor((item + item) / 3);
                return (item + item);
            }else{
                //return floor((item + this->OpValue) / 3);
                return (item + OpValue);
            }
        case Math::MULTIPLY:
            if (this->OpValue == -1) {
                //return ((item % sanity) * item);
                return (item * item);
                //return floor((item * item) / 3);
            }else{
                //return ((item % sanity) * OpValue);
                return (item * OpValue);
                //return floor((item * this->OpValue) / 3);
            }
    }
    throw new exception();
}

class Turn
{
    public:
    int rounds = 0;
    int counter = 0;
    vector<Monkey*> Monkeys;
    void MoveCounter();
};

void Turn::MoveCounter()
{
    this->counter++;
    if (this->counter == 4) {
        this->counter = 0;
        this->rounds++;
    }
    return;
}

void Monkey::ThrowItem(Turn& turn, bool test)
{
    if (test == true) {
        //cout << "Item is divisible by test value, throwing to true monkey" << endl;
        //this->items.erase(1);
        turn.Monkeys[this->truemonkey]->items.push_back(this->items[0]);
        this->items.erase(this->items.begin());
        //this->items.erase(auto i = 0, auto b = 1);
        //cout << "Monkey now has " << this->items.size();
        //cout << " items" << endl;
    }else{
        //cout << "Item is NOT divisible by test value, throwing to false monkey" << endl;
        turn.Monkeys[this->falsemonkey]->items.push_back(this->items[0]);
        this->items.erase(this->items.begin());
        //this->items.erase(auto i = 0, auto b = 1);
        //cout << "Monkey now has " << this->items.size();
        //cout << " items" << endl;
    }
}

int main ()
{
    //TO DO:
    // Auto generate monkeys based on input
    // Auto create items for each monkey based on input



    // Create monkeys
    Turn turn;
    turn.Monkeys.push_back(new Monkey(2, 3, Math::MULTIPLY, 19, 23, 0));
    turn.Monkeys.push_back(new Monkey(2, 0, Math::PLUS, 6, 19, 1));
    turn.Monkeys.push_back(new Monkey(1, 3, Math::MULTIPLY, -1, 13, 2));
    turn.Monkeys.push_back(new Monkey(0, 1, Math::PLUS, 3, 17, 3));
    // Create Items
    turn.Monkeys[0]->items.push_back(new Item(0, 79));
    turn.Monkeys[0]->items.push_back(new Item(1, 98));
    turn.Monkeys[1]->items.push_back(new Item(2, 54));
    turn.Monkeys[1]->items.push_back(new Item(3, 65));
    turn.Monkeys[1]->items.push_back(new Item(4, 75));
    turn.Monkeys[1]->items.push_back(new Item(5, 74));
    turn.Monkeys[2]->items.push_back(new Item(6, 79));
    turn.Monkeys[2]->items.push_back(new Item(7, 60));
    turn.Monkeys[2]->items.push_back(new Item(8, 97));
    turn.Monkeys[3]->items.push_back(new Item(9, 74));
    //Begin the real work
    
    int currentitems = 0;

    while (turn.rounds < 10000) {
        currentitems = turn.Monkeys[turn.counter]->items.size();
        for (int i = 0; i < currentitems; i++) {
            long long cur_worry = 0;
            bool test;
            // Monkey inspects, increases worry level, gets bored, decreases worry level
            turn.Monkeys[turn.counter]->inspections++;
            cur_worry = turn.Monkeys[turn.counter]->GetWorry();
            cur_worry = (turn.Monkeys[turn.counter]->Operation(cur_worry) % 96577);
            // Is worry level divisible by Monkey's test value
            test = turn.Monkeys[turn.counter]->TestItem(cur_worry);
            // Set new worry level on item
            turn.Monkeys[turn.counter]->SetWorry(0, cur_worry);
            // Throw to Monkey
            turn.Monkeys[turn.counter]->ThrowItem(turn, test);
        }
        if (turn.rounds == 1) {
            //break;
        }
        turn.MoveCounter();
    }
    //cout << turn.Monkeys[0]->items.size() << endl;
    cout << turn.Monkeys[0]->inspections << endl;
    //cout << turn.Monkeys[1]->items.size() << endl;
    cout << turn.Monkeys[1]->inspections << endl;
    //cout << turn.Monkeys[2]->items.size() << endl;
    cout << turn.Monkeys[2]->inspections << endl;
   // cout << turn.Monkeys[3]->items.size() << endl;
    cout << turn.Monkeys[3]->inspections << endl;
    

    return 0;
}