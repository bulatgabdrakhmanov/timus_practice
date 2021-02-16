#include <iostream>
#include <string>

using namespace std;

string get_palindrome_substr(string text) {
    string result = string{text[0]};

    for (int center = 0; center < text.size(); center++) {
        int left = center;
        int right = center;

        while (left > 0 && text[left - 1] == text[center]) left--;
        while (right < text.size() - 1 && text[right + 1] == text[center]) right++;

        while (left >= 1 && right < text.size() - 1 && text[left - 1] == text[right + 1])
        {
            left--;
            right++;
        }

        if (right - left + 1 > result.size())
        {
            result = text.substr(left, right - left + 1);
        }
    }

    return result;
}

int main() {
    string message;
    cin >> message;

    string result = message.size() <= 1
        ? message
        : get_palindrome_substr(message);

    cout << result;

    return 0;
}
