#include <iostream>
#include <algorithm>
#include <vector>
#include <string>
//using namespace std; -- generally considered bad practice
 
//class Turn; 
class MonkeyPen;
 
enum MonkeyOperation {PLUS, MULTIPLY}; // for Math->MonkeyOperation for clarity
 
/*class Item -- you don't need this
{
    public:
    long long id;
    long long worry;
    Item(int id, long long worry);
};
Item::Item(int id, long long worry)
{
    this->id = id;
    this->worry = worry;
}*/
 
using Items = std::vector<long long>;
 
class Monkey
{
   private: // if everything is public, it should just be a struct, but these should be private
    // int id; - trying to put it here makes everything much more complicated, as you either need an index or you need to search for it
    int inspections_ = 0; 
    MonkeyOperation /*OpMath*/opMath_; // inconsistent variable naming -- typically class members are either m_camelCase or camelCase_
    int /*OpValue*/opValue_;
    int /*TestValue*/testValue_;
    int /*truemonkey*/trueMonkey_; 
    int /*falsemonkey*/falseMonkey_; 
    //vector<Item*> items; //never ever put raw pointers in a container, only shared_ptr, if needed (but not needed here)
    Items items_; // a simple int vector is enough
    bool DoTest(long long worry); 
    long long Operation(long long worry);
 public:
    //long long GetWorry();  - getworry is for an item, not for a monkey
    //void SetWorry(int position, long long worry); - worry shouldn't be changed from the outside
    void ThrowItems(MonkeyPen& pen/*, bool test*/); // I don't think this belongs in the Monkey, there should be a monkeypen manager that 
                                                // asks monkeys what they want to throw and forwards it to the other monkey, but 
                                                // I want to preserve something from the design
    Monkey(int itrue, int ifalse, MonkeyOperation math, int value, int test/*, int id*/, Items items);
    void AddItem(long long item) 
    {
        items_.push_back(item);
    }
    int inspections(){
        return inspections_;
    }
};
 
Monkey::Monkey(int itrue, int ifalse, MonkeyOperation math, int op_value, int test, Items items) 
: trueMonkey_(itrue), falseMonkey_(ifalse), opMath_(math), opValue_(op_value), testValue_(test), items_(items)
{
    /*this->truemonkey = itrue; -- error prone, use initializer list
    this->falsemonkey = ifalse;
    this->OpMath = math;
    this->OpValue = value;
    this->TestValue = test;*/
}
 
 
/*long long Monkey::GetWorry() 
{
    return this->items[0]->worry;
}
void Monkey::SetWorry(int position, long long worry)
{
    this->items[position]->worry = worry;
}*/
 
bool Monkey::DoTest(long long worry) // this is not an item but a worry level
{
    return worry % testValue_ == 0; // no point of having a function for a single operation, but whatever
/*    if ((item % this->TestValue) == 0) { -- no need for "this->", no need for if (true) return true else return false
        return true;
    }else{
        return false;
    }*/
}
 
long long Monkey::Operation(long long worry)
{
    switch (/*this->*/opMath_) // no need for "this->"
    {
        case MonkeyOperation::PLUS:
            if (/*this->*/opValue_ == -1) {
                worry += worry;
            } else {
                worry += opValue_;
            }
            break;
        case MonkeyOperation::MULTIPLY:
            if (/*this->*/opValue_ == -1) {
                worry *= worry;
            } else {
                worry *= opValue_;
            }
            break;
    }
    return worry; ///3;
}
 
class MonkeyPen // Turn -> MonkeyPen 
{
  private:
    std::vector<Monkey> monkeys_; // never put pointers in a container
  public:
        MonkeyPen(std::vector<Monkey> monkeys) : monkeys_(monkeys)
        {
 
        }
        Monkey& GetMonkey(int i)
        {
            return monkeys_[i];
        }
        void DoRound()
        {
            for (auto & monkey : monkeys_) {
                monkey.ThrowItems(*this);
            }
        }
    //public:
    //int rounds = 1; - does not belong here
    //int counter = 0; - not even sure what it is
};
 
 
/*void Turn::MoveCounter() - no idea what this is
{
    this->counter++;
    if (this->counter == 8) {
        this->counter = 0;
        this->rounds++;
    }
} */
 
// this is very far from the declaration, and really it should just be inlined
void Monkey::ThrowItems(MonkeyPen& pen/*, bool test*/)  // the monkey can very well do the test for himself
{
    for (auto item : items_) 
    {
        item = (Operation(item) % (long long)9699690);
        if (DoTest(item)) {
            pen.GetMonkey(trueMonkey_).AddItem(item);
        } else {
            pen.GetMonkey(falseMonkey_).AddItem(item);
        }
        inspections_ ++;
    }
    items_.clear();
    /*if (test == true) {
        turn.Monkeys[this->truemonkey]->items.push_back(this->items[0]); -- you shouldn't mess around with the monkey's items directly
                                                                         -- because he's gonna bite your hand!
        this->items.erase(this->items.begin());
    }else{
        turn.Monkeys[this->falsemonkey]->items.push_back(this->items[0]);
        this->items.erase(this->items.begin());
    }*/
}
 
int main ()
{
    // Create monkeys -- the short way
    MonkeyPen monkeys {
        {
            {3, 4, MonkeyOperation::MULTIPLY, 5, 11, {92, 73, 86, 83, 65, 51, 55, 93}},
            {6, 7, MonkeyOperation::MULTIPLY, -1, 2, {99, 67, 62, 61, 59, 98}},
            {1, 5, MonkeyOperation::MULTIPLY, 7, 5, {81, 89, 56, 61, 99}},
            {2, 5, MonkeyOperation::PLUS, 1, 17, {97, 74, 68}},
            {2, 3, MonkeyOperation::PLUS, 3, 19, {78, 73}},
            {1, 6, MonkeyOperation::PLUS, 5, 7, {50}},
            {0, 7, MonkeyOperation::PLUS, 8, 3, {95, 88, 53, 75}},
            {4, 0, MonkeyOperation::PLUS, 2, 13, {50, 77, 98, 85, 94, 56, 89}}
        }
    };
    // Create Items
 
    for (int rounds = 1; rounds <= 10000; ++rounds) {
        monkeys.DoRound();
        /*currentitems = turn.Monkeys[turn.counter]->items.size();
        for (int i = 0; i < currentitems; i++) { -- if you have a monkey class, it should be doing the throwing
            long long cur_worry = 0;
            bool test;
            // Monkey inspects, increases worry level, gets bored, decreases worry level
            turn.Monkeys[turn.counter]->inspections++;
            cur_worry = turn.Monkeys[turn.counter]->GetWorry();
            cur_worry = turn.Monkeys[turn.counter]->Operation(cur_worry);
            // have tried long long (gives 347 + 348) and int (gives 347 + 350)
            cur_worry = (long long)floor(cur_worry / 3);               // floor is meaningless, this is an integer division, in fact you
                                                                        // convert the division result to double and then back :)
            // Is worry level divisible by Monkey's test value
            test = turn.Monkeys[turn.counter]->TestItem(cur_worry);
            // Set new worry level on item
            turn.Monkeys[turn.counter]->SetWorry(0, cur_worry);
            // Throw to Monkey
            turn.Monkeys[turn.counter]->ThrowItem(turn, test);
            
        }*/ 
        //
        //turn.MoveCounter();
    }
    std::cout << monkeys.GetMonkey(0).inspections() << std::endl;
    std::cout << monkeys.GetMonkey(1).inspections() << std::endl;
    std::cout << monkeys.GetMonkey(2).inspections() << std::endl;
    std::cout << monkeys.GetMonkey(3).inspections() << std::endl;
    std::cout << monkeys.GetMonkey(4).inspections() << std::endl;
    std::cout << monkeys.GetMonkey(5).inspections() << std::endl;
    std::cout << monkeys.GetMonkey(6).inspections() << std::endl;
    std::cout << monkeys.GetMonkey(7).inspections() << std::endl;
    
 
    return 0;
}