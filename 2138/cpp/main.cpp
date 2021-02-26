#include <iostream>
#include <cmath>

using namespace std;

typedef unsigned int uint;

int main() {
    string pc_type;
    uint n;

    cin >> pc_type >> n;

    uint result = 0;

    for (int i = 0; i < 4; i++) {
        result += n % 256 * pow(256, 3 - i);
        n /= 256;
    }

    cout << result;

    return 0;
}
