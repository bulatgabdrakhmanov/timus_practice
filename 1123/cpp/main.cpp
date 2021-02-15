#include <iostream>
#include <string>

using namespace std;

string get_salary_palindrome(string s) {
    if (s.size() <= 1) return s;

    string result = s;
    int middle_item_pos = ((int)result.size() - 1 ) / 2;

    for (int i = middle_item_pos + 1; i < result.size(); i++) {
        char item = result[i];
        char mirror_item = result[result.size() - i - 1];

        if (item == mirror_item) continue;
        if (item < mirror_item) break;

        int remainder = 1;
        int j = middle_item_pos;
        while (j >= 0 && remainder != 0) {
            int num = result[j] - '0';
            num += remainder;
            remainder = num / 10;
            result[j] = (num % 10) + '0';
            j--;
        }

        break;
    }

    for (int i = middle_item_pos + 1; i < result.size(); i++) {
        result[i] = result[result.size() - i - 1];
    }

    return result;
}

int main() {
    string salary;
    cin >> salary;

    cout << get_salary_palindrome(salary);

    return 0;
}
