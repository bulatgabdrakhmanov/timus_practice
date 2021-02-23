#include <iostream>
#include <cmath>
#include <vector>

using namespace std;

vector<double> calculate_coors(string buttons) {
    double x = 0;
    double y = 0;
    double diagonalDistance = 1 / sqrt(2);

    for (char button: buttons) {
        if (button == '0') break;

        switch (button) {
            case '1':
                y -= diagonalDistance;
                x -= diagonalDistance;
                break;

            case '2':
                y--;
                break;

            case '3':
                y -= diagonalDistance;
                x += diagonalDistance;
                break;

            case '4':
                x--;
                break;

            case '6':
                x++;
                break;

            case '7':
                y += diagonalDistance;
                x -= diagonalDistance;
                break;

            case '8':
                y++;
                break;

            case '9':
                y += diagonalDistance;
                x += diagonalDistance;
                break;

            default:
                break;
        }
    }

    return {x, y};
}

int main() {
    string buttons;
    cin >> buttons;

    cout.precision(10);
    auto coors = calculate_coors(buttons);
    cout << fixed << coors[0] << " " << fixed << coors[1];

    return 0;
}
