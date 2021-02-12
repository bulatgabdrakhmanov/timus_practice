#include <iostream>
#include <vector>
#include <string>

using namespace std;

int read_n() {
    int n = 0;
    cin >> n;
    return n;
}

vector<string> read_codes() {
    vector<string> codes{};

    string code;
    while (getline(cin, code)) {
        if (code.empty()) continue;
        codes.push_back(code);
    }

    return codes;
}

bool mod_is_0(int a, int b) {
    return a % b == 0;
}

string replaced_code(string code) {
    int n = code.size();
    string result = code;
    int sum = 0;
    vector<int> unit_positions;

    for (int i = 0; i < n; i++) {
        if (code[i] == '0') continue;
        unit_positions.push_back(i + 1);
        sum += i + 1;
    }

    if (mod_is_0(sum, n + 1)) return result;

    int fake_unit_pos = 0;
    for (int unit_pos: unit_positions) {
        if (mod_is_0(sum - unit_pos, n + 1)) {
            fake_unit_pos = unit_pos - 1;
            break;
        }
    }

    result[fake_unit_pos] = '0';
    return result;
}

string supplemented_code(string code) {
    int n = code.size() + 1;
    string result = code;
    int sum = 0;
    vector<int> unit_positions;

    for (int i = 0; i < n - 1; i++) {
        if (code[i] == '0') continue;
        unit_positions.push_back(i + 1);
        sum += i + 1;
    }

    if (mod_is_0(sum, n + 1)) return code + "0";

    int units_left = unit_positions.size();
    int insert_item_pos = 0;
    char insert_item = '0';

    for (int i = 0; i < n; i++) {
        if (mod_is_0(sum + units_left, n + 1) || mod_is_0(sum + units_left + i + 1, n + 1)) {
            insert_item = mod_is_0(sum + units_left, n + 1) ? '0' : '1';
            insert_item_pos = i;
            break;
        }

        if (code[i] == '1') units_left--;
    }

    result.insert(insert_item_pos, string{insert_item});
    return result;
}

string stripped_code(string code) {
    int n = code.size() - 1;
    string result = code;
    int sum = 0;
    vector<int> unit_positions;

    for (int i = 0; i < n + 1; i++) {
        if (code[i] == '0') continue;
        unit_positions.push_back(i + 1);
        sum += i + 1;
    }

    int units_left = unit_positions.size();
    int delete_item_pos = 0;

    for (int i = 0; i < n + 1; i++) {
        bool is1 = code[i] == '1';
        if (is1) units_left--;

        if (mod_is_0(sum - units_left - (is1 ? i + 1 : 0), n + 1)) {
            delete_item_pos = i;
            break;
        }
    }

    result.erase(delete_item_pos, 1);
    return result;
}

int main() {
    int n = read_n();
    auto codes = read_codes();

    for (auto& code: codes) {
        int len = code.size();

        string result;

        if (len == n) result = replaced_code(code);
        else if (len < n) result = supplemented_code(code);
        else result = stripped_code(code);

        cout << result << endl;
    }

    return 0;
}
