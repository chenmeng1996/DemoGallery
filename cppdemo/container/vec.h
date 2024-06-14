#include <vector>
#include <iostream>
using namespace std;

void test() {
    vector<int> a = {1, 2, 3};
    for (auto i = 0; i != a.size(); ++i) {
        cout << a[i] << "\n";
    }
    for (auto& x : a) {
        cout << x << "\n";
    }
}