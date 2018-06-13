
// Created by Austin Sutton on 9/26/2017.
//
#include <iostream>
#include <vector>
#include <sstream>
#include <cstring>

using namespace std;

unsigned long long reverse(unsigned long long num) {
    unsigned long long out = 0;
    while (num) {
        out *= 10;
        out += num % 10;
        num /= 10;
    }
    return out;
}

string findPalindrome(string &number) {
    int count = 0;
    auto num = static_cast<unsigned long long int>(atoll(number.c_str()));
    if (num == reverse(num)) {
        num += reverse(num);
        count++;
    }

    while (num != reverse(num)) {
        num += reverse(num);
        count++;
    }

    stringstream count_stream;
    stringstream number_stream;

    count_stream << count;
    number_stream << num;

    return count_stream.str() + " " + number_stream.str();
}

char* process(const char* numbers) {
    string asString(numbers);
    vector<string> takeNums;
    istringstream iss(asString);

    string result;

    for (; iss >> asString;)
        takeNums.push_back(asString);

    for (size_t i = 0; i < takeNums.size(); i++) {
        result += (findPalindrome(takeNums.at(i)));
        if (i != takeNums.size() - 1) {
            result += " ";
        }
    }

    auto cstr = new char[result.length() + 1];
    strcpy(cstr, result.c_str());

    return cstr;
}